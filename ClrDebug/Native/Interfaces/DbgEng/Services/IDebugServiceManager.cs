using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AB73D421-5FBA-403D-BC0D-4EB92720135A")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugServiceManager
    {
        /// <summary>
        /// Called once by the owner of the service manager to initialize all bound services in topological order. After the initialization, services which come into or change the service stack must be prepared to deal with immediate initialization and handling NotifyServiceChange calls.
        /// </summary>
        [PreserveSig]
        HRESULT InitializeServices();

        /// <summary>
        /// Find a component which implements the service given by serviceGuid and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown.
        /// </summary>
        [PreserveSig]
        HRESULT QueryService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceGuid,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);

        /// <summary>
        /// Finds a component which implements the service given by serviceGuid and returns a generic IUnknown interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required.
        /// </summary>
        [PreserveSig]
        HRESULT LocateService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);

        /// <summary>
        /// Registers a service with the service manager. If a service is already registered by the specified serviceGuid, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterService(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Registers a service for event notifications on a particular event (or set of events).
        /// </summary>
        [PreserveSig]
        HRESULT RegisterEventNotification(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Unregisters a service from event notifications on a particular event (or set of events).
        /// </summary>
        [PreserveSig]
        HRESULT UnregisterEventNotification(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Fires an event to all registered event sinks.
        /// </summary>
        [PreserveSig]
        HRESULT FireEventNotification(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument,
            [Out] out HRESULT pSinkResult);
    }
}
