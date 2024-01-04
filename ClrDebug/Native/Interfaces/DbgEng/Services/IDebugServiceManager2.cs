using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("099FCD6F-0A4D-45CC-BD8B-C10C6ED53AC7")]
    [ComImport]
    public interface IDebugServiceManager2 : IDebugServiceManager
    {
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
        HRESULT EnumerateServices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceEnumerator enumerator);
    }
}
