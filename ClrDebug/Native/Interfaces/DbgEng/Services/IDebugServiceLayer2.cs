using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("12954378-FAFD-4749-ADD8-7A98A5A4B896")]
    [ComImport]
    public interface IDebugServiceLayer2 : IDebugServiceLayer
    {
        [PreserveSig]
        new HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);
        
        [PreserveSig]
        new HRESULT GetServiceDependencies(
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
        new HRESULT InitializeServices(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid);
        
        [PreserveSig]
        new HRESULT NotifyServiceChange(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer priorService,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newService);
        
        [PreserveSig]
        new HRESULT NotifyEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument);
        
        [PreserveSig]
        HRESULT RegisterConditionalServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);
    }
}
