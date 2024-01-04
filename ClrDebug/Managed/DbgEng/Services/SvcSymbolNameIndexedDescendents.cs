namespace ClrDebug.DbgEng
{
    public class SvcSymbolNameIndexedDescendents : ComObject<ISvcSymbolNameIndexedDescendents>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolNameIndexedDescendents"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolNameIndexedDescendents(ISvcSymbolNameIndexedDescendents raw) : base(raw)
        {
        }

        #region ISvcSymbolNameIndexedDescendents
        #region EnumerateIndexedDescendents

        public SvcSymbolSetEnumerator EnumerateIndexedDescendents(SvcSymbolKind kind, IndexSearchFlags searchFlags, string name, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateIndexedDescendents(kind, searchFlags, name, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        public HRESULT TryEnumerateIndexedDescendents(SvcSymbolKind kind, IndexSearchFlags searchFlags, string name, SvcSymbolSearchInfo pSearchInfo, out SvcSymbolSetEnumerator childEnumResult)
        {
            /*HRESULT EnumerateIndexedDescendents(
            [In] SvcSymbolKind kind,
            [In] IndexSearchFlags searchFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);*/
            ISvcSymbolSetEnumerator childEnum;
            HRESULT hr = Raw.EnumerateIndexedDescendents(kind, searchFlags, name, ref pSearchInfo, out childEnum);

            if (hr == HRESULT.S_OK)
                childEnumResult = childEnum == null ? null : new SvcSymbolSetEnumerator(childEnum);
            else
                childEnumResult = default(SvcSymbolSetEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
