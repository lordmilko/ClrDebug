namespace ClrDebug.DbgEng
{
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

        public SvcImageFileViewRegion Next
        {
            get
            {
                SvcImageFileViewRegion ppRegionResult;
                TryGetNext(out ppRegionResult).ThrowDbgEngNotOK();

                return ppRegionResult;
            }
        }

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
