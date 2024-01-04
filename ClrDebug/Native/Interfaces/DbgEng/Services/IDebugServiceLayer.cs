using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6BF32043-E2A9-462D-99B1-B2E6C15252A2")]
    [ComImport]
    public interface IDebugServiceLayer
    {
        [PreserveSig]
        HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);
        
        [PreserveSig]
        HRESULT GetServiceDependencies(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In] long sizeHardDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[] pHardDependencies,
            [Out] out long pNumHardDependencies,
            [In] long sizeSoftDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] Guid[] pSoftDependencies,
            [Out] out long pNumSoftDependencies);
        
        [PreserveSig]
        HRESULT InitializeServices(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid);
        
        [PreserveSig]
        HRESULT NotifyServiceChange(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer priorService,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newService);
        
        [PreserveSig]
        HRESULT NotifyEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument);
    }
}
