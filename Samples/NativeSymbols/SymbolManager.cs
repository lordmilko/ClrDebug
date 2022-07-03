using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace NativeSymbols
{
    internal unsafe class SymbolManager
    {
        private IntPtr identifier;
        private SymbolClient symbolClient;

        private Dictionary<string, IMAGEHLP_MODULE64> knownAssemblies = new Dictionary<string, IMAGEHLP_MODULE64>(StringComparer.OrdinalIgnoreCase);

        public SymbolManager(IntPtr identifier)
        {
            /* You want to read symbols of an unmanaged module. There are several options available to you:
             * - DbgHelp.dll in system32 is obviously the way to go...except Windows doesn't ship with symsrv.dll, so you're completely unable to download PDBs to get symbols for
             * - The Debugging Tools for Windows comes with both DbgHelp.dll and symsrv.dll! But now you're forced to take a dependency on both these tools even being installed,
             *   and being able to find them even if they are.
             * - If you install both the Microsoft.Debugging.Platform.DbgEng and Microsoft.Debugging.Platform.SymSrv NuGet packages,
             *   you'll be able to include DbgHelp and SymSrv in your application...except now you have to deal with making sure your program is using the right one based on based on the bitness of the running program
             * - The ISymUnmanagedReader interface sounds promising. Despite being part of .NET, it does work on pure unmanaged assemblies. But it doesn't actually seem to work on PDBs from Microsoft's symbol servers,
             *   and even if it did it's way more low level than DbgHelp is
             * - The same problem also applies to Microsoft.DiaSymReader and dnlib, both of which rely on ISymUnmanagedReader / Microsoft.DiaSymReader.Native
             * - Speaking of DIA (Debug Interface Access), it would seem that the APIs in DiaSymReader are not the same APIs as you find in the normal DIA SDK; not that it matters, as apparently it only ships with Visual Studio
             * - You might be wondering how Visual Studio resolves its symbols; naturally, it seems it uses its own custom PDB engine, with custom DLLs like symbollocator.dll, etc
             *
             * So what's the solution? The simplest solution to me is to handle the duties of symsrv.dll ourselves, and then instruct DbgHelp where to look to find symbols once we've already downloaded them.
             * You can't rely on having a _NT_SYMBOL_PATH either in this situation: _NT_SYMBOL_PATH is evidently parsed by symsrv, not dbghelp */

            this.identifier = identifier;
            symbolClient = new SymbolClient();

            var result = NativeMethods.SymInitialize(identifier, symbolClient.CacheStore.CacheDirectory, false);

            if (!result)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            NativeMethods.SymSetOptions(SYMOPT.CASE_INSENSITIVE);
        }

        public SymbolInfo[] GetSymbols(string expression)
        {
            string fileName;
            string expr;
            ParseExpression(expression, out fileName, out expr);

            var moduleInfo = EnsureSymbols(fileName);

            /* SymEnumSymbols allows specifying a BaseOfDll (which limits the search to the specified DLL)
             * and a wildcard mask (which identifies the symbols to return). If no base address is specified,
             * the wildcard mask MUST contain a pattern specifying the modules to consider. e.g. with no
             * base address, if you wanted to search for everything, you would have to do *!* instead of merely *
             * If a baseAddress IS specified, the pattern is scoped to the module in question */

            var results = new List<SymbolInfo>();

            var result = NativeMethods.SymEnumSymbols(
                identifier,
                moduleInfo.BaseOfImage,
                expr,
                (info, size, context) =>
                {
                    var symbol = new SymbolInfo(identifier, info, moduleInfo.ModuleName);

                    results.Add(symbol);

                    return true;
                },
                IntPtr.Zero
            );

            if (!result)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return results.ToArray();
        }

        public SymbolInfo GetSymbol(ulong address)
        {
            var maxNameLength = 2000;

            //If you were using SymFromAddrW, you would do maxNameLength * 2
            var nameBytes = maxNameLength;

            var structSize = Marshal.SizeOf<SYMBOL_INFO>();

            var buffer = Marshal.AllocHGlobal(structSize + nameBytes);

            try
            {
                SYMBOL_INFO* pNative = (SYMBOL_INFO*)buffer;
                pNative->SizeOfStruct = structSize;
                pNative->MaxNameLen = maxNameLength; // Characters, not bytes!

                ulong displacement;

                var result = NativeMethods.SymFromAddr(
                    identifier,
                    address,
                    out displacement,
                    buffer
                );

                if (!result)
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

                return new SymbolInfo(identifier, buffer, GetModule(address).ModuleName);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public IMAGEHLP_MODULE64 GetModule(ulong address)
        {
            IMAGEHLP_MODULE64 moduleInfo = new IMAGEHLP_MODULE64();
            moduleInfo.SizeOfStruct = Marshal.SizeOf<IMAGEHLP_MODULE64>();

            var result = NativeMethods.SymGetModuleInfo64(
                identifier,
                address,
                ref moduleInfo
            );

            if (!result)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return moduleInfo;
        }

        public ulong GetModuleBase(ulong address)
        {
            var result = NativeMethods.SymGetModuleBase64(
                identifier,
                address
            );

            if (result == 0)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return address;
        }

        private void ParseExpression(string expression, out string fileName, out string expr)
        {
            if (!expression.Contains("!"))
            {
                fileName = expression;
                expr = "*";
            }
            else
            {
                var split = expression.Split('!');

                if (split.Length != 2)
                    throw new InvalidOperationException($"Expression '{expression}' contained more than one exclamation mark");

                fileName = split[0];
                expr = split[1];
            }
        }

        private IMAGEHLP_MODULE64 EnsureSymbols(string fileName)
        {
            fileName = GetAbsoluteFileName(fileName);

            IMAGEHLP_MODULE64 moduleInfo;

            if (!knownAssemblies.TryGetValue(fileName, out moduleInfo))
            {
                //If the PDB does not exist in our cache symbol store, it will automatically be downloaded.
                //DbgHelp will then be able to pick it up from the UserSearchPath we specified to SymInitialize()
                var pdb = symbolClient.GetPdb(fileName);

                var baseAddress = NativeMethods.SymLoadModuleExW(
                    identifier,
                    IntPtr.Zero,
                    fileName,
                    null,
                    0,
                    0
                );

                if (baseAddress == 0)
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

                moduleInfo = GetModule(baseAddress);

                knownAssemblies[fileName] = moduleInfo;
            }

            return moduleInfo;
        }

        private string GetAbsoluteFileName(string fileName)
        {
            if (fileName == "this")
                return Process.GetCurrentProcess().MainModule.FileName;

            if (!Path.IsPathRooted(fileName))
            {
                var originalName = fileName;

                var ext = Path.GetExtension(fileName);

                if (ext == string.Empty)
                    fileName += ".dll";

                fileName = "C:\\Windows\\system32\\" + fileName;

                if (!File.Exists(fileName))
                {
                    //If no extension was specified, maybe its an EXE?
                    if (ext == string.Empty)
                    {
                        var exeName = "C:\\Windows\\system32\\" + originalName + ".exe";

                        if (File.Exists(exeName))
                            return exeName;
                    }

                    throw new InvalidOperationException($"Cannot find file '{fileName}'");
                }
            }

            return fileName;
        }
    }
}
