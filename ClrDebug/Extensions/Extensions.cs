using System;
using System.IO;
using System.Runtime.InteropServices;
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
        [In] ref Guid iid,
        [MarshalAs(UnmanagedType.Interface), In] ICLRDataTarget target,
        [MarshalAs(UnmanagedType.Interface), Out] out object iface);

    public static partial class Extensions
    {
        private const string mscoree = "mscoree.dll";

        /// <summary>
        /// Caches the reference to mscordacwks retrieved in <see cref="CLRDataCreateInstance(ICLRDataTarget)"/>.
        /// </summary>
        private static IntPtr dacLib;

        public static readonly Guid CLSID_CLRMetaHost = new Guid("9280188D-0E8E-4867-B30C-7FA83884E8DE");
        public static readonly Guid CLSID_CLRMetaHostPolicy = new Guid("2EBCD49A-1B47-4A61-B13A-4A03701E594B");
        public static readonly Guid CLSID_CLRRuntimeHost = new Guid("90F1A06E-7712-4762-86B5-7A5EBA6BDB02");
        public static readonly Guid CLSID_CLRDebugging = new Guid("BACC578D-FBDD-48A4-969F-02D932B74634");
        public static readonly Guid CLSID_CLRDebuggingLegacy = new Guid("DF8395B5-A4BA-450b-A77C-A9A47762C520");
        public static readonly Guid CLSID_CLRStrongName = new Guid("B79B0ACD-F5CD-409B-B5A5-A16244610B92");
        public static readonly Guid CLSID_CorMetaDataDispenser = new Guid("E5CB7A31-7512-11d2-89CE-0080C792E5D8");
        public static readonly Guid CLSID_CorRuntimeHost = new Guid("CB2F6723-AB3A-11d2-9C40-00C04FA30A3E");
        public static readonly Guid CLSID_TypeNameFactory = new Guid("B81FF171-20F3-11d2-8DCC-00A0C9B00525");

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
            [In] ref Guid clsid,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppInterface);

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from <see cref="CLRCreateInstance(ref Guid, ref Guid, out object)"/>.<para/>
        /// If this method is called from an STA thread, an <see cref="InvalidOperationException"/> will be thrown, as the ICorDebug API does not support being used from STA threads.<para/>
        /// If you wish to bypass this check, please use the <see cref="CLRCreateInstance(ref Guid, ref Guid, out object)"/> method instead.
        /// </summary>
        /// <returns>The common interfaces that can be retrieved from <see cref="CLRCreateInstance(ref Guid, ref Guid, out object)"/>.</returns>
        /// <exception cref="InvalidOperationException">The current thread is a STA thread.</exception>
        public static CLRCreateInstanceInterfaces CLRCreateInstance()
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                throw new InvalidOperationException($"The ICorDebug API cannot be used from an STA thread. Please create a new thread and initialize ICorDebug from there. For more information, please see https://web.archive.org/web/20140422174916/http://blogs.msdn.com/b/jmstall/archive/2005/09/15/icordebug-mta-sta.aspx");

            return new CLRCreateInstanceInterfaces();
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.<para/>
        /// This method will automatically attempt to load mscordacwks.dll and retrieve the CLRDataCreateInstance function from it.<para/>
        /// If mscordacwks.dll is not the name of the DAC for your target runtime, create  you must retrieve a <see cref="CLRDataCreateInstanceDelegate"/> from the DAC
        /// yourself to be passed to the <see cref="CLRDataCreateInstance(CLRDataCreateInstanceDelegate, ICLRDataTarget)"/> method.
        /// </summary>
        /// <param name="target">A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
        /// <returns>The common interfaces that can be retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.</returns>
        public static CLRDataCreateInstanceInterfaces CLRDataCreateInstance(ICLRDataTarget target)
        {
            if (dacLib == IntPtr.Zero)
            {
                var mscordacwksPath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "mscordacwks.dll");

                dacLib = NativeMethods.LoadLibrary(mscordacwksPath);

                if (dacLib == IntPtr.Zero)
                    throw new InvalidOperationException($"Failed to load library '{mscordacwksPath}': {(HRESULT)Marshal.GetHRForLastWin32Error()}");
            }

            var clrDataCreateInstancePtr = NativeMethods.GetProcAddress(dacLib, "CLRDataCreateInstance");

            if (clrDataCreateInstancePtr == IntPtr.Zero)
                throw new InvalidOperationException($"Failed to find function 'CLRDataCreateInstance': {(HRESULT)Marshal.GetHRForLastWin32Error()}");

            var clrDataCreateInstance = Marshal.GetDelegateForFunctionPointer<CLRDataCreateInstanceDelegate>(clrDataCreateInstancePtr);

            return CLRDataCreateInstance(clrDataCreateInstance, target);
        }

        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.
        /// </summary>
        /// <param name="clrDataCreateInstance">A delegate of the CLRDataCreateInstance function, commonly found inside the target runtime's DAC DLL.</param>
        /// <param name="target">A pointer to a user-implemented <see cref="ICLRDataTarget"/> object that represents the target item for which to create the interface object.</param>
        /// <returns>The common interfaces that can be retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.</returns>
        public static CLRDataCreateInstanceInterfaces CLRDataCreateInstance(CLRDataCreateInstanceDelegate clrDataCreateInstance, ICLRDataTarget target) =>
            new CLRDataCreateInstanceInterfaces(clrDataCreateInstance, target);

        private static IntPtr AllocAndInitContext<T>(int size, ContextFlags contextFlags)
        {
            var buffer = Marshal.AllocHGlobal(size);

            //Most context structs (X86, ARM, ARM64) specify their ContextFlags member at offset 0.
            //AMD64 however has a bunch of home members in front
            if (typeof(T) == typeof(AMD64_CONTEXT))
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
    }
}
