using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58034A5B-F616-47C5-B5D5-B1390E0F0B23")]
    [ComImport]
    public interface IDebugServiceProvider
    {
        [PreserveSig]
        HRESULT QueryService(
            [In] long server,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceId,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceInterfaceId,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugService @interface);
    }
}
