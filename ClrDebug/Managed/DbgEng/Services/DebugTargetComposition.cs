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

        /// <summary>
        /// Creates a service manager.
        /// </summary>
        public DebugServiceManager CreateServiceManager()
        {
            DebugServiceManager serviceManagerResult;
            TryCreateServiceManager(out serviceManagerResult).ThrowDbgEngNotOK();

            return serviceManagerResult;
        }

        /// <summary>
        /// Creates a service manager.
        /// </summary>
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

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.
        /// </summary>
        public void RegisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            TryRegisterComponent(componentGuid, component).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.
        /// </summary>
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

        /// <summary>
        /// Unregisters a given component by GUID such that instances of the component can no longer be created via Create[AndQuery]Component.
        /// </summary>
        public void UnregisterComponent(Guid componentGuid, IDebugTargetCompositionComponent component)
        {
            TryUnregisterComponent(componentGuid, component).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Unregisters a given component by GUID such that instances of the component can no longer be created via Create[AndQuery]Component.
        /// </summary>
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

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.<para/>
        /// In addition, registers the component as a conditional implementation of a given service as given by the conditional service information.<para/>
        /// The given component can either be created by its explicit component GUID or it can be created by a the service GUID and a description of the conditions.
        /// </summary>
        public void RegisterComponentAsConditionalService(Guid componentGuid, IDebugTargetCompositionComponent component, SvcConditionalServiceInformation conditionalServiceInfo)
        {
            TryRegisterComponentAsConditionalService(componentGuid, component, conditionalServiceInfo).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a given component by GUID such that an instance of the component can be created via Create[AndQuery]Component.<para/>
        /// In addition, registers the component as a conditional implementation of a given service as given by the conditional service information.<para/>
        /// The given component can either be created by its explicit component GUID or it can be created by a the service GUID and a description of the conditions.
        /// </summary>
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

        /// <summary>
        /// Finds the component registered as the implementation of a particular service for a particular set of conditions and creates it.
        /// </summary>
        public DebugServiceLayer CreateConditionalService(SvcConditionalServiceInformation conditionalServiceInfo)
        {
            DebugServiceLayer componentServiceResult;
            TryCreateConditionalService(conditionalServiceInfo, out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        /// <summary>
        /// Finds the component registered as the implementation of a particular service for a particular set of conditions and creates it.
        /// </summary>
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

        /// <summary>
        /// Registers a given component by GUID such that it acts as the standard means of aggregation for another service as identified by GUID.<para/>
        /// The given component must implement IDebugServiceAggregate.
        /// </summary>
        public void RegisterComponentAsStandardAggregator(Guid componentGuid, IDebugTargetCompositionComponent component, Guid aggregatedServiceGuid)
        {
            TryRegisterComponentAsStandardAggregator(componentGuid, component, aggregatedServiceGuid).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers a given component by GUID such that it acts as the standard means of aggregation for another service as identified by GUID.<para/>
        /// The given component must implement IDebugServiceAggregate.
        /// </summary>
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

        /// <summary>
        /// Finds the component registered as the standard implementation of an aggregator for a particular service and creates it.<para/>
        /// The returned component will implement IDebugServiceAggregate.
        /// </summary>
        public DebugServiceLayer CreateServiceAggregatorComponent(Guid serviceGuid)
        {
            DebugServiceLayer componentServiceResult;
            TryCreateServiceAggregatorComponent(serviceGuid, out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        /// <summary>
        /// Finds the component registered as the standard implementation of an aggregator for a particular service and creates it.<para/>
        /// The returned component will implement IDebugServiceAggregate.
        /// </summary>
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
