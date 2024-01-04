using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5637D1DE-5804-4AEE-A98B-9BA1E97A8A07")]
    [ComImport]
    public interface IDebugServiceManager5 : IDebugServiceManager4
    {
        [PreserveSig]
        new HRESULT RegisterConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);
        
        [PreserveSig]
        new HRESULT QueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceUnknown);
        
        [PreserveSig]
        new HRESULT LocateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);
        
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
        HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newAggregateService);
    }
}
