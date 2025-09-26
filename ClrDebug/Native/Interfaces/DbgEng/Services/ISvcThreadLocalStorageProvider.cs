using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58EE46F3-209E-4402-8452-C3797D5C3355")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcThreadLocalStorageProvider
    {
        /// <summary>
        /// Returns the base address of a module's TLS block for a given thread.
        /// </summary>
        [PreserveSig]
        HRESULT GetTLSBlockAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread pThread,
            [Out] out long pAddress);
    }
}
