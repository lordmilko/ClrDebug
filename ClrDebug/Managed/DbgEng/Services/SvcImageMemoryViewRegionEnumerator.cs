namespace ClrDebug.DbgEng
{
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

        public SvcImageMemoryViewRegion Next
        {
            get
            {
                SvcImageMemoryViewRegion ppRegionResult;
                TryGetNext(out ppRegionResult).ThrowDbgEngNotOK();

                return ppRegionResult;
            }
        }

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
