namespace ClrDebug.DbgEng
{
    public class SvcRegisterEnumerator : ComObject<ISvcRegisterEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterEnumerator(ISvcRegisterEnumerator raw) : base(raw)
        {
        }

        #region ISvcRegisterEnumerator
        #region Next

        /// <summary>
        /// Gets the next register for the architecture. Returns E_BOUNDS if there are no more.
        /// </summary>
        public SvcRegisterInformation Next
        {
            get
            {
                SvcRegisterInformation registerInfoResult;
                TryGetNext(out registerInfoResult).ThrowDbgEngNotOK();

                return registerInfoResult;
            }
        }

        /// <summary>
        /// Gets the next register for the architecture. Returns E_BOUNDS if there are no more.
        /// </summary>
        public HRESULT TryGetNext(out SvcRegisterInformation registerInfoResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInfo);*/
            ISvcRegisterInformation registerInfo;
            HRESULT hr = Raw.GetNext(out registerInfo);

            if (hr == HRESULT.S_OK)
                registerInfoResult = registerInfo == null ? null : new SvcRegisterInformation(registerInfo);
            else
                registerInfoResult = default(SvcRegisterInformation);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
