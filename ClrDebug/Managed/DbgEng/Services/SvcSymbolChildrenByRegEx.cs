namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports the enumeration of children by regular expression supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// This interface should be considered *OPTIONAL* -- even in the presence of ISvcSymbolChildren. It is intended for providers which can provide for optimization of regular expression lookups.
    /// </summary>
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

        /// <summary>
        /// Enumerates all children of the given symbol whose name matches a given regular expression.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateChildrenByRegEx(SvcSymbolKind kind, string regEx, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateChildrenByRegEx(kind, regEx, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        /// <summary>
        /// Enumerates all children of the given symbol whose name matches a given regular expression.
        /// </summary>
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
