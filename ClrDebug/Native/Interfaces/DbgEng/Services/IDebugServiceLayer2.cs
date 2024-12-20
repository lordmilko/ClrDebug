using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("12954378-FAFD-4749-ADD8-7A98A5A4B896")]
    [ComImport]
    public interface IDebugServiceLayer2 : IDebugServiceLayer
    {
        /// <summary>
        /// Registers the services in a service layer / component with a service manager. This only registers any canonical services.<para/>
        /// Registration of conditional services is via a call to IDebugServiceLayer2::RegisterConditionalServices.
        /// </summary>
        [PreserveSig]
        new HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);

        /// <summary>
        /// Returns the set of services which this service layer / component depends on. Having sizeHardDependencies or sizeSoftDependencies set to 0 will pass back the number of dependencies and do nothing else.
        /// </summary>
        [PreserveSig]
        new HRESULT GetServiceDependencies(
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
        new HRESULT InitializeServices(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid);

        /// <summary>
        /// Services in the services stack are notified of changes (the addition or removal of layers) via a call to this method.
        /// </summary>
        [PreserveSig]
        new HRESULT NotifyServiceChange(
            [In] ServiceNotificationKind notificationKind,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer priorService,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer newService);

        /// <summary>
        /// Services in the service stack are notified of events they explicitly register to via this API.
        /// </summary>
        [PreserveSig]
        new HRESULT NotifyEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] object eventArgument);

        /// <summary>
        /// Registers the conditional services in a service layer / component with a service manager. This o only registers any conditional services.<para/>
        /// Registration of canonical services is via an explicit decision to do so and a call to IDebugServiceLayer::RegisterServices.<para/>
        /// Some conditional services may never be able to registered as canonical providers (RegisterServices will simply return S_FALSE) and some may be able to depending on conditions (e.g.: a custom architecture disassembler may be registered as both a conditional service and the canonical disassembler if the target machine architecture is the custom one).
        /// </summary>
        [PreserveSig]
        HRESULT RegisterConditionalServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);
    }
}
