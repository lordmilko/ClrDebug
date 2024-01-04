namespace ClrDebug.DbgEng
{
    public class DebugHostFunctionLocalDetailsEnumerator : ComObject<IDebugHostFunctionLocalDetailsEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostFunctionLocalDetailsEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostFunctionLocalDetailsEnumerator(IDebugHostFunctionLocalDetailsEnumerator raw) : base(raw)
        {
        }

        #region IDebugHostFunctionLocalDetailsEnumerator
        #region Next

        public DebugHostFunctionLocalDetails Next
        {
            get
            {
                DebugHostFunctionLocalDetails localDetailsResult;
                TryGetNext(out localDetailsResult).ThrowDbgEngNotOK();

                return localDetailsResult;
            }
        }

        public HRESULT TryGetNext(out DebugHostFunctionLocalDetails localDetailsResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetails localDetails);*/
            IDebugHostFunctionLocalDetails localDetails;
            HRESULT hr = Raw.GetNext(out localDetails);

            if (hr == HRESULT.S_OK)
                localDetailsResult = localDetails == null ? null : new DebugHostFunctionLocalDetails(localDetails);
            else
                localDetailsResult = default(DebugHostFunctionLocalDetails);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
