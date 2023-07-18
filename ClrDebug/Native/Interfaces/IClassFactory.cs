using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IClassFactory
    {
        [PreserveSig]
        HRESULT CreateInstance(
            [MarshalAs(UnmanagedType.Interface), In] object pUnkOuter,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppvObject);

        [PreserveSig]
        HRESULT LockServer(
            [In, MarshalAs(UnmanagedType.Bool)] bool fLock);
    }
}
