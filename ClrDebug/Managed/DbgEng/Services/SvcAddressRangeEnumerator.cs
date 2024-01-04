namespace ClrDebug.DbgEng
{
    public class SvcAddressRangeEnumerator : ComObject<ISvcAddressRangeEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcAddressRangeEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcAddressRangeEnumerator(ISvcAddressRangeEnumerator raw) : base(raw)
        {
        }

        #region ISvcAddressRangeEnumerator
        #region Next

        public SvcAddressRange Next
        {
            get
            {
                SvcAddressRange pAddressRange;
                TryGetNext(out pAddressRange).ThrowDbgEngNotOK();

                return pAddressRange;
            }
        }

        public HRESULT TryGetNext(out SvcAddressRange pAddressRange)
        {
            /*HRESULT GetNext(
            [Out] out SvcAddressRange pAddressRange);*/
            return Raw.GetNext(out pAddressRange);
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
