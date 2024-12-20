namespace ClrDebug.DbgEng
{
    public class DebugTargetCompositionComponent : ComObject<IDebugTargetCompositionComponent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetCompositionComponent"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetCompositionComponent(IDebugTargetCompositionComponent raw) : base(raw)
        {
        }

        #region IDebugTargetCompositionComponent
        #region CreateInstance

        /// <summary>
        /// Create a new instance of this component which is not yet bound to any service manager.
        /// </summary>
        public DebugServiceLayer CreateInstance()
        {
            DebugServiceLayer componentServiceResult;
            TryCreateInstance(out componentServiceResult).ThrowDbgEngNotOK();

            return componentServiceResult;
        }

        /// <summary>
        /// Create a new instance of this component which is not yet bound to any service manager.
        /// </summary>
        public HRESULT TryCreateInstance(out DebugServiceLayer componentServiceResult)
        {
            /*HRESULT CreateInstance(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);*/
            IDebugServiceLayer componentService;
            HRESULT hr = Raw.CreateInstance(out componentService);

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
