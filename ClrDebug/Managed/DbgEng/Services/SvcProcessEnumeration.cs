namespace ClrDebug.DbgEng
{
    public class SvcProcessEnumeration : ComObject<ISvcProcessEnumeration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcProcessEnumeration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcProcessEnumeration(ISvcProcessEnumeration raw) : base(raw)
        {
        }

        #region ISvcProcessEnumeration
        #region FindProcess

        public SvcProcess FindProcess(long processKey)
        {
            SvcProcess targetProcessResult;
            TryFindProcess(processKey, out targetProcessResult).ThrowDbgEngNotOK();

            return targetProcessResult;
        }

        public HRESULT TryFindProcess(long processKey, out SvcProcess targetProcessResult)
        {
            /*HRESULT FindProcess(
            [In] long processKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess targetProcess);*/
            ISvcProcess targetProcess;
            HRESULT hr = Raw.FindProcess(processKey, out targetProcess);

            if (hr == HRESULT.S_OK)
                targetProcessResult = targetProcess == null ? null : new SvcProcess(targetProcess);
            else
                targetProcessResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #region EnumerateProcesses

        public SvcProcessEnumerator EnumerateProcesses()
        {
            SvcProcessEnumerator targetProcessEnumeratorResult;
            TryEnumerateProcesses(out targetProcessEnumeratorResult).ThrowDbgEngNotOK();

            return targetProcessEnumeratorResult;
        }

        public HRESULT TryEnumerateProcesses(out SvcProcessEnumerator targetProcessEnumeratorResult)
        {
            /*HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcessEnumerator targetProcessEnumerator);*/
            ISvcProcessEnumerator targetProcessEnumerator;
            HRESULT hr = Raw.EnumerateProcesses(out targetProcessEnumerator);

            if (hr == HRESULT.S_OK)
                targetProcessEnumeratorResult = targetProcessEnumerator == null ? null : new SvcProcessEnumerator(targetProcessEnumerator);
            else
                targetProcessEnumeratorResult = default(SvcProcessEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
