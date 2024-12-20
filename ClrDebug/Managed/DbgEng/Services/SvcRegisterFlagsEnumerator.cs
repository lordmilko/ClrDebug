namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterFlagsEnumerator interface enumerates the flags bits of a flags register.
    /// </summary>
    public class SvcRegisterFlagsEnumerator : ComObject<ISvcRegisterFlagsEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterFlagsEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterFlagsEnumerator(ISvcRegisterFlagsEnumerator raw) : base(raw)
        {
        }

        #region ISvcRegisterFlagsEnumerator
        #region Next

        /// <summary>
        /// Gets the next flag in the register. Returns E_BOUNDS if there are no more.
        /// </summary>
        public SvcRegisterFlagInformation Next
        {
            get
            {
                SvcRegisterFlagInformation flagInfoResult;
                TryGetNext(out flagInfoResult).ThrowDbgEngNotOK();

                return flagInfoResult;
            }
        }

        /// <summary>
        /// Gets the next flag in the register. Returns E_BOUNDS if there are no more.
        /// </summary>
        public HRESULT TryGetNext(out SvcRegisterFlagInformation flagInfoResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);*/
            ISvcRegisterFlagInformation flagInfo;
            HRESULT hr = Raw.GetNext(out flagInfo);

            if (hr == HRESULT.S_OK)
                flagInfoResult = flagInfo == null ? null : new SvcRegisterFlagInformation(flagInfo);
            else
                flagInfoResult = default(SvcRegisterFlagInformation);

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
