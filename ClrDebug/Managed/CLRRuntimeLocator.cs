namespace ClrDebug
{
    public class CLRRuntimeLocator : ComObject<ICLRRuntimeLocator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRRuntimeLocator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRRuntimeLocator(ICLRRuntimeLocator raw) : base(raw)
        {
        }

        #region ICLRRuntimeLocator
        #region RuntimeBase

        public CLRDATA_ADDRESS RuntimeBase
        {
            get
            {
                CLRDATA_ADDRESS baseAddress;
                TryGetRuntimeBase(out baseAddress).ThrowOnNotOK();

                return baseAddress;
            }
        }

        public HRESULT TryGetRuntimeBase(out CLRDATA_ADDRESS baseAddress)
        {
            /*HRESULT GetRuntimeBase(
            [Out] out CLRDATA_ADDRESS baseAddress);*/
            return Raw.GetRuntimeBase(out baseAddress);
        }

        #endregion
        #endregion
    }
}
