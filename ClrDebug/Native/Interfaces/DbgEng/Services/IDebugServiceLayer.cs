using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6BF32043-E2A9-462D-99B1-B2E6C15252A2")]
    [ComImport]
    public interface IDebugServiceLayer
    {
        /// <summary>
        /// Registers the services in a service layer / component with a service manager. This only registers any canonical services.<para/>
        /// Registration of conditional services is via a call to IDebugServiceLayer2::RegisterConditionalServices.
        /// </summary>
        [PreserveSig]
        HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);

        /// <summary>
        /// Returns the set of services which this service layer / component depends on. Having sizeHardDependencies or sizeSoftDependencies set to 0 will pass back the number of dependencies and do nothing else.
        /// </summary>
        [PreserveSig]
        HRESULT GetServiceDependencies(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In] long sizeHardDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[] pHardDependencies,
            [Out] out long pNumHardDependencies,
            [In] long sizeSoftDependencies,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] Guid[] pSoftDependencies,
            [Out] out long pNumSoftDependencies);

        /// <summary>
        /// Performs initialization of the services in a service layer / component. Services which aggregate, encapsulate, or stack on top of other services must pass down the initialization notification in an appropriate manner (with notificationKind set to LayeredNotification.
        /// </summary>
        [PreserveSig]
        HRESULT InitializeServices(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid);

        /// <summary>
        /// Services in the services stack are notified of changes (the addition or removal of layers) via a call to this method.
        /// </summary>
        [PreserveSig]
        HRESULT NotifyServiceChange(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer priorService,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newService);

        /// <summary>
        /// Services in the service stack are notified of events they explicitly register to via this API.
        /// </summary>
        [PreserveSig]
        HRESULT NotifyEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument);
    }
}
