namespace ClrDebug.DbgEng
{
    public class SvcConnectableProcessEnumerator : ComObject<ISvcConnectableProcessEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcConnectableProcessEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcConnectableProcessEnumerator(ISvcConnectableProcessEnumerator raw) : base(raw)
        {
        }

        #region ISvcConnectableProcessEnumerator
        #region Next

        /// <summary>
        /// Gets the next connectable process in the list.
        /// </summary>
        public SvcConnectableProcess Next
        {
            get
            {
                SvcConnectableProcess connectableProcessResult;
                TryGetNext(out connectableProcessResult).ThrowDbgEngNotOK();

                return connectableProcessResult;
            }
        }

        /// <summary>
        /// Gets the next connectable process in the list.
        /// </summary>
        public HRESULT TryGetNext(out SvcConnectableProcess connectableProcessResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcess connectableProcess);*/
            ISvcConnectableProcess connectableProcess;
            HRESULT hr = Raw.GetNext(out connectableProcess);

            if (hr == HRESULT.S_OK)
                connectableProcessResult = connectableProcess == null ? null : new SvcConnectableProcess(connectableProcess);
            else
                connectableProcessResult = default(SvcConnectableProcess);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator to the first process.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator to the first process.
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
