namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A symbol provider which implements a full name index (and also supports regular expression matching against that index) can implement this interface on symbols (and scopes) in order to speed certain classes of name lookups by regular expression.<para/>
    /// This interface is **ENTIRELY OPTIONAL**. Symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// Symbol providers which implement this interface **MUST** also implement ISvcSymbolChildren on any object which implements ISvcSymbolRegExIndexedDescendents.
    /// </summary>
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

        /// <summary>
        /// Enumerates the sub-tree rooted at the object implementing this interface for search criteria similar to ISvcSymbolChildren::EnumerateChildren.<para/>
        /// Names with this method are matched not by a constant string but rather by a regular expression. This method, however, enumerates all of the descendents of the given node and either returns immediate children which contain a match in their sub-tree (IndexSearchContainingImmediateChildren) or returns descendents in the sub-tree which are a match but are not necessarily immediate children (IndexSearchDescendents).<para/>
        /// This method may return E_NOTIMPL in a variety of cases. Some symbol providers may support general name indexed query but not qualified name indexed query, for instance.<para/>
        /// In such cases, E_NOTIMPL indicates that the given type of query is not supported. The caller must go back to utilization of ISvcSymbolChildren.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateIndexedDescendentsByRegEx(SvcSymbolKind kind, IndexSearchFlags searchFlags, string regEx, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSymbolSetEnumerator childEnumResult;
            TryEnumerateIndexedDescendentsByRegEx(kind, searchFlags, regEx, pSearchInfo, out childEnumResult).ThrowDbgEngNotOK();

            return childEnumResult;
        }

        /// <summary>
        /// Enumerates the sub-tree rooted at the object implementing this interface for search criteria similar to ISvcSymbolChildren::EnumerateChildren.<para/>
        /// Names with this method are matched not by a constant string but rather by a regular expression. This method, however, enumerates all of the descendents of the given node and either returns immediate children which contain a match in their sub-tree (IndexSearchContainingImmediateChildren) or returns descendents in the sub-tree which are a match but are not necessarily immediate children (IndexSearchDescendents).<para/>
        /// This method may return E_NOTIMPL in a variety of cases. Some symbol providers may support general name indexed query but not qualified name indexed query, for instance.<para/>
        /// In such cases, E_NOTIMPL indicates that the given type of query is not supported. The caller must go back to utilization of ISvcSymbolChildren.
        /// </summary>
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
