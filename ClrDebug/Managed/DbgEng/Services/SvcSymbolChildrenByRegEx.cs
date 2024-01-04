namespace ClrDebug.DbgEng
{
    public class SvcSymbolChildrenByRegEx : ComObject<ISvcSymbolChildrenByRegEx>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolChildrenByRegEx"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolChildrenByRegEx(ISvcSymbolChildrenByRegEx raw) : base(raw)
        {
        }

        #region ISvcSymbolChildrenByRegEx
        #region EnumerateChildrenByRegEx

        public SvcSymbolSetEnumerator EnumerateChildrenByRegEx(SvcSymbolKind kind, string regEx, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateChildrenByRegEx(kind, regEx, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        public HRESULT TryEnumerateChildrenByRegEx(SvcSymbolKind kind, string regEx, SvcSymbolSearchInfo pSearchInfo, out SvcSymbolSetEnumerator childEnumResult)
        {
            /*HRESULT EnumerateChildrenByRegEx(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string regEx,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);*/
            ISvcSymbolSetEnumerator childEnum;
            HRESULT hr = Raw.EnumerateChildrenByRegEx(kind, regEx, ref pSearchInfo, out childEnum);

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
