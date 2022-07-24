using System;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng;

namespace NativeSymbols
{
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    internal delegate bool PSYM_ENUMERATESYMBOLS_CALLBACK(
        [In] IntPtr pSymInfo,
        [In] int SymbolSize,
        [In] IntPtr UserContext);

    internal static class NativeMethods
    {
        private const string dbghelp = "dbghelp.dll";

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymInitialize(IntPtr hProcess, string UserSearchPath, bool fInvadeProcess);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern ulong SymLoadModuleExW(
            IntPtr hProcess,
            [Optional] IntPtr hFile,
            [Optional, MarshalAs(UnmanagedType.LPWStr)] string ImageName,
            [Optional, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            ulong BaseOfDll,
            uint DllSize,
            [Optional] IntPtr Data,
            [Optional] int Flags
        );

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymEnumSymbols(
            [In] IntPtr hProcess,
            [In] ulong BaseofDll,
            [In, MarshalAs(UnmanagedType.LPStr)] string Mask,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback,
            [In] IntPtr UserContext);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymEnumTypesByName(
            [In] IntPtr hProcess,
            [In] ulong BaseOfDll,
            [In, MarshalAs(UnmanagedType.LPStr)] string Mask,
            [In, MarshalAs(UnmanagedType.FunctionPtr)]
            PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback,
            [In] IntPtr UserContext);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern SYMOPT SymSetOptions(SYMOPT symOptions);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymFromAddr(
            [In] IntPtr hProcess,
            [In] ulong address,
            [Out] out ulong displacement,
            [Out] IntPtr pSymbolInfo);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymGetModuleInfo64(
            [In] IntPtr hProcess,
            [In] ulong qwAddr,
            [In, Out] ref IMAGEHLP_MODULE64 ModuleInfo);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern ulong SymGetModuleBase64(
            [In] IntPtr hProcess,
            [In] ulong qwAddr);

        [DllImport(dbghelp, SetLastError = true)]
        internal static extern bool SymSearch(
            [In] IntPtr hProcess,
            [In] ulong BaseOfDll,
            [In] int Index,
            [In] SymTag SymTag,
            [In, MarshalAs(UnmanagedType.LPStr)] string Mask,
            [In] ulong Address,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback,
            [In] IntPtr UserContext,
            [In] SYMSEARCH Options);
    }
}
