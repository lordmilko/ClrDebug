namespace ClrDebug.DbgEng
{
    public class SvcSymbolRegExIndexedDescendents : ComObject<ISvcSymbolRegExIndexedDescendents>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolRegExIndexedDescendents"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolRegExIndexedDescendents(ISvcSymbolRegExIndexedDescendents raw) : base(raw)
        {
        }

        #region ISvcSymbolRegExIndexedDescendents
        #region EnumerateIndexedDescendentsByRegEx

        public SvcSymbolSetEnumerator EnumerateIndexedDescendentsByRegEx(SvcSymbolKind kind, IndexSearchFlags searchFlags, string regEx, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateIndexedDescendentsByRegEx(kind, searchFlags, regEx, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        public HRESULT TryEnumerateIndexedDescendentsByRegEx(SvcSymbolKind kind, IndexSearchFlags searchFlags, string regEx, SvcSymbolSearchInfo pSearchInfo, out SvcSymbolSetEnumerator childEnumResult)
        {
            /*HRESULT EnumerateIndexedDescendentsByRegEx(
            [In] SvcSymbolKind kind,
            [In] IndexSearchFlags searchFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string regEx,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);*/
            ISvcSymbolSetEnumerator childEnum;
            HRESULT hr = Raw.EnumerateIndexedDescendentsByRegEx(kind, searchFlags, regEx, ref pSearchInfo, out childEnum);

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
