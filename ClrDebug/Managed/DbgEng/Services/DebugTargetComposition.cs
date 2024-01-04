using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugTargetComposition : ComObject<IDebugTargetComposition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetComposition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetComposition(IDebugTargetComposition raw) : base(raw)
        {
        }

        #region IDebugTargetComposition
        #region CreateServiceManager

        public DebugServiceManager CreateServiceManager()
        {
            DebugServiceManager serviceManagerResult;
            TryCreateServiceManager(out serviceManagerResult).ThrowDbgEngNotOK();

            return serviceManagerResult;
        }

        public HRESULT TryCreateServiceManager(out DebugServiceManager serviceManagerResult)
        {
            /*HRESULT CreateServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager serviceManager);*/
            IDebugServiceManager serviceManager;
            HRESULT hr = Raw.CreateServiceManager(out serviceManager);

            if (hr == HRESULT.S_OK)
                serviceManagerResult = serviceManager == null ? null : new DebugServiceManager(serviceManager);
            else
                serviceManagerResult = default(DebugServiceManager);

            return hr;
        }

        #endregion
        #region RegisterComponent

        public void RegisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            TryRegisterComponent(componentGuid, component).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            /*HRESULT RegisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);*/
            return Raw.RegisterComponent(componentGuid, component);
        }

        #endregion
        #region CreateComponent

        public DebugServiceLayer CreateComponent(Guid componentGuid)
        {
            DebugServiceLayer componentServiceResult;
            TryCreateComponent(componentGuid, out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        public HRESULT TryCreateComponent(Guid componentGuid, out DebugServiceLayer componentServiceResult)
        {
            /*HRESULT CreateComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);*/
            IDebugServiceLayer componentService;
            HRESULT hr = Raw.CreateComponent(componentGuid, out componentService);

            if (hr == HRESULT.S_OK)
                componentServiceResult = componentService == null ? null : new DebugServiceLayer(componentService);
            else
                componentServiceResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #region CreateAndQueryComponent

        public CreateAndQueryComponentResult CreateAndQueryComponent(Guid componentGuid, Guid serviceInterface)
        {
            CreateAndQueryComponentResult result;
            TryCreateAndQueryComponent(componentGuid, serviceInterface, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryCreateAndQueryComponent(Guid componentGuid, Guid serviceInterface, out CreateAndQueryComponentResult result)
        {
            /*HRESULT CreateAndQueryComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);*/
            IDebugServiceLayer componentService;
            object interfaceUnknown;
            HRESULT hr = Raw.CreateAndQueryComponent(componentGuid, out componentService, serviceInterface, out interfaceUnknown);

            if (hr == HRESULT.S_OK)
                result = new CreateAndQueryComponentResult(componentService == null ? null : new DebugServiceLayer(componentService), interfaceUnknown);
            else
                result = default(CreateAndQueryComponentResult);

            return hr;
        }

        #endregion
        #region UnregisterComponent

        public void UnregisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            TryUnregisterComponent(componentGuid, component).ThrowDbgEngNotOK();
        }

        public HRESULT TryUnregisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            /*HRESULT UnregisterComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component);*/
            return Raw.UnregisterComponent(componentGuid, component);
        }

        #endregion
        #endregion
        #region IDebugTargetComposition2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetComposition2 Raw2 => (IDebugTargetComposition2) Raw;

        #region RegisterComponentAsConditionalService

        public void RegisterComponentAsConditionalService(Guid componentGuid, IDebugTargetCompositionComponent component, SvcConditionalServiceInformation conditionalServiceInfo)
        {
            TryRegisterComponentAsConditionalService(componentGuid, component, conditionalServiceInfo).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterComponentAsConditionalService(Guid componentGuid, IDebugTargetCompositionComponent component, SvcConditionalServiceInformation conditionalServiceInfo)
        {
            /*HRESULT RegisterComponentAsConditionalService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo);*/
            return Raw2.RegisterComponentAsConditionalService(componentGuid, component, ref conditionalServiceInfo);
        }

        #endregion
        #region CreateConditionalService

        public DebugServiceLayer CreateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo)
        {
            DebugServiceLayer componentServiceResult;
            TryCreateConditionalService(conditionalServiceInfo, out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        public HRESULT TryCreateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, out DebugServiceLayer componentServiceResult)
        {
            /*HRESULT CreateConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);*/
            IDebugServiceLayer componentService;
            HRESULT hr = Raw2.CreateConditionalService(ref conditionalServiceInfo, out componentService);

            if (hr == HRESULT.S_OK)
                componentServiceResult = componentService == null ? null : new DebugServiceLayer(componentService);
            else
                componentServiceResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #region CreateAndQueryConditionalService

        public CreateAndQueryConditionalServiceResult CreateAndQueryConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, Guid serviceInterface)
        {
            CreateAndQueryConditionalServiceResult result;
            TryCreateAndQueryConditionalService(conditionalServiceInfo, serviceInterface, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryCreateAndQueryConditionalService(SvcConditionalServiceInformation conditionalServiceInfo, Guid serviceInterface, out CreateAndQueryConditionalServiceResult result)
        {
            /*HRESULT CreateAndQueryConditionalService(
            [In] ref SvcConditionalServiceInformation conditionalServiceInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out object interfaceUnknown);*/
            IDebugServiceLayer componentService;
            object interfaceUnknown;
            HRESULT hr = Raw2.CreateAndQueryConditionalService(ref conditionalServiceInfo, out componentService, serviceInterface, out interfaceUnknown);

            if (hr == HRESULT.S_OK)
                result = new CreateAndQueryConditionalServiceResult(componentService == null ? null : new DebugServiceLayer(componentService), interfaceUnknown);
            else
                result = default(CreateAndQueryConditionalServiceResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugTargetComposition3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetComposition3 Raw3 => (IDebugTargetComposition3) Raw;

        #region RegisterComponentAsStandardAggregator

        public void RegisterComponentAsStandardAggregator(Guid componentGuid, IDebugTargetCompositionComponent component, Guid aggregatedServiceGuid)
        {
            TryRegisterComponentAsStandardAggregator(componentGuid, component, aggregatedServiceGuid).ThrowDbgEngNotOK();
        }

        public HRESULT TryRegisterComponentAsStandardAggregator(Guid componentGuid, IDebugTargetCompositionComponent component, Guid aggregatedServiceGuid)
        {
            /*HRESULT RegisterComponentAsStandardAggregator(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid componentGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugTargetCompositionComponent component,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid aggregatedServiceGuid);*/
            return Raw3.RegisterComponentAsStandardAggregator(componentGuid, component, aggregatedServiceGuid);
        }

        #endregion
        #region CreateServiceAggregatorComponent

        public DebugServiceLayer CreateServiceAggregatorComponent(Guid serviceGuid)
        {
            DebugServiceLayer componentServiceResult;
            TryCreateServiceAggregatorComponent(serviceGuid, out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        public HRESULT TryCreateServiceAggregatorComponent(Guid serviceGuid, out DebugServiceLayer componentServiceResult)
        {
            /*HRESULT CreateServiceAggregatorComponent(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);*/
            IDebugServiceLayer componentService;
            HRESULT hr = Raw3.CreateServiceAggregatorComponent(serviceGuid, out componentService);

            if (hr == HRESULT.S_OK)
                componentServiceResult = componentService == null ? null : new DebugServiceLayer(componentService);
            else
                componentServiceResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #endregion
    }
}
