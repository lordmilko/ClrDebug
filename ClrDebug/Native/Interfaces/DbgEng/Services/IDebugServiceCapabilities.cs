using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("729CF17B-E82F-4FF8-B27C-F13693971FE3")]
    [ComImport]
    public interface IDebugServiceCapabilities
    {
        [PreserveSig]
        HRESULT GetCapability(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid capabilitySet,
            [In] int capabilityId,
            [In] int bufferSize,
            [Out] IntPtr buffer);
    }
}
