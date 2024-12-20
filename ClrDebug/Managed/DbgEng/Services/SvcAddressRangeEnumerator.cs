namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates a set of one or more address ranges.
    /// </summary>
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

        /// <summary>
        /// Gets the next address range from the enumerator.
        /// </summary>
        public SvcAddressRange Next
        {
            get
            {
                SvcAddressRange pAddressRange;
                TryGetNext(out pAddressRange).ThrowDbgEngNotOK();

                return pAddressRange;
            }
        }

        /// <summary>
        /// Gets the next address range from the enumerator.
        /// </summary>
        public HRESULT TryGetNext(out SvcAddressRange pAddressRange)
        {
            /*HRESULT GetNext(
            [Out] out SvcAddressRange pAddressRange);*/
            return Raw.GetNext(out pAddressRange);
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
