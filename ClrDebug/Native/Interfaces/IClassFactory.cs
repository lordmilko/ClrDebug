using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IClassFactory
    {
        [PreserveSig]
        HRESULT CreateInstance(
            [MarshalAs(UnmanagedType.IUnknown), In] object pUnkOuter,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown), Out] out object ppvObject);

        [PreserveSig]
        HRESULT LockServer(
            [In, MarshalAs(UnmanagedType.Bool)] bool fLock);
    }
}
