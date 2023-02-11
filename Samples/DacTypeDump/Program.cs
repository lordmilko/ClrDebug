using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug;
using static ClrDebug.Extensions;

namespace DacTypeDump
{
    class Program
    {
        private static SOSDacInterface sosDacInterface;

        /// <summary>
        /// Demonstrates how the <see cref="IXCLRDataProcess"/> and <see cref="ISOSDacInterface"/> interfaces can be retrieved and used to perform
        /// low level analysis against a debug target using the .NET Framework.<para/>
        /// .NET Core will be similar, except instead of mscordacwks.dll, alternate DLLs such as mscordaccore.dll or otherwise will be used instead.
        /// </summary>
        static void Main(string[] args)
        {
            //We'll demonstrate the principles shown in this sample using PowerShell, a .NET application found on all Windows computers
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                WindowStyle = ProcessWindowStyle.Minimized,
            };
            var process = Process.Start(psi);

            //Create an ICLRDataTarget that will facilitate communicating between this program and our debug target (PowerShell)
            var dataTarget = new DataTarget(process);

            /* Get a delegate for mscordacwks!CLRDataCreateInstance. One of the Extensions.CLRDataCreateInstance() overloads encapsulates this logic for Windows systems,
             * however you can additionally create this delegate from the relevant DAC assembly for your platform yourself */
            var clrDataCreateInstance = GetCLRDataCreateInstance();

            /* ClrDebug provides various helper functions/methods for scenarios where multiple interfaces can potentially be retrieved.
             * Our pseudo CLRDataCreateInstance function returns an object that provides access to all the interfaces it knows you can potentially retrieve.
             * In this sample, we don't actually need to use IXCLRDataProcess, however this demonstrates how if you do have one, it's easy to get an ISOSDacInterface from it */
            var dataProcess = CLRDataCreateInstance(clrDataCreateInstance, dataTarget).XCLRDataProcess;

            //Rather than creating a new mscordacwks!ClrDataAccess object, we'll simply QueryInterface ISOSDacInterface out of our IXCLRDataProcess
            sosDacInterface = new SOSDacInterface((ISOSDacInterface) dataProcess.Raw);

            var numAppDomains = sosDacInterface.AppDomainStoreData.DomainCount;

            /* There are several types of AppDomains: system, shared, and normal. We just want the normal one. Unlike most COM methods that tell you their size when you call them
             * with an empty buffer, GetAppDomainList relies on you knowing the number of AppDomains that exist, which we can find out from DacpAppDomainStoreData.
             * For more information on the different types of AppDomains see https://docs.microsoft.com/en-us/archive/msdn-magazine/2005/may/net-framework-internals-how-the-clr-creates-runtime-objects */
            var appDomain = sosDacInterface.GetAppDomainList(numAppDomains).Single();

            var assemblies = sosDacInterface.GetAssemblyList(appDomain);

            ProcessAssemblies(assemblies);
        }

        private static void ProcessAssemblies(CLRDATA_ADDRESS[] assemblies)
        {
            var results = new List<ModuleInfoBuilder>();

            foreach (var assemblyAddress in assemblies)
            {
                string name;

                /* GetAssemblyName may sometimes randomly return E_FAIL; my guess is this could be a race condition possibly
                 * caused by the fact this sample does not "debug" the target process, thus it is still running while we're analyzing it */
                if (sosDacInterface.TryGetAssemblyName(assemblyAddress, out name) != HRESULT.S_OK)
                    name = assemblyAddress.ToString();
                else
                {
                    if (name.Contains(Path.DirectorySeparatorChar))
                        name = Path.GetFileName(name);
                }

                LogLevel = 0;
                Log($"Assembly: {name}");

                var location = sosDacInterface.GetAssemblyLocation(assemblyAddress);
                var modules = sosDacInterface.GetAssemblyModuleList(assemblyAddress);

                foreach (var moduleAddress in modules)
                {
                    var moduleInfoBuilder = new ModuleInfoBuilder(name, sosDacInterface, moduleAddress);

                    results.Add(moduleInfoBuilder);
                }
            }

            LogLevel = 0;
            Log("\nResults");
            LogLevel = 1;

            var maxLength = results.Select(r => r.AssemblyName.Length).Max();

            foreach (var result in results)
                Log(result.AssemblyName.PadRight(maxLength) + " | " + "Types: " + result.Types.Count, ConsoleColor.Cyan);
        }

        private static CLRDataCreateInstanceDelegate GetCLRDataCreateInstance()
        {
            /* We need to create a ClrDataAccess object (IXCLRDataProcess/ISOSDacInterface) from mscordacwks.dll.
             * This can be done by calling the mscordacwks!CLRDataCreateInstance method. We can't simply P/Invoke
             * this method however, as P/Invoke will search the global PATH for any and all mscordacwks.dll assemblies,
             * which is wrong. We need to load the specific mscordacwks.dll from the exact runtime version/bitness
             * we're executing under. */
            var mscordacwksPath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "mscordacwks.dll");

            var mscordacwks = NativeMethods.LoadLibrary(mscordacwksPath);

            if (mscordacwks == IntPtr.Zero)
                throw new InvalidOperationException($"Failed to load library '{mscordacwksPath}': {(HRESULT)Marshal.GetHRForLastWin32Error()}");

            var clrDataCreateInstancePtr = NativeMethods.GetProcAddress(mscordacwks, "CLRDataCreateInstance");

            if (clrDataCreateInstancePtr == IntPtr.Zero)
                throw new InvalidOperationException($"Failed to find function 'CLRDataCreateInstance': {(HRESULT)Marshal.GetHRForLastWin32Error()}");

            var clrDataCreateInstance = Marshal.GetDelegateForFunctionPointer<CLRDataCreateInstanceDelegate>(clrDataCreateInstancePtr);

            return clrDataCreateInstance;
        }

        #region Logging

        internal static int LogLevel;

        internal static void Log(string message, ConsoleColor? color = null)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < LogLevel; i++)
                builder.Append("    ");

            builder.Append(message);

            var original = Console.ForegroundColor;

            if (color != null)
                Console.ForegroundColor = color.Value;

            Console.WriteLine(builder.ToString());

            if (color != null)
                Console.ForegroundColor = original;
        }

        #endregion
    }
}
