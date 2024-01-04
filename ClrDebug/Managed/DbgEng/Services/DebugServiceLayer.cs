using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
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

        public void RegisterServices(IDebugServiceManager serviceManager)
        {
            TryRegisterServices(serviceManager).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterServices(IDebugServiceManager serviceManager)
        {
            /*HRESULT RegisterServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager serviceManager);*/
            return Raw.RegisterServices(serviceManager);
        }

        #endregion
        #region GetServiceDependencies

        public GetServiceDependenciesResult GetServiceDependencies(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, long sizeHardDependencies, long sizeSoftDependencies)
        {
            GetServiceDependenciesResult result;
            TryGetServiceDependencies(notificationKind, serviceManager, serviceGuid, sizeHardDependencies, sizeSoftDependencies, out result).ThrowDbgEngNotOK();

            return result;
        }

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

        public void InitializeServices(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid)
        {
            TryInitializeServices(notificationKind, serviceManager, serviceGuid).ThrowDbgEngNotOK();
        }

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

        public void NotifyServiceChange(ServiceNotificationKind notificationKind, IDebugServiceManager serviceManager, Guid serviceGuid, IDebugServiceLayer priorService, IDebugServiceLayer newService)
        {
            TryNotifyServiceChange(notificationKind, serviceManager, serviceGuid, priorService, newService).ThrowDbgEngNotOK();
        }

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

        public void NotifyEvent(IDebugServiceManager serviceManager, Guid eventGuid, object eventArgument)
        {
            TryNotifyEvent(serviceManager, eventGuid, eventArgument).ThrowDbgEngNotOK();
        }

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

        public void RegisterConditionalServices(IDebugServiceManager serviceManager)
        {
            TryRegisterConditionalServices(serviceManager).ThrowDbgEngNotOK();
        }

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
