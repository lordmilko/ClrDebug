using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("17B978DD-15C0-4318-A3D0-15305C6DD0D4")]
    [ComImport]
    public interface IDebugServiceManager3 : IDebugServiceManager2
    {
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
        HRESULT UninitializeServices();
    }
}
