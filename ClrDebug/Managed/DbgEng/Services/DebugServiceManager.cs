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

        public void InitializeServices()
        {
            TryInitializeServices().ThrowDbgEngNotOK();
        }

        public HRESULT TryInitializeServices()
        {
            /*HRESULT InitializeServices();*/
            return Raw.InitializeServices();
        }

        #endregion
        #region QueryService

        public object QueryService(Guid serviceGuid, Guid serviceInterface)
        {
            object interfaceUnknown;
            TryQueryService(serviceGuid, serviceInterface, out interfaceUnknown).ThrowDbgEngNotOK();

            return interfaceUnknown;
        }

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

        public DebugServiceLayer LocateService(Guid serviceGuid)
        {
            DebugServiceLayer serviceResult;
            TryLocateService(serviceGuid, out serviceResult).ThrowDbgEngNotOK();

            return serviceResult;
        }

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

        public void RegisterService(Guid serviceGuid, IDebugServiceLayer service)
        {
            TryRegisterService(serviceGuid, service).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterService(Guid serviceGuid, IDebugServiceLayer service)
        {
            /*HRESULT RegisterService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.RegisterService(serviceGuid, service);
        }

        #endregion
        #region RegisterEventNotification

        public void RegisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            TryRegisterEventNotification(eventGuid, service).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            /*HRESULT RegisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.RegisterEventNotification(eventGuid, service);
        }

        #endregion
        #region UnregisterEventNotification

        public void UnregisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            TryUnregisterEventNotification(eventGuid, service).ThrowDbgEngNotOK();
        }

        public HRESULT TryUnregisterEventNotification(Guid eventGuid, IDebugServiceLayer service)
        {
            /*HRESULT UnregisterEventNotification(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid eventGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw.UnregisterEventNotification(eventGuid, service);
        }

        #endregion
        #region FireEventNotification

        public HRESULT FireEventNotification(Guid eventGuid, object eventArgument)
        {
            HRESULT pSinkResult;
            TryFireEventNotification(eventGuid, eventArgument, out pSinkResult).ThrowDbgEngNotOK();

            return pSinkResult;
        }

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

        public DebugServiceEnumerator EnumerateServices()
        {
            DebugServiceEnumerator enumeratorResult;
            TryEnumerateServices(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

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

        public void UninitializeServices()
        {
            TryUninitializeServices().ThrowDbgEngNotOK();
        }

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

        public void RegisterConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, IDebugServiceLayer service)
        {
            TryRegisterConditionalService(conditionalServiceInfo, service).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, IDebugServiceLayer service)
        {
            /*HRESULT RegisterConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer service);*/
            return Raw4.RegisterConditionalService(ref conditionalServiceInfo, service);
        }

        #endregion
        #region QueryConditionalService

        public object QueryConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd, Guid serviceInterface)
        {
            object serviceUnknown;
            TryQueryConditionalService(conditionalServiceInfo, dynamicAdd, serviceInterface, out serviceUnknown).ThrowDbgEngNotOK();

            return serviceUnknown;
        }

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

        public DebugServiceLayer LocateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, bool dynamicAdd)
        {
            DebugServiceLayer serviceResult;
            TryLocateConditionalService(conditionalServiceInfo, dynamicAdd, out serviceResult).ThrowDbgEngNotOK();

            return serviceResult;
        }

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

        public void AggregateService(Guid serviceGuid, IDebugServiceLayer newAggregateService)
        {
            TryAggregateService(serviceGuid, newAggregateService).ThrowDbgEngNotOK();
        }

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
