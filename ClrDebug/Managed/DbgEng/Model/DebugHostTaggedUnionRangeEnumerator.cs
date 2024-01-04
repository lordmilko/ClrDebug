namespace ClrDebug.DbgEng
{
    public class DebugHostTaggedUnionRangeEnumerator : ComObject<IDebugHostTaggedUnionRangeEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostTaggedUnionRangeEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostTaggedUnionRangeEnumerator(IDebugHostTaggedUnionRangeEnumerator raw) : base(raw)
        {
        }

        #region IDebugHostTaggedUnionRangeEnumerator
        #region Next

        public DebugHostTaggedUnionRangeEnumerator_GetNextResult Next
        {
            get
            {
                DebugHostTaggedUnionRangeEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNext(out DebugHostTaggedUnionRangeEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLow,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHigh);*/
            object pLow;
            object pHigh;
            HRESULT hr = Raw.GetNext(out pLow, out pHigh);

            if (hr == HRESULT.S_OK)
                result = new DebugHostTaggedUnionRangeEnumerator_GetNextResult(pLow, pHigh);
            else
                result = default(DebugHostTaggedUnionRangeEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Count

        public int Count
        {
            get
            {
                int pCount;
                TryGetCount(out pCount).ThrowDbgEngNotOK();

                return pCount;
            }
        }

        public HRESULT TryGetCount(out int pCount)
        {
            /*HRESULT GetCount(
            [Out] out int pCount);*/
            return Raw.GetCount(out pCount);
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
