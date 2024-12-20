namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator for "file view regions" of an executable.
    /// </summary>
    public class SvcImageFileViewRegionEnumerator : ComObject<ISvcImageFileViewRegionEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageFileViewRegionEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageFileViewRegionEnumerator(ISvcImageFileViewRegionEnumerator raw) : base(raw)
        {
        }

        #region ISvcImageFileViewRegionEnumerator
        #region Next

        /// <summary>
        /// Gets the next "file view region".
        /// </summary>
        public SvcImageFileViewRegion Next
        {
            get
            {
                SvcImageFileViewRegion ppRegionResult;
                TryGetNext(out ppRegionResult).ThrowDbgEngNotOK();

                return ppRegionResult;
            }
        }

        /// <summary>
        /// Gets the next "file view region".
        /// </summary>
        public HRESULT TryGetNext(out SvcImageFileViewRegion ppRegionResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);*/
            ISvcImageFileViewRegion ppRegion;
            HRESULT hr = Raw.GetNext(out ppRegion);

            if (hr == HRESULT.S_OK)
                ppRegionResult = ppRegion == null ? null : new SvcImageFileViewRegion(ppRegion);
            else
                ppRegionResult = default(SvcImageFileViewRegion);

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
