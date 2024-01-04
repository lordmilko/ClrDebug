namespace ClrDebug.DbgEng
{
    public class SvcOSKernelLocator : ComObject<ISvcOSKernelLocator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSKernelLocator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSKernelLocator(ISvcOSKernelLocator raw) : base(raw)
        {
        }

        #region ISvcOSKernelLocator
        #region KernelBase

        public long KernelBase
        {
            get
            {
                long pKernelBase;
                TryGetKernelBase(out pKernelBase).ThrowDbgEngNotOK();

                return pKernelBase;
            }
        }

        public HRESULT TryGetKernelBase(out long pKernelBase)
        {
            /*HRESULT GetKernelBase(
            [Out] out long pKernelBase);*/
            return Raw.GetKernelBase(out pKernelBase);
        }

        #endregion
        #region CreateOSKernelComponent

        public DebugServiceLayer CreateOSKernelComponent()
        {
            DebugServiceLayer ppServiceLayerResult;
            TryCreateOSKernelComponent(out ppServiceLayerResult).ThrowDbgEngNotOK();

            return ppServiceLayerResult;
        }

        public HRESULT TryCreateOSKernelComponent(out DebugServiceLayer ppServiceLayerResult)
        {
            /*HRESULT CreateOSKernelComponent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer ppServiceLayer);*/
            IDebugServiceLayer ppServiceLayer;
            HRESULT hr = Raw.CreateOSKernelComponent(out ppServiceLayer);

            if (hr == HRESULT.S_OK)
                ppServiceLayerResult = ppServiceLayer == null ? null : new DebugServiceLayer(ppServiceLayer);
            else
                ppServiceLayerResult = default(DebugServiceLayer);

            return hr;
        }

        #endregion
        #endregion
    }
}
