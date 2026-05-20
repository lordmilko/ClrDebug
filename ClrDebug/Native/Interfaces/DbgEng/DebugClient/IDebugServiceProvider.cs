using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58034A5B-F616-47C5-B5D5-B1390E0F0B23")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugServiceProvider
    {
        [PreserveSig]
        HRESULT QueryService(
            [In] long server,
#if !GENERATED_MARSHALLING
            [MarshalAs(UnmanagedType.LPStruct), In]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceId,
#if !GENERATED_MARSHALLING
            [MarshalAs(UnmanagedType.LPStruct), In]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceInterfaceId,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugService @interface);
    }
}
