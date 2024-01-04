namespace ClrDebug.DbgEng
{
    public class DebugHostContextControl : ComObject<IDebugHostContextControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContextControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContextControl(IDebugHostContextControl raw) : base(raw)
        {
        }

        #region IDebugHostContextControl
        #region ContextAlternator

        public DebugHostContextAlternator ContextAlternator
        {
            get
            {
                DebugHostContextAlternator contextAlternatorResult;
                TryGetContextAlternator(out contextAlternatorResult).ThrowDbgEngNotOK();

                return contextAlternatorResult;
            }
        }

        public HRESULT TryGetContextAlternator(out DebugHostContextAlternator contextAlternatorResult)
        {
            /*HRESULT GetContextAlternator(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContextAlternator contextAlternator);*/
            IDebugHostContextAlternator contextAlternator;
            HRESULT hr = Raw.GetContextAlternator(out contextAlternator);

            if (hr == HRESULT.S_OK)
                contextAlternatorResult = contextAlternator == null ? null : new DebugHostContextAlternator(contextAlternator);
            else
                contextAlternatorResult = default(DebugHostContextAlternator);

            return hr;
        }

        #endregion
        #region SwitchTo

        public void SwitchTo()
        {
            TrySwitchTo().ThrowDbgEngNotOK();
        }

        public HRESULT TrySwitchTo()
        {
            /*HRESULT SwitchTo();*/
            return Raw.SwitchTo();
        }

        #endregion
        #endregion
    }
}
