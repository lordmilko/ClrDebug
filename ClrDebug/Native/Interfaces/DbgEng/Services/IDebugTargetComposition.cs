using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6D4E5F39-657E-4905-9670-448978F7FB27")]
    [ComImport]
    public interface IDebugTargetComposition
    {
        [PreserveSig]
        HRESULT CreateServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager serviceManager);
        
        [PreserveSig]
        HRESULT RegisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        HRESULT CreateComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        HRESULT CreateAndQueryComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);
        
        [PreserveSig]
        HRESULT UnregisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
    }
}
