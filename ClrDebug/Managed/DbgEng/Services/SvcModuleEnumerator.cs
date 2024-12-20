namespace ClrDebug.DbgEng
{
    public class SvcModuleEnumerator : ComObject<ISvcModuleEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcModuleEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcModuleEnumerator(ISvcModuleEnumerator raw) : base(raw)
        {
        }

        #region ISvcModuleEnumerator
        #region Next

        /// <summary>
        /// Gets the next module from the enumerator.
        /// </summary>
        public SvcModule Next
        {
            get
            {
                SvcModule targetModuleResult;
                TryGetNext(out targetModuleResult).ThrowDbgEngNotOK();

                return targetModuleResult;
            }
        }

        /// <summary>
        /// Gets the next module from the enumerator.
        /// </summary>
        public HRESULT TryGetNext(out SvcModule targetModuleResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);*/
            ISvcModule targetModule;
            HRESULT hr = Raw.GetNext(out targetModule);

            if (hr == HRESULT.S_OK)
                targetModuleResult = SvcModule.New(targetModule);
            else
                targetModuleResult = default(SvcModule);

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
