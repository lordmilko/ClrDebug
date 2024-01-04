namespace ClrDebug.DbgEng
{
    public class SvcExecutionUnitHardware : ComObject<ISvcExecutionUnitHardware>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExecutionUnitHardware"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExecutionUnitHardware(ISvcExecutionUnitHardware raw) : base(raw)
        {
        }

        #region ISvcExecutionUnitHardware
        #region SpecialContext

        public SvcRegisterContext SpecialContext
        {
            get
            {
                SvcRegisterContext specialContextResult;
                TryGetSpecialContext(out specialContextResult).ThrowDbgEngNotOK();

                return specialContextResult;
            }
        }

        public HRESULT TryGetSpecialContext(out SvcRegisterContext specialContextResult)
        {
            /*HRESULT GetSpecialContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext specialContext);*/
            ISvcRegisterContext specialContext;
            HRESULT hr = Raw.GetSpecialContext(out specialContext);

            if (hr == HRESULT.S_OK)
                specialContextResult = specialContext == null ? null : new SvcRegisterContext(specialContext);
            else
                specialContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region ProcessorNumber

        public long ProcessorNumber
        {
            get
            {
                /*long GetProcessorNumber();*/
                return Raw.GetProcessorNumber();
            }
        }

        #endregion
        #endregion
    }
}
