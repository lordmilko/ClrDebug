using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using NetCore;
using static ClrDebug.Extensions;

namespace ClrDebug.Tests
{
    class MarshalTestImpl
    {
        /// <summary>
        /// Loads a native library.<para/>
        /// This method is compatible with both .NET Framework and .NET Core.
        /// </summary>
        /// <param name="path">The name of the native library to be loaded.</param>
        /// <returns>The handle for the loaded native library.</returns>
        /// <exception cref="ArgumentNullException">If libraryPath is null</exception>
        /// <exception cref="DllNotFoundException ">If the library can't be found.</exception>
        /// <exception cref="BadImageFormatException">If the library is not valid.</exception>
        internal static IntPtr LoadLibrary(string path)
        {
#if !NET8_0_OR_GREATER
            var hModule = NativeMethods.LoadLibrary(path);

            if (hModule != IntPtr.Zero)
                return hModule;

            var hr = (HRESULT) Marshal.GetHRForLastWin32Error();

            if (hr == HRESULT.ERROR_BAD_EXE_FORMAT)
                throw new BadImageFormatException($"Failed to load module '{path}'. Module may target an architecture different from the current process.");

            var ex = Marshal.GetExceptionForHR((int) hr);

            throw new DllNotFoundException($"Unable to load DLL '{path}' or one of its dependencies: {ex.Message}");
#else
            return NativeLibrary.Load(path);
#endif
        }

        /// <summary>
        /// Gets the address of an exported symbol.<para/>
        /// This method is compatible with both .NET Framework and .NET Core.
        /// </summary>
        /// <param name="handle">The native library handle.</param>
        /// <param name="name">The name of the exported symbol.</param>
        /// <returns>The address of the symbol.</returns>
        /// <exception cref="ArgumentNullException">If handle or name is null</exception>
        /// <exception cref="EntryPointNotFoundException">If the symbol is not found</exception>
        internal static IntPtr GetExport(IntPtr handle, string name)
        {
#if !NET8_0_OR_GREATER
            var result = NativeMethods.GetProcAddress(handle, name);

            if (result != IntPtr.Zero)
                return result;

            throw new EntryPointNotFoundException($"Unable to find entry point named '{name}' in DLL: {(HRESULT)Marshal.GetHRForLastWin32Error()}");
#else
            return NativeLibrary.GetExport(handle, name);
#endif
        }

        internal static bool Marshal_Delegate_Call(Process process, IntPtr? hModule = null)
        {
            var dataTarget = new DataTarget(process);

            var sos = (hModule == null ? CLRDataCreateInstance(dataTarget) : CLRDataCreateInstance(hModule.Value, dataTarget)).SOSDacInterface;

            return sos.AppDomainStoreData.DomainCount > 0;
        }

        internal static bool Marshal_Delegate_Call_WithOutInterface()
        {
            var metaHost = CLRCreateInstance().CLRMetaHost;
            var enumerator = metaHost.EnumerateInstalledRuntimes();
            return enumerator != null;
        }

        internal static bool Marshal_Delegate_Call_WithInInterface(string appPath, string dbgShimPath = null)
        {
            dbgShimPath = dbgShimPath ?? DbgShimResolver.Resolve();

            var hModule = LoadLibrary(dbgShimPath);

            var dbgShim = new DbgShim(hModule);

            var processInfo = dbgShim.CreateProcessForLaunch(appPath, true);
            var process = Process.GetProcessById(processInfo.ProcessId);

            try
            {
                var startupEvent = dbgShim.GetStartupNotificationEvent(processInfo.ProcessId);

                dbgShim.ResumeProcess(processInfo.ResumeHandle);

                //Don't know how to WaitForSingleObject cross-platform, so just wait 1 second
                Thread.Sleep(1000);

                var runtime = dbgShim.EnumerateCLRs(processInfo.ProcessId).Items.Single();

                var versionStr = dbgShim.CreateVersionStringFromModule(processInfo.ProcessId, runtime.Path);

                var libraryProvider = new LibraryProvider();

                var hr = dbgShim.TryCreateDebuggingInterfaceFromVersion3(CorDebugInterfaceVersion.CorDebugVersion_4_0, versionStr, null, libraryProvider, out _);

                if (hr != HRESULT.CORDBG_E_DEBUG_COMPONENT_MISSING)
                    hr.ThrowOnNotOK();

                return libraryProvider.Called;
            }
            finally
            {
                dbgShim.CloseResumeHandle(processInfo.ResumeHandle);

                try
                {
                    if (!process.HasExited)
                        process.Kill();
                }
                catch
                {
                    //Don't care
                }
            }
        }

#if !NET8_0_OR_GREATER
        internal static void Marshal_CoClass_Call()
        {
            var dispenser = new ClrDebug.CoClass.CorMetaDataDispenser();

            var path = typeof(MarshalTestImpl).Assembly.Location;
            dispenser.OpenScope(path, CorOpenFlags.ofReadOnly, typeof(IMetaDataImport).GUID, out var unk);
        }
#endif

        internal static bool Marshal_MetaDataDispenser_Call(string path, IntPtr? hModule = null)
        {
            path = Path.ChangeExtension(path, "dll");

            var dispenser = hModule != null ? new MetaDataDispenserEx(hModule.Value) : new MetaDataDispenserEx();

            //It seems you might not be able to specify an EXE to this
            var mdi = dispenser.OpenScope<MetaDataImport>(path, CorOpenFlags.ofReadOnly);
            var types = mdi.EnumTypeDefs();

            return types.Length > 0;
        }
    }
}
