namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ISvcImageMemoryRegionEnumerator An enumerator for "memory view regions" of an executable.
    /// </summary>
    public class SvcImageMemoryViewRegionEnumerator : ComObject<ISvcImageMemoryViewRegionEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageMemoryViewRegionEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageMemoryViewRegionEnumerator(ISvcImageMemoryViewRegionEnumerator raw) : base(raw)
        {
        }

        #region ISvcImageMemoryViewRegionEnumerator
        #region Next

        /// <summary>
        /// Gets the next "memory view region".
        /// </summary>
        public SvcImageMemoryViewRegion Next
        {
            get
            {
                SvcImageMemoryViewRegion ppRegionResult;
                TryGetNext(out ppRegionResult).ThrowDbgEngNotOK();

                return ppRegionResult;
            }
        }

        /// <summary>
        /// Gets the next "memory view region".
        /// </summary>
        public HRESULT TryGetNext(out SvcImageMemoryViewRegion ppRegionResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);*/
            ISvcImageMemoryViewRegion ppRegion;
            HRESULT hr = Raw.GetNext(out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageMemoryViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageMemoryViewRegion);

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
