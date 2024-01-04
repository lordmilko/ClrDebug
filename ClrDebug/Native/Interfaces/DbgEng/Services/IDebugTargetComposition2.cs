using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("66403806-4988-4A0A-A552-F14B1B5E33D5")]
    [ComImport]
    public interface IDebugTargetComposition2 : IDebugTargetComposition
    {
        [PreserveSig]
        new HRESULT CreateServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager serviceManager);
        
        [PreserveSig]
        new HRESULT RegisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        new HRESULT CreateComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        new HRESULT CreateAndQueryComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);
        
        [PreserveSig]
        new HRESULT UnregisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);
        
        [PreserveSig]
        HRESULT RegisterComponentAsConditionalService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo);
        
        [PreserveSig]
        HRESULT CreateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
        
        [PreserveSig]
        HRESULT CreateAndQueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);
    }
}
