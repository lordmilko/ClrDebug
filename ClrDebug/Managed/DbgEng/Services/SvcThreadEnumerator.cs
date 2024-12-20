namespace ClrDebug.DbgEng
{
    public class SvcThreadEnumerator : ComObject<ISvcThreadEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcThreadEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcThreadEnumerator(ISvcThreadEnumerator raw) : base(raw)
        {
        }

        #region ISvcThreadEnumerator
        #region Next

        /// <summary>
        /// Gets the next thread from the enumerator.
        /// </summary>
        public SvcThread Next
        {
            get
            {
                SvcThread targetThreadResult;
                TryGetNext(out targetThreadResult).ThrowDbgEngNotOK();

                return targetThreadResult;
            }
        }

        /// <summary>
        /// Gets the next thread from the enumerator.
        /// </summary>
        public HRESULT TryGetNext(out SvcThread targetThreadResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread targetThread);*/
            ISvcThread targetThread;
            HRESULT hr = Raw.GetNext(out targetThread);

            if (hr == HRESULT.S_OK)
                targetThreadResult = targetThread == null ? null : new SvcThread(targetThread);
            else
                targetThreadResult = default(SvcThread);

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
