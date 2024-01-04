using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("84069FCD-E8B0-48E5-8611-7F0A8FA130D2")]
    [ComImport]
    public interface IDebugServiceManager4 : IDebugServiceManager3
    {
        [PreserveSig]
        new HRESULT UninitializeServices();
        
        [PreserveSig]
        new HRESULT EnumerateServices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT InitializeServices();
        
        [PreserveSig]
        new HRESULT QueryService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);
        
        [PreserveSig]
        new HRESULT LocateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);
        
        [PreserveSig]
        new HRESULT RegisterService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);
        
        [PreserveSig]
        new HRESULT RegisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);
        
        [PreserveSig]
        new HRESULT UnregisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);
        
        [PreserveSig]
        new HRESULT FireEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument,
            [Out] out HRESULT pSinkResult);
        
        [PreserveSig]
        HRESULT RegisterConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);
        
        [PreserveSig]
        HRESULT QueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceUnknown);
        
        [PreserveSig]
        HRESULT LocateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);
    }
}
