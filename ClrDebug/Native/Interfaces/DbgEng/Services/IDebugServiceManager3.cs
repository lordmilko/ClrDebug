using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("17B978DD-15C0-4318-A3D0-15305C6DD0D4")]
    [ComImport]
    public interface IDebugServiceManager3 : IDebugServiceManager2
    {
        /// <summary>
        /// Enumerates all of the services in the service manager.
        /// </summary>
        [PreserveSig]
        new HRESULT EnumerateServices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceEnumerator enumerator);

        /// <summary>
        /// Called once by the owner of the service manager to initialize all bound services in topological order. After the initialization, services which come into or change the service stack must be prepared to deal with immediate initialization and handling NotifyServiceChange calls.
        /// </summary>
        [PreserveSig]
        new HRESULT InitializeServices();

        /// <summary>
        /// Find a component which implements the service given by serviceGuid and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown.
        /// </summary>
        [PreserveSig]
        new HRESULT QueryService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);

        /// <summary>
        /// Finds a component which implements the service given by serviceGuid and returns a generic IUnknown interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required.
        /// </summary>
        [PreserveSig]
        new HRESULT LocateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);

        /// <summary>
        /// Registers a service with the service manager. If a service is already registered by the specified serviceGuid, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Registers a service for event notifications on a particular event (or set of events).
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Unregisters a service from event notifications on a particular event (or set of events).
        /// </summary>
        [PreserveSig]
        new HRESULT UnregisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Fires an event to all registered event sinks.
        /// </summary>
        [PreserveSig]
        new HRESULT FireEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument,
            [Out] out HRESULT pSinkResult);

        /// <summary>
        /// Clients should call this before releasing their final reference to the service manager. This will remove and uninitialize any services still in the service container.
        /// </summary>
        [PreserveSig]
        HRESULT UninitializeServices();
    }
}
