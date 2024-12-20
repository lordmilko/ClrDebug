namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports the enumeration of children supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.
    /// </summary>
    public class SvcSymbolChildren : ComObject<ISvcSymbolChildren>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolChildren"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolChildren(ISvcSymbolChildren raw) : base(raw)
        {
        }

        #region ISvcSymbolChildren
        #region EnumerateChildren

        /// <summary>
        /// Enumerates all children of the given symbol.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateChildren(SvcSymbolKind kind, string name, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateChildren(kind, name, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        /// <summary>
        /// Enumerates all children of the given symbol.
        /// </summary>
        public HRESULT TryEnumerateChildren(SvcSymbolKind kind, string name, SvcSymbolSearchInfo pSearchInfo, out SvcSymbolSetEnumerator childEnumResult)
        {
            /*HRESULT EnumerateChildren(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);*/
            ISvcSymbolSetEnumerator childEnum;
            HRESULT hr = Raw.EnumerateChildren(kind, name, ref pSearchInfo, out childEnum);

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
