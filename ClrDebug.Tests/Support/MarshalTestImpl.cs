using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using ClrDebug.DIA;
using static ClrDebug.Extensions;
using DbgShimResolver = NetCore.DbgShimResolver;

namespace ClrDebug.Tests
{
    class MarshalTestImpl
    {
        private static SymbolClient symbolClient;

        static MarshalTestImpl()
        {
            var localStore = Path.Combine(Environment.GetEnvironmentVariable("temp"), "symbols");
            var ntSymbolPath = $"srv*{localStore}*http://msdl.microsoft.com/download/symbols";
            Environment.SetEnvironmentVariable("_NT_SYMBOL_PATH", ntSymbolPath);
            symbolClient = new SymbolClient();
        }

        private static ConcurrentDictionary<string, IntPtr> moduleCache = new ConcurrentDictionary<string, IntPtr>();

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

        internal static void FreeLibrary(IntPtr hModule)
        {
#if !NET8_0_OR_GREATER
            NativeMethods.FreeLibrary(hModule);
#else
            NativeLibrary.Free(hModule);
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

        #region DIA

        internal static bool Marshal_Dia_String_DiaSource(string dll) => TestDIA(CLSID_DiaSource, comHeap: true, array: false, dll);

        internal static bool Marshal_Dia_String_DiaSourceAlt(string dll) => TestDIA(CLSID_DiaSourceAlt, comHeap: false, array: false, dll);

        internal static bool Marshal_Dia_String_DbgHelp(string dll) => TestDIA(null, comHeap: false, array: false, dll);

        internal static bool Marshal_Dia_StringArray_DiaSource(string dll) => TestDIA(CLSID_DiaSource, comHeap: true, array: true, dll);

        internal static bool Marshal_Dia_StringArray_DiaSourceAlt(string dll) => TestDIA(CLSID_DiaSourceAlt, comHeap: false, array: true, dll);

        internal static bool Marshal_Dia_StringArray_DbgHelp(string dll) => TestDIA(null, comHeap: false, array: true, dll);

        internal static unsafe bool TestDIA(Guid? clsid, bool? comHeap, bool array, string dll)
        {
            if (comHeap != null)
                DiaStringsUseComHeap = comHeap.Value;

            bool isDbgHelp = clsid == null;

            var fileName = isDbgHelp ? "dbghelp.dll" : "msdia140.dll";

            string LocateDll(string name)
            {
                var appDir = AppContext.BaseDirectory;

                //TestApp (non-NativeAOT) will have the file in the output directory
                var runtimeDll = Path.Combine(appDir, name);

                if (File.Exists(runtimeDll))
                    return runtimeDll;

                return Path.Combine(AppContext.BaseDirectory, "runtimes", IntPtr.Size == 4 ? "win-x86" : "win-x64", "native", name);
            }

            if (dll == null)
                dll = LocateDll(fileName);

            var hModule = moduleCache.GetOrAdd(dll, v =>
            {
                if (NativeMethods.GetModuleHandleW(fileName) != IntPtr.Zero)
                    throw new InvalidOperationException($"Module {fileName} was already loaded");

                return LoadLibrary(v);
            });

            var expectedName = IntPtr.Size == 4 ? "wntdll" : "ntdll";

            try
            {
                if (isDbgHelp)
                    return TestDiaDbgHelp(array, expectedName);
                else
                    return TestDiaNormal(hModule, clsid, array, expectedName);
            }
            finally
            {
                //All of the DIA objects should now be out of scope. Force a GC. We observed that without wrapping all the DIA objects up in an inner function, we'd sometimes crash while waiting for pending finalizers
                //clr!RCWCleanupList::ReleaseRCWListInCorrectCtx results in some RPC calls being made in the finalizer thread, and then
                //next thing we know on our thread here we're calling LocalFree on some unknown object and throwing
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private static unsafe bool TestDiaDbgHelp(bool array, string expectedName)
        {
            var hProcess = Process.GetCurrentProcess().Handle;

            try
            {
                if (!NativeMethods.SymInitializeW(hProcess, null, false))
                    throw new InvalidOperationException($"SymInitialize failed: {(HRESULT) Marshal.GetHRForLastWin32Error()}");

                var ntdll = Process.GetCurrentProcess().Modules.Cast<ProcessModule>().Single(m => m.ModuleName == "ntdll.dll");

                if (NativeMethods.SymLoadModuleExW(hProcess, ImageName: ntdll.FileName, BaseOfDll: (ulong) (void*) ntdll.BaseAddress) == 0)
                    throw new InvalidOperationException($"SymLoadModuleExW failed: {(HRESULT) Marshal.GetHRForLastWin32Error()}");

                //This is a big gotcha: you MUST create any interfaces you want to use with source generated COM via a StrategyBasedComWrappers instance.
                //If you let the CLR try and do default marshalling on a PInvoke, you're going to get a regular old System.__ComObject which won't utilize
                //our source generated COM interfaces (unless of course you globally register a ComWrappers instance)

                if (!NativeMethods.SymGetDiaSession(hProcess, (long) (void*) ntdll.BaseAddress, out var rawSession))
                    throw new InvalidOperationException($"SymGetDiaSession failed: {(HRESULT) Marshal.GetHRForLastWin32Error()}");

                var diaSession = new DiaSession(GetObjectForIUnknown<IDiaSession>(rawSession));
                var globalScope = diaSession.GlobalScope;

                if (array)
                    return TestDiaArray(globalScope);
                else
                    return expectedName == globalScope.Name;
            }
            finally
            {
                NativeMethods.SymCleanup(hProcess);
            }
        }

        private static unsafe bool TestDiaNormal(IntPtr hModule, Guid? clsid, bool array, string expectedName)
        {
            var pdb = symbolClient.GetPdb("C:\\Windows\\system32\\ntdll.dll");

            var pDllGetClassObject = GetExport(hModule, "DllGetClassObject");

            IntPtr pClassFactory = IntPtr.Zero;
#if NET8_0_OR_GREATER
            var fn = (delegate* unmanaged<GuidMarshaller.GuidNative*, GuidMarshaller.GuidNative*, IntPtr*, HRESULT>) pDllGetClassObject;

            var localClsid = GuidMarshaller.ConvertToUnmanaged(clsid.Value);
            var localRiid = GuidMarshaller.ConvertToUnmanaged(typeof(IClassFactory).GUID);

            //todo: evidently this is wrong, because its crashing our normal .net 8 test
            fn(&localClsid, &localRiid, &pClassFactory).ThrowOnNotOK();
#else
            var dllGetClassObject = Marshal.GetDelegateForFunctionPointer<DllGetClassObjectDelegate>(pDllGetClassObject);

            dllGetClassObject(clsid.Value, typeof(IClassFactory).GUID, out pClassFactory);
#endif
            var classFactory = GetObjectForIUnknown<IClassFactory>(pClassFactory);
            classFactory.CreateInstance(null, typeof(IDiaDataSource).GUID, out var ppvObject).ThrowOnNotOK();

            var dataSource = new DiaDataSource((IDiaDataSource) ppvObject);

            dataSource.LoadDataFromPdb(pdb);

            var session = dataSource.OpenSession();
            var globalScope = session.GlobalScope;

            var name = globalScope.Name;

            if (array)
                return TestDiaArray(globalScope);
            else
                return expectedName == name;
        }

        private static bool TestDiaArray(DiaSymbol globalScope)
        {
            var properties = globalScope.As<DiaPropertyStorage>();

            //STATPROPSTG also has issues, so we need to test this too
            var items = properties.Items.Take(3).ToArray();

            var names = properties.ReadPropertyNames(0, 1);

            for (var i = 0; i < names.Length; i++)
            {
                if (items[i].lpwstrName != names[i])
                    return false;
            }

            //Do it again to make sure we reset all state in our custom marshaller
            names = properties.ReadPropertyNames(0, 1, 2);

            for (var i = 0; i < names.Length; i++)
            {
                if (items[i].lpwstrName != names[i])
                    return false;
            }

            return true;
        }

        #endregion
    }
}
