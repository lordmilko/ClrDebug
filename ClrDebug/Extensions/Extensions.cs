using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Threading;

namespace ClrDebug
{
    /// <summary>
    /// Creates an interface object for the specified target item.
    /// </summary>
    /// <param name="iid">[in] The identifier of the interface to be instantiated.</param>
    /// <param name="target">[in] A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
    /// <param name="iface">[out] A pointer to the address of the returned interface object.</param>
    /// <returns>A HRESULT that indicates success or failure.</returns>
    /// <remarks>
    /// The <see cref="ICLRDataTarget"/> object is implemented by the writer of the debugging application. The implementation depends on
    /// the type of target item being represented. The target item may be a process, memory dump, remote machine, and so on.
    /// </remarks>
    public delegate HRESULT CLRDataCreateInstanceDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid iid,
        [In, MarshalAs(UnmanagedType.Interface)] ICLRDataTarget target,
        [MarshalAs(UnmanagedType.Interface), Out] out object iface);

    public delegate HRESULT MetaDataGetDispenserDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
        [MarshalAs(UnmanagedType.Interface), Out] out object ppv);

    public static partial class Extensions
    {
        public const int DAC_NUM_GC_DATA_POINTS = 9;
        public const int DAC_MAX_COMPACT_REASONS_COUNT = 11;
        public const int DAC_MAX_EXPAND_MECHANISMS_COUNT = 6;
        public const int DAC_MAX_GC_MECHANISM_BITS_COUNT = 2;
        public const int DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT = 6;

        public const int DAC_NUMBERGENERATIONS = 4;

        private const string mscoree = "mscoree.dll";

        /// <summary>
        /// Caches the reference to mscordacwks retrieved in <see cref="CLRDataCreateInstance(ICLRDataTarget)"/>.
        /// </summary>
        private static IntPtr dacLib;

        public static readonly Guid CLSID_CLR_v2_MetaData = new Guid("EFEA471A-44FD-4862-9292-0C58D46E1F3A");
        public static readonly Guid CLSID_CLRMetaHost = new Guid("9280188D-0E8E-4867-B30C-7FA83884E8DE");
        public static readonly Guid CLSID_CLRMetaHostPolicy = new Guid("2EBCD49A-1B47-4A61-B13A-4A03701E594B");
        public static readonly Guid CLSID_CLRRuntimeHost = new Guid("90F1A06E-7712-4762-86B5-7A5EBA6BDB02");
        public static readonly Guid CLSID_CLRDebugging = new Guid("BACC578D-FBDD-48A4-969F-02D932B74634");
        public static readonly Guid CLSID_CLRDebuggingLegacy = new Guid("DF8395B5-A4BA-450b-A77C-A9A47762C520");
        public static readonly Guid CLSID_CLRStrongName = new Guid("B79B0ACD-F5CD-409B-B5A5-A16244610B92");
        public static readonly Guid CLSID_CorMetaDataDispenser = new Guid("E5CB7A31-7512-11d2-89CE-0080C792E5D8");
        public static readonly Guid CLSID_CorMetaDataRuntime = CLSID_CLR_v2_MetaData;
        public static readonly Guid CLSID_CorRuntimeHost = new Guid("CB2F6723-AB3A-11d2-9C40-00C04FA30A3E");
        public static readonly Guid CLSID_TypeNameFactory = new Guid("B81FF171-20F3-11d2-8DCC-00A0C9B00525");

        private const string ClrLibDesktop = "clr.dll";
        private const string ClrLibWinCore = "coreclr.dll";
        private const string ClrLibLinuxCore = "libcoreclr.so";
        private const string ClrLibMacCore = "libcoreclr.dylib";

        private const string DacLibDesktop = "mscordacwks.dll";
        private const string DacLibWinCore = "mscordaccore.dll";
        private const string DacLibLinuxCore = "libmscordaccore.so";
        private const string DacLibMacCore = "libmscordaccore.dylib";

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
#if !GENERATED_MARSHALLING
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
#if !GENERATED_MARSHALLING
            var result = NativeMethods.GetProcAddress(handle, name);

            if (result != IntPtr.Zero)
                return result;

            throw new EntryPointNotFoundException($"Unable to find entry point named '{name}' in DLL: {(HRESULT)Marshal.GetHRForLastWin32Error()}");
#else
            return NativeLibrary.GetExport(handle, name);
#endif
        }

        #region CLRCreateInstance

        /// <summary>
        /// Provides one of three interfaces: <see cref="ICLRMetaHost"/>, <see cref="ICLRMetaHostPolicy"/> or <see cref="ICLRDebugging"/>.
        /// </summary>
        /// <param name="clsid">[in] One of three class identifiers: <see cref="CLSID_CLRMetaHost"/>, <see cref="CLSID_CLRMetaHostPolicy"/> or <see cref="CLSID_CLRDebugging"/>.</param>
        /// <param name="riid">[in] One of three interface identifiers (IIDs): IID_ICLRMetaHost, IID_ICLRMetaHostPolicy, or IID_ICLRDebugging.</param>
        /// <param name="ppInterface">[out] One of three interfaces: <see cref="ICLRMetaHost"/>, <see cref="ICLRMetaHostPolicy"/>, or <see cref="ICLRDebugging"/>.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        [DllImport(mscoree)]
        public static extern HRESULT CLRCreateInstance(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid clsid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppInterface);

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRCreateInstance(Guid, Guid, out object)"/>.<para/>
        /// This method is only supported on Windows.
        /// </summary>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRCreateInstance(Guid, Guid, out object)"/>.</returns>
        public static CLRCreateInstanceInterfaces CLRCreateInstance() => new CLRCreateInstanceInterfaces();

        #endregion
        #region CLRDataCreateInstance

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.<para/>
        /// This method will automatically attempt to load your runtime's DAC library and retrieve the CLRDataCreateInstance function from it.<para/>
        /// If this method is unable to locate the DAC library for your target runtime, you must retrieve a <see cref="CLRDataCreateInstanceDelegate"/> from the DAC
        /// yourself to be passed to the <see cref="CLRDataCreateInstance(CLRDataCreateInstanceDelegate, ICLRDataTarget)"/> method.
        /// </summary>
        /// <param name="target">A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
        /// <returns>The common interfaces that can be retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.</returns>
        public static CLRDataCreateInstanceInterfaces CLRDataCreateInstance(ICLRDataTarget target)
        {
            if (dacLib == IntPtr.Zero)
            {
                var dacPath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), GetDacLibPath());

                dacLib = LoadLibrary(dacPath);
            }

            var clrDataCreateInstance = new DelegateProvider(dacLib).CLRDataCreateInstance;

            return CLRDataCreateInstance(clrDataCreateInstance, target);
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.<para/>
        /// This method will automatically attempt to load your runtime's DAC library and retrieve the CLRDataCreateInstance function from it.<para/>
        /// If this method is unable to locate the DAC library for your target runtime, you must retrieve a <see cref="CLRDataCreateInstanceDelegate"/> from the DAC
        /// yourself to be passed to the <see cref="CLRDataCreateInstance(CLRDataCreateInstanceDelegate, ICLRDataTarget)"/> method.
        /// </summary>
        /// <param name="hModule">A handle to the DAC library that has been loaded into the current process.</param>
        /// <param name="target">A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
        /// <returns>The common interfaces that can be retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.</returns>
        public static CLRDataCreateInstanceInterfaces CLRDataCreateInstance(IntPtr hModule, ICLRDataTarget target)
        {
            var clrDataCreateInstance = new DelegateProvider(hModule).CLRDataCreateInstance;

            return CLRDataCreateInstance(clrDataCreateInstance, target);
        }

        private static string GetDacLibPath()
        {
            string dacLib;

#if !GENERATED_MARSHALLING
                if (RuntimeInformation.FrameworkDescription == null || RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework"))
                    dacLib = DacLibDesktop;
                else
                    dacLib = DacLibWinCore;
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                dacLib = DacLibWinCore;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                dacLib = DacLibLinuxCore;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                dacLib = DacLibMacCore;
            else
                throw new NotSupportedException($"Could not determine DAC library to use for operating system '{RuntimeInformation.OSDescription}'.");
#endif

            return dacLib;
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.
        /// </summary>
        /// <param name="clrDataCreateInstance">A delegate of the CLRDataCreateInstance function, commonly found inside the target runtime's DAC DLL.</param>
        /// <param name="target">A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
        /// <returns>The common interfaces that can be retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.</returns>
        public static CLRDataCreateInstanceInterfaces CLRDataCreateInstance(CLRDataCreateInstanceDelegate clrDataCreateInstance, ICLRDataTarget target) =>
            new CLRDataCreateInstanceInterfaces(clrDataCreateInstance, target);

        #endregion
        #region MetaDataGetDispenser

        internal static IMetaDataDispenserEx MetaDataGetDispenser()
        {
            var hModule = GetClrModuleHandle();

            return MetaDataGetDispenser(hModule);
        }

        internal static IMetaDataDispenserEx MetaDataGetDispenser(IntPtr hModule)
        {
            var @delegate = new DelegateProvider(hModule).MetaDataGetDispenser;

            @delegate(CLSID_CorMetaDataDispenser, typeof(IMetaDataDispenserEx).GUID, out var ppv).ThrowOnNotOK();

            return (IMetaDataDispenserEx)ppv;
        }

        private static IntPtr GetClrModuleHandle()
        {
#if GENERATED_MARSHALLING
            string clrDll;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                clrDll = ClrLibWinCore;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                clrDll = ClrLibLinuxCore;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                clrDll = ClrLibMacCore;
            else
                throw new NotSupportedException($"Could not determine CLR library to use for operating system '{RuntimeInformation.OSDescription}'.");

            var modules = Process.GetCurrentProcess().Modules;

            var match = modules.Cast<ProcessModule>().FirstOrDefault(m => clrDll.Equals(m.ModuleName, StringComparison.OrdinalIgnoreCase));

            if (match != null)
                return match.BaseAddress;
#else
            IntPtr hModule;
            var result = NativeMethods.GetModuleHandleExW(GetModuleHandleExFlag.UnchangedRefCount, ClrLibDesktop, out hModule);

            if (result)
                return hModule;

            result = NativeMethods.GetModuleHandleExW(GetModuleHandleExFlag.UnchangedRefCount, ClrLibWinCore, out hModule);

            if (result)
                return hModule;
#endif
            throw new InvalidOperationException("Failed to locate a CLR module within the current process.");
        }

        #endregion

        private static IntPtr AllocAndInitContext<T>(int size, ContextFlags contextFlags)
        {
            var buffer = Marshal.AllocHGlobal(size);

            //Most context structs (X86, ARM, ARM64) specify their ContextFlags member at offset 0.
            //AMD64 however has a bunch of home members in front
            if (typeof(T) == typeof(CROSS_PLATFORM_CONTEXT) && contextFlags >= ContextFlags.AMD64Context && contextFlags <= ContextFlags.AMD64ContextAll)
            {
                var ctx = new CROSS_PLATFORM_CONTEXT
                {
                    Amd64Context = new AMD64_CONTEXT
                    {
                        ContextFlags = contextFlags
                    }
                };

                Marshal.StructureToPtr(ctx, buffer, false);
            }
            else if (typeof(T) == typeof(AMD64_CONTEXT))
            {
                var ctx = new AMD64_CONTEXT
                {
                    ContextFlags = contextFlags
                };

                Marshal.StructureToPtr(ctx, buffer, false);
            }
            else
            {
                Marshal.WriteInt32(buffer, (int)contextFlags);
            }

            return buffer;
        }

        /// <summary>
        /// Creates a <see langword="string"/> from a null-terminated sequence of characters of unknown length.
        /// </summary>
        /// <param name="charArray">The null-terminated sequence of characters.</param>
        /// <returns>A <see langword="string"/> containing the characters in <paramref name="charArray"/> prior to the null-terminator (\0), or <see cref="string.Empty"/> if <paramref name="charArray"/> is empty,
        /// or <see langword="null"/> if <paramref name="charArray"/> is <see langword="null"/></returns>
        public static string CreateString(char[] charArray)
        {
            if (charArray == null)
                return null;

            var length = 0;

            for (; length < charArray.Length; length++)
            {
                if (charArray[length] == '\0')
                    break;
            }

            return new string(charArray, 0, length);
        }

        /// <summary>
        /// Creates a <see langword="string"/> from a null-terminated sequence of characters of known length.
        /// </summary>
        /// <param name="charArray">The null-terminated sequence of characters.</param>
        /// <param name="length">The number of characters that were filled in in <paramref name="charArray"/> including a null-terminator (\0).</param>
        /// <returns>A <see langword="string"/> containing the characters in <paramref name="charArray"/> prior to the null-terminator (\0), or <see cref="string.Empty"/> if <paramref name="charArray"/> is empty,
        /// or <see langword="null"/> if <paramref name="charArray"/> is <see langword="null"/></returns>
        public static string CreateString(char[] charArray, int length)
        {
            if (charArray == null)
                return null;

            //The length will include a null terminator. So if there's no characters, or just a null terminator, it's an empty string
            if (length <= 1 || charArray.Length == 0)
                return string.Empty;

            //ISOSDacInterface::GetMethodDescName() can respond "System.Action`2.Invoke(!0, !0)" the first time you query the method for the length, and "System.Action`2.Invoke(!56001, !0)"
            //the second time you query it for the exact same method. As such, if we're given a bogus length, fallback to the slow path and consume as much of the charArray as possible (excluding
            //any null-terminator)
            if (length > charArray.Length)
                return CreateString(charArray);

            return new string(charArray, 0, length - 1);
        }

        /// <summary>
        /// Retrieves an RCW for a given COM interface pointer cast to a specific interface type.<para/>
        /// When a targeting a framework where source generated COM is being used, this method creates an RCW via a StrategyBasedComWrappers instance.
        /// Otherwise, retrieves an RCW via the CLR's built in COM interop marshaller.
        /// </summary>
        /// <typeparam name="T">The type of interface to retrieve.</typeparam>
        /// <param name="pUnk">The COM interface pointer to retrieve an RCW for.</param>
        /// <returns>A COM interface pointer cast to interface type <typeparamref name="T"/>.</returns>
        public static T GetObjectForIUnknown<T>(IntPtr pUnk) => (T) GetObjectForIUnknown(pUnk);

        /// <summary>
        /// Retrieves an RCW for a given COM interface pointer.<para/>
        /// When a targeting a framework where source generated COM is being used, this method creates an RCW via a StrategyBasedComWrappers instance.
        /// Otherwise, retrieves an RCW via the CLR's built in COM interop marshaller.
        /// </summary>
        /// <param name="pUnk">The COM interface pointer to retrieve an RCW for.</param>
        /// <returns>An RCW that encapsulates the specified interface pointer.</returns>
        public static object GetObjectForIUnknown(IntPtr pUnk)
        {
#if GENERATED_MARSHALLING
            return DefaultMarshallingInstance.GetOrCreateObjectForComInstance(pUnk, CreateObjectFlags.None);
#else
            return Marshal.GetObjectForIUnknown(pUnk);
#endif
        }

        /// <summary>
        /// Retrieves an IUnknown CCW for a given managed object.<para/>
        /// When a targeting a framework where source generated COM is being used, this method creates an IUnknown CCW via a StrategyBasedComWrappers instance.
        /// Otherwise, retrieves an IUnknown CCW via the CLR's built in COM interop marshaller.<para/>
        /// Note that when source generated COM is being used, if the type of <paramref name="o"/> is a <see langword="class"/>,
        /// the class MUST be decorated with GeneratedComClassAttribute, otherwise ComWrappers won't know what interfaces the type implements.<para/>
        /// If an IUnknown pointer is passed to an unmanaged method expecting an interface type other than IUnknown, that method may fail if it does not
        /// defensively QueryInterface your pointer to the interface type it was expecting. To retrieve a pointer for a specific interface type, see <see cref="GetInterfaceForObject{T}(object)"/>.
        /// </summary>
        /// <param name="o">The managed object to retrieve a CCW for.</param>
        /// <returns>An IUnknown interface pointer for the managed object that can be passed to unmanaged code.</returns>
        public static IntPtr GetIUnknownForObject(object o)
        {
#if GENERATED_MARSHALLING
            return DefaultMarshallingInstance.GetOrCreateComInterfaceForObject(o, CreateComInterfaceFlags.None);
#else
            return Marshal.GetIUnknownForObject(o);
#endif
        }

        /// <summary>
        /// Retrieves a CCW of a specific interface type for a given managed object.
        /// </summary>
        /// <typeparam name="T">The type of CCW to create.</typeparam>
        /// <param name="o">The managed object to retrieve a CCW for.</param>
        /// <returns>An interface pointer of the specified type that can be passed to unmanaged code.</returns>
        public static IntPtr GetInterfaceForObject<T>(object o)
        {
            var pUnk = GetIUnknownForObject(o);

            //The CLR's ComInterfaceMarshaller will call Release if the QueryInterface fails. I don't understand this;
            //QueryInterface will only increment the reference count on success!
            //https://github.com/dotnet/runtime/blob/main/src/libraries/System.Runtime.InteropServices/src/System/Runtime/InteropServices/Marshalling/ComInterfaceMarshaller.cs#L72C33-L72C33

            var iid = typeof(T).GUID;
            var hr = (HRESULT) Marshal.QueryInterface(pUnk, ref iid, out var ppv);

#if GENERATED_MARSHALLING
            if (hr == HRESULT.E_NOINTERFACE && !(o is ComObject))
                throw new DebugException($"Failed to query interface type '{typeof(T).FullName}' from type '{o.GetType().FullName}'. Confirm that the implementing class both derives from the interface and is decorated with '{nameof(GeneratedComClassAttribute)}'", hr);
#endif
            hr.ThrowOnNotOK();

            /* QueryInterface will increment the reference count. Because we're returning a pointer from this method,
             * there isn't going to be an RCW to decrement the reference count we increased - we must be the one to do it.
             * The purpose of this method is merely to "cast" to the desired interface vtable. The caller already has a reference
             * to the COM object, and must continue to maintain it after they've done what they need to with the pointer returned
             * from this method */
            Marshal.Release(pUnk);

            return ppv;
        }
    }
}
