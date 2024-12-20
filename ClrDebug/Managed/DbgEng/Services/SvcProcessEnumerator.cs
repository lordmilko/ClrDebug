namespace ClrDebug.DbgEng
{
    public class SvcProcessEnumerator : ComObject<ISvcProcessEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcProcessEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcProcessEnumerator(ISvcProcessEnumerator raw) : base(raw)
        {
        }

        #region ISvcProcessEnumerator
        #region Next

        /// <summary>
        /// Gets the next process from the enumerator.
        /// </summary>
        public SvcProcess Next
        {
            get
            {
                SvcProcess targetProcessResult;
                TryGetNext(out targetProcessResult).ThrowDbgEngNotOK();

                return targetProcessResult;
            }
        }

        /// <summary>
        /// Gets the next process from the enumerator.
        /// </summary>
        public HRESULT TryGetNext(out SvcProcess targetProcessResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess targetProcess);*/
            ISvcProcess targetProcess;
            HRESULT hr = Raw.GetNext(out targetProcess);

            if (hr == HRESULT.S_OK)
                targetProcessResult = targetProcess == null ? null : new SvcProcess(targetProcess);
            else
                targetProcessResult = default(SvcProcess);

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
