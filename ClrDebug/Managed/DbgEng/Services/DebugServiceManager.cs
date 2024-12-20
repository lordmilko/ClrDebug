using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugServiceManager : ComObject<IDebugServiceManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugServiceManager(IDebugServiceManager raw) : base(raw)
        {
        }

        #region IDebugServiceManager
        #region InitializeServices

        /// <summary>
        /// Called once by the owner of the service manager to initialize all bound services in topological order. After the initialization, services which come into or change the service stack must be prepared to deal with immediate initialization and handling NotifyServiceChange calls.
        /// </summary>
        public void InitializeServices()
        {
            TryInitializeServices().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Called once by the owner of the service manager to initialize all bound services in topological order. After the initialization, services which come into or change the service stack must be prepared to deal with immediate initialization and handling NotifyServiceChange calls.
        /// </summary>
        public HRESULT TryInitializeServices()
        {
            /*HRESULT InitializeServices();*/
            return Raw.InitializeServices();
        }

        #endregion
        #region QueryService

        /// <summary>
        /// Find a component which implements the service given by serviceGuid and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown.
        /// </summary>
        public object QueryService(Guid serviceGuid, Guid serviceInterface)
        {
            object interfaceUnknown;
            TryQueryService(serviceGuid, serviceInterface, out interfaceUnknown).ThrowDbgEngNotOK();

            return interfaceUnknown;
        }

        /// <summary>
        /// Find a component which implements the service given by serviceGuid and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown.
        /// </summary>
        public HRESULT TryQueryService(Guid serviceGuid, Guid serviceInterface, out object interfaceUnknown)
        {
            /*HRESULT QueryService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);*/
            return Raw.QueryService(serviceGuid, serviceInterface, out interfaceUnknown);
        }

        #endregion
        #region LocateService

        /// <summary>
        /// Finds a component which implements the service given by serviceGuid and returns a generic IUnknown interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required.
        /// </summary>
        public DebugServiceLayer LocateService(Guid serviceGuid)
        {
            DebugServiceLayer serviceResult;
            TryLocateService(serviceGuid, out serviceResult).ThrowDbgEngNotOK();

            return serviceResult;
        }

        /// <summary>
        /// Finds a component which implements the service given by serviceGuid and returns a generic IUnknown interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required.
        /// </summary>
        public HRESULT TryLocateService(Guid serviceGuid, out DebugServiceLayer serviceResult)
        {
            /*HRESULT LocateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);*/
            IDebugServiceLayer service;
            HRESULT hr = Raw.LocateService(serviceGuid, out service);

            if (hr == HRESULT.S_OK)
                serviceResult = service == null ? null : new DebugServiceLayer(service);
            else
                serviceResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #region RegisterService

        /// <summary>
        /// Registers a service with the service manager. If a service is already registered by the specified serviceGuid, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer.
        /// </summary>
        public void RegisterService(Guid serviceGuid, IDebugServiceLayer service)
        {
            TryRegisterService(serviceGuid, service).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a service with the service manager. If a service is already registered by the specified serviceGuid, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer.
        /// </summary>
        public HRESULT TryRegisterService(Guid serviceGuid, IDebugServiceLayer service)
        {
            /*HRESULT RegisterService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.RegisterService(serviceGuid, service);
        }

        #endregion
        #region RegisterEventNotification

        /// <summary>
        /// Registers a service for event notifications on a particular event (or set of events).
        /// </summary>
        public void RegisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            TryRegisterEventNotification(eventGuid, service).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a service for event notifications on a particular event (or set of events).
        /// </summary>
        public HRESULT TryRegisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            /*HRESULT RegisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.RegisterEventNotification(eventGuid, service);
        }

        #endregion
        #region UnregisterEventNotification

        /// <summary>
        /// Unregisters a service from event notifications on a particular event (or set of events).
        /// </summary>
        public void UnregisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            TryUnregisterEventNotification(eventGuid, service).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Unregisters a service from event notifications on a particular event (or set of events).
        /// </summary>
        public HRESULT TryUnregisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            /*HRESULT UnregisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.UnregisterEventNotification(eventGuid, service);
        }

        #endregion
        #region FireEventNotification

        /// <summary>
        /// Fires an event to all registered event sinks.
        /// </summary>
        public HRESULT FireEventNotification(Guid eventGuid, object eventArgument)
        {
            HRESULT pSinkResult;
            TryFireEventNotification(eventGuid, eventArgument, out pSinkResult).ThrowDbgEngNotOK();

            return pSinkResult;
        }

        /// <summary>
        /// Fires an event to all registered event sinks.
        /// </summary>
        public HRESULT TryFireEventNotification(Guid eventGuid, object eventArgument, out HRESULT pSinkResult)
        {
            /*HRESULT FireEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument,
            [Out] out HRESULT pSinkResult);*/
            return Raw.FireEventNotification(eventGuid, eventArgument, out pSinkResult);
        }

        #endregion
        #endregion
        #region IDebugServiceManager2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugServiceManager2 Raw2 => (IDebugServiceManager2) Raw;

        #region EnumerateServices

        /// <summary>
        /// Enumerates all of the services in the service manager.
        /// </summary>
        public DebugServiceEnumerator EnumerateServices()
        {
            DebugServiceEnumerator enumeratorResult;
            TryEnumerateServices(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// Enumerates all of the services in the service manager.
        /// </summary>
        public HRESULT TryEnumerateServices(out DebugServiceEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateServices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceEnumerator enumerator);*/
            IDebugServiceEnumerator enumerator;
            HRESULT hr = Raw2.EnumerateServices(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new DebugServiceEnumerator(enumerator);
            else
                enumeratorResult = default(DebugServiceEnumerator);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugServiceManager3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugServiceManager3 Raw3 => (IDebugServiceManager3) Raw;

        #region UninitializeServices

        /// <summary>
        /// Clients should call this before releasing their final reference to the service manager. This will remove and uninitialize any services still in the service container.
        /// </summary>
        public void UninitializeServices()
        {
            TryUninitializeServices().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Clients should call this before releasing their final reference to the service manager. This will remove and uninitialize any services still in the service container.
        /// </summary>
        public HRESULT TryUninitializeServices()
        {
            /*HRESULT UninitializeServices();*/
            return Raw3.UninitializeServices();
        }

        #endregion
        #endregion
        #region IDebugServiceManager4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugServiceManager4 Raw4 => (IDebugServiceManager4) Raw;

        #region RegisterConditionalService

        /// <summary>
        /// Registers a conditional service with the service manager. If a service is already registered by the specified serviceGuid and conditions, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer. NOTE: If a component wishes to be both a conditional service and a canonical service, it must call both RegisterConditionalService and RegisterService and deal with the fact that it may be initialized twice.<para/>
        /// An example of this might be a disassembler service which registers as the AMD64 disassembler but also the canonical disassembler for an AMD64 debug target.<para/>
        /// It may be the case that such a service would need to listen for change notifications and add/remove itself as the canonical service if conditions can change.
        /// </summary>
        public void RegisterConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, IDebugServiceLayer service)
        {
            TryRegisterConditionalService(conditionalServiceInfo, service).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a conditional service with the service manager. If a service is already registered by the specified serviceGuid and conditions, this call will replace the underlying service.<para/>
        /// Unregistration of a service can be performed by registering a nullptr service layer. NOTE: If a component wishes to be both a conditional service and a canonical service, it must call both RegisterConditionalService and RegisterService and deal with the fact that it may be initialized twice.<para/>
        /// An example of this might be a disassembler service which registers as the AMD64 disassembler but also the canonical disassembler for an AMD64 debug target.<para/>
        /// It may be the case that such a service would need to listen for change notifications and add/remove itself as the canonical service if conditions can change.
        /// </summary>
        public HRESULT TryRegisterConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, IDebugServiceLayer service)
        {
            /*HRESULT RegisterConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw4.RegisterConditionalService(ref conditionalServiceInfo, service);
        }

        #endregion
        #region QueryConditionalService

        /// <summary>
        /// Find a component which implements the service given in in the conditionalServiceInfo structure according to the conditions specified there and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        public object QueryConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd, Guid serviceInterface)
        {
            object serviceUnknown;
            TryQueryConditionalService(conditionalServiceInfo, dynamicAdd, serviceInterface, out serviceUnknown).ThrowDbgEngNotOK();

            return serviceUnknown;
        }

        /// <summary>
        /// Find a component which implements the service given in in the conditionalServiceInfo structure according to the conditions specified there and query it for the interface specified by serviceInterface.<para/>
        /// Such service is returned in interfaceUnknown. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        public HRESULT TryQueryConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd, Guid serviceInterface, out object serviceUnknown)
        {
            /*HRESULT QueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceUnknown);*/
            return Raw4.QueryConditionalService(ref conditionalServiceInfo, dynamicAdd, serviceInterface, out serviceUnknown);
        }

        #endregion
        #region LocateConditionalService

        /// <summary>
        /// Finds a component which implements the service given in the conditionalServiceInfo structure according to the conditions specified there and return a generic interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        public DebugServiceLayer LocateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd)
        {
            DebugServiceLayer serviceResult;
            TryLocateConditionalService(conditionalServiceInfo, dynamicAdd, out serviceResult).ThrowDbgEngNotOK();

            return serviceResult;
        }

        /// <summary>
        /// Finds a component which implements the service given in the conditionalServiceInfo structure according to the conditions specified there and return a generic interface to the service.<para/>
        /// The service must be explicitly queried for whatever interface is required. If the 'dynamicAdd' parameter is true and the composition manager knows of a component that provides the service under the given condition, the component will be created and added to the service container.
        /// </summary>
        public HRESULT TryLocateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd, out DebugServiceLayer serviceResult)
        {
            /*HRESULT LocateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.U1)] bool dynamicAdd,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);*/
            IDebugServiceLayer service;
            HRESULT hr = Raw4.LocateConditionalService(ref conditionalServiceInfo, dynamicAdd, out service);

            if (hr == HRESULT.S_OK)
                serviceResult = service == null ? null : new DebugServiceLayer(service);
            else
                serviceResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugServiceManager5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugServiceManager5 Raw5 => (IDebugServiceManager5) Raw;

        #region AggregateService

        /// <summary>
        /// Adds a new service to an aggregate collection in the service manager. Instead of calling pService-&gt;RegisterServices(pServiceManager) to register the service, calling pServiceManager-&gt;AggregateService(DEBUG_SERVICE_XXX, pService) acts as a "helper method" with the following functionality - If there is no DEBUG_SERVICE_XXX in the service container, it behaves identically to calling pService-&gt;RegisterServices(pServiceManager).<para/>
        /// - If there is a DEBUG_SERVICE_XXX in the service container and that service is already an aggregator, it queries the existing service for IDebugServiceAggregate and calls AggregateService.<para/>
        /// In effect, it adds 'newAggregateService' as one of the children that the aggregator aggregates. - If there is a DEBUG_SERVICE_XXX in the service container and that service is *NOT* an aggregator, it creates the default aggregator for the service (via IDebugTargetComposition3::CreateServiceAggregatorComponent), replaces what was in the container with the newly created aggregator, and adds both the pre-existing service and 'newAggregateService' as children that the aggregator aggregates.<para/>
        /// Note that this method can fail if there is no defualt aggregator registered for a particular service.
        /// </summary>
        public void AggregateService(Guid serviceGuid, IDebugServiceLayer newAggregateService)
        {
            TryAggregateService(serviceGuid, newAggregateService).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Adds a new service to an aggregate collection in the service manager. Instead of calling pService-&gt;RegisterServices(pServiceManager) to register the service, calling pServiceManager-&gt;AggregateService(DEBUG_SERVICE_XXX, pService) acts as a "helper method" with the following functionality - If there is no DEBUG_SERVICE_XXX in the service container, it behaves identically to calling pService-&gt;RegisterServices(pServiceManager).<para/>
        /// - If there is a DEBUG_SERVICE_XXX in the service container and that service is already an aggregator, it queries the existing service for IDebugServiceAggregate and calls AggregateService.<para/>
        /// In effect, it adds 'newAggregateService' as one of the children that the aggregator aggregates. - If there is a DEBUG_SERVICE_XXX in the service container and that service is *NOT* an aggregator, it creates the default aggregator for the service (via IDebugTargetComposition3::CreateServiceAggregatorComponent), replaces what was in the container with the newly created aggregator, and adds both the pre-existing service and 'newAggregateService' as children that the aggregator aggregates.<para/>
        /// Note that this method can fail if there is no defualt aggregator registered for a particular service.
        /// </summary>
        public HRESULT TryAggregateService(Guid serviceGuid, IDebugServiceLayer newAggregateService)
        {
            /*HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newAggregateService);*/
            return Raw5.AggregateService(serviceGuid, newAggregateService);
        }

        #endregion
        #endregion
    }
}
