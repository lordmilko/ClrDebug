namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates address regions.
    /// </summary>
    public class SvcMemoryRegionEnumerator : ComObject<ISvcMemoryRegionEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMemoryRegionEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMemoryRegionEnumerator(ISvcMemoryRegionEnumerator raw) : base(raw)
        {
        }

        #region ISvcMemoryRegionEnumerator
        #region Next

        /// <summary>
        /// Gets the next memory region.
        /// </summary>
        public SvcMemoryRegion Next
        {
            get
            {
                SvcMemoryRegion regionResult;
                TryGetNext(out regionResult).ThrowDbgEngNotOK();

                return regionResult;
            }
        }

        /// <summary>
        /// Gets the next memory region.
        /// </summary>
        public HRESULT TryGetNext(out SvcMemoryRegion regionResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);*/
            ISvcMemoryRegion region;
            HRESULT hr = Raw.GetNext(out region);

            if (hr == HRESULT.S_OK)
                regionResult = region == null ? null : new SvcMemoryRegion(region);
            else
                regionResult = default(SvcMemoryRegion);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator back to its initial creation state.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator back to its initial creation state.
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
