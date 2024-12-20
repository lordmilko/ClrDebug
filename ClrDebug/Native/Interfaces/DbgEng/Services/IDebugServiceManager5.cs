using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5637D1DE-5804-4AEE-A98B-9BA1E97A8A07")]
    [ComImport]
    public interface IDebugServiceManager5 : IDebugServiceManager4
    {
        /// <summary>
        /// Registers a conditional service with the service manager. If a service is already registered by the specified serviceGuid and conditions, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer. NOTE: If a component wishes to be both a conditional service and a canonical service, it must call both RegisterConditionalService and RegisterService and deal with the fact that it may be initialized twice.<para/>
        /// An example of this might be a disassembler service which registers as the AMD64 disassembler but also the canonical disassembler for an AMD64 debug target.<para/>
        /// It may be the case that such a service would need to listen for change notifications and add/remove itself as the canonical service if conditions can change.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);

        /// <summary>
        /// Find a component which implements the service given in in the conditionalServiceInfo structure according to the conditions specified there and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        [PreserveSig]
        new HRESULT QueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceUnknown);

        /// <summary>
        /// Finds a component which implements the service given in the conditionalServiceInfo structure according to the conditions specified there and return a generic interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        [PreserveSig]
        new HRESULT LocateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);

        /// <summary>
        /// Clients should call this before releasing their final reference to the service manager. This will remove and uninitialize any services still in the service container.
        /// </summary>
        [PreserveSig]
        new HRESULT UninitializeServices();

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
        /// Adds a new service to an aggregate collection in the service manager. Instead of calling pService-&gt;RegisterServices(pServiceManager) to register the service, calling pServiceManager-&gt;AggregateService(DEBUG_SERVICE_XXX, pService) acts as a "helper method" with the following functionality - If there is no DEBUG_SERVICE_XXX in the service container, it behaves identically to calling pService-&gt;RegisterServices(pServiceManager).<para/>
        /// - If there is a DEBUG_SERVICE_XXX in the service container and that service is already an aggregator, it queries the existing service for IDebugServiceAggregate and calls AggregateService.<para/>
        /// In effect, it adds 'newAggregateService' as one of the children that the aggregator aggregates. - If there is a DEBUG_SERVICE_XXX in the service container and that service is *NOT* an aggregator, it creates the default aggregator for the service (via IDebugTargetComposition3::CreateServiceAggregatorComponent), replaces what was in the container with the newly created aggregator, and adds both the pre-existing service and 'newAggregateService' as children that the aggregator aggregates.<para/>
        /// Note that this method can fail if there is no defualt aggregator registered for a particular service.
        /// </summary>
        [PreserveSig]
        HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newAggregateService);
    }
}
