using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Every service which is managed by the services manager must support IDebugServiceLayer. Initialization of a service occurs in stages 1) The service is bound to a service manager (irrevocably).<para/>
    /// Someone will call RegisterServices() on the service in order to perform this action. The implementation of RegisterServices should call back the service manager and register each service within the component via a call to RegisterService.<para/>
    /// At this stage, the service should *NOT* make calls on dependent services. 2) When the service manager is ready, it will make a call into each and every service asking for its dependent services (a call to GetServiceDependencies).<para/>
    /// The component should return all services that it depends on - A "hard dependency" is a service which this component relies on and cannot do without.<para/>
    /// The service manager will not "start" the target until all dependent services are initialized. The set of "hard dependencies" should form a DAG.<para/>
    /// Initialization of each service in the DAG will occur in topological order. - A "soft dependency" is a service which is either not mandatory or creates a cycle in service dependencies.<para/>
    /// The component in question should be prepared to deal with call failures from such a service. NOTE: For conditional services, a dependency can be resolved via either a regular service *OR* a another conditional service with the same condition set.<para/>
    /// A regular service is preferred. 3) The service manager will perform a topological sort of the DAG of service dependencies and call InitializeServices for the service in question.<para/>
    /// At this point, calls to dependent services can be made. Note that any service which aggregates, stacks on top of, or encapsulates another service is required to handle passing down initialization calls in an appropriate manner.
    /// </summary>
    public class DebugServiceLayer : ComObject<IDebugServiceLayer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceLayer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugServiceLayer(IDebugServiceLayer raw) : base(raw)
        {
        }

        #region IDebugServiceLayer
        #region RegisterServices

        /// <summary>
        /// Registers the services in a service layer / component with a service manager. This only registers any canonical services.<para/>
        /// Registration of conditional services is via a call to IDebugServiceLayer2::RegisterConditionalServices.
        /// </summary>
        public void RegisterServices(IDebugServiceManager serviceManager)
        {
            TryRegisterServices(serviceManager).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers the services in a service layer / component with a service manager. This only registers any canonical services.<para/>
        /// Registration of conditional services is via a call to IDebugServiceLayer2::RegisterConditionalServices.
        /// </summary>
        public HRESULT TryRegisterServices(IDebugServiceManager serviceManager)
        {
            /*HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);*/
            return Raw.RegisterServices(serviceManager);
        }

        #endregion
        #region GetServiceDependencies

        /// <summary>
        /// Returns the set of services which this service layer / component depends on. Having sizeHardDependencies or sizeSoftDependencies set to 0 will pass back the number of dependencies and do nothing else.
        /// </summary>
        public GetServiceDependenciesResult GetServiceDependencies(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, long sizeHardDependencies, long sizeSoftDependencies)
        {
            GetServiceDependenciesResult result;
            TryGetServiceDependencies(notificationKind, serviceManager, serviceGuid, sizeHardDependencies, sizeSoftDependencies, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Returns the set of services which this service layer / component depends on. Having sizeHardDependencies or sizeSoftDependencies set to 0 will pass back the number of dependencies and do nothing else.
        /// </summary>
        public HRESULT TryGetServiceDependencies(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, long sizeHardDependencies, long sizeSoftDependencies, out GetServiceDependenciesResult result)
        {
            /*HRESULT GetServiceDependencies(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In] long sizeHardDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[] pHardDependencies,
            [Out] out long pNumHardDependencies,
            [In] long sizeSoftDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] Guid[] pSoftDependencies,
            [Out] out long pNumSoftDependencies);*/
            Guid[] pHardDependencies = new Guid[(int) sizeHardDependencies];
            long pNumHardDependencies;
            Guid[] pSoftDependencies = new Guid[(int) sizeSoftDependencies];
            long pNumSoftDependencies;
            HRESULT hr = Raw.GetServiceDependencies(notificationKind, serviceManager, serviceGuid, sizeHardDependencies, pHardDependencies, out pNumHardDependencies, sizeSoftDependencies, pSoftDependencies, out pNumSoftDependencies);

            if (hr == HRESULT.S_OK)
                result = new GetServiceDependenciesResult(pHardDependencies, pNumHardDependencies, pSoftDependencies, pNumSoftDependencies);
            else
                result = default(GetServiceDependenciesResult);

            return hr;
        }

        #endregion
        #region InitializeServices

        /// <summary>
        /// Performs initialization of the services in a service layer / component. Services which aggregate, encapsulate, or stack on top of other services must pass down the initialization notification in an appropriate manner (with notificationKind set to LayeredNotification.
        /// </summary>
        public void InitializeServices(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid)
        {
            TryInitializeServices(notificationKind, serviceManager, serviceGuid).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Performs initialization of the services in a service layer / component. Services which aggregate, encapsulate, or stack on top of other services must pass down the initialization notification in an appropriate manner (with notificationKind set to LayeredNotification.
        /// </summary>
        public HRESULT TryInitializeServices(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid)
        {
            /*HRESULT InitializeServices(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid);*/
            return Raw.InitializeServices(notificationKind, serviceManager, serviceGuid);
        }

        #endregion
        #region NotifyServiceChange

        /// <summary>
        /// Services in the services stack are notified of changes (the addition or removal of layers) via a call to this method.
        /// </summary>
        public void NotifyServiceChange(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, IDebugServiceLayer priorService, IDebugServiceLayer newService)
        {
            TryNotifyServiceChange(notificationKind, serviceManager, serviceGuid, priorService, newService).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Services in the services stack are notified of changes (the addition or removal of layers) via a call to this method.
        /// </summary>
        public HRESULT TryNotifyServiceChange(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, IDebugServiceLayer priorService, IDebugServiceLayer newService)
        {
            /*HRESULT NotifyServiceChange(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer priorService,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newService);*/
            return Raw.NotifyServiceChange(notificationKind, serviceManager, serviceGuid, priorService, newService);
        }

        #endregion
        #region NotifyEvent

        /// <summary>
        /// Services in the service stack are notified of events they explicitly register to via this API.
        /// </summary>
        public void NotifyEvent(IDebugServiceManager serviceManager, Guid eventGuid, object eventArgument)
        {
            TryNotifyEvent(serviceManager, eventGuid, eventArgument).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Services in the service stack are notified of events they explicitly register to via this API.
        /// </summary>
        public HRESULT TryNotifyEvent(IDebugServiceManager serviceManager, Guid eventGuid, object eventArgument)
        {
            /*HRESULT NotifyEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument);*/
            return Raw.NotifyEvent(serviceManager, eventGuid, eventArgument);
        }

        #endregion
        #endregion
        #region IDebugServiceLayer2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugServiceLayer2 Raw2 => (IDebugServiceLayer2) Raw;

        #region RegisterConditionalServices

        /// <summary>
        /// Registers the conditional services in a service layer / component with a service manager. This o only registers any conditional services.<para/>
        /// Registration of canonical services is via an explicit decision to do so and a call to IDebugServiceLayer::RegisterServices.<para/>
        /// Some conditional services may never be able to registered as canonical providers (RegisterServices will simply return S_FALSE) and some may be able to depending on conditions (e.g.: a custom architecture disassembler may be registered as both a conditional service and the canonical disassembler if the target machine architecture is the custom one).
        /// </summary>
        public void RegisterConditionalServices(IDebugServiceManager serviceManager)
        {
            TryRegisterConditionalServices(serviceManager).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers the conditional services in a service layer / component with a service manager. This o only registers any conditional services.<para/>
        /// Registration of canonical services is via an explicit decision to do so and a call to IDebugServiceLayer::RegisterServices.<para/>
        /// Some conditional services may never be able to registered as canonical providers (RegisterServices will simply return S_FALSE) and some may be able to depending on conditions (e.g.: a custom architecture disassembler may be registered as both a conditional service and the canonical disassembler if the target machine architecture is the custom one).
        /// </summary>
        public HRESULT TryRegisterConditionalServices(IDebugServiceManager serviceManager)
        {
            /*HRESULT RegisterConditionalServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);*/
            return Raw2.RegisterConditionalServices(serviceManager);
        }

        #endregion
        #endregion
    }
}
