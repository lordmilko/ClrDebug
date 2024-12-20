using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A symbol provider which implements a full name index can implement this interface on symbols (and scopes) in order to speed certain classes of name lookups.<para/>
    /// This interface is **ENTIRELY OPTIONAL**. Symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// Symbol providers which implement this interface **MUST** also implement ISvcSymbolChildren on any object which implements ISvcSymbolNameIndexedDescendents.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B76E15E2-132E-42ED-9EFA-D798ED6EA6A5")]
    [ComImport]
    public interface ISvcSymbolNameIndexedDescendents
    {
        /// <summary>
        /// Enumerates the sub-tree rooted at the object implementing this interface for search criteria similar to ISvcSymbolChildren::EnumerateChildren.<para/>
        /// This method, however, enumerates all of the descendents of the given node and either returns immediate children which contain a match in their sub-tree (IndexSearchContainingImmediateChildren) or returns descendents in the sub-tree which are a match but are not necessarily immediate children (IndexSearchDescendents).<para/>
        /// This method may return E_NOTIMPL in a variety of cases. Some symbol providers may support general name indexed query but not qualified name indexed query, for instance.<para/>
        /// In such cases, E_NOTIMPL indicates that the given type of query is not supported. The caller must go back to utilization of ISvcSymbolChildren.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateIndexedDescendents(
            [In] SvcSymbolKind kind,
            [In] IndexSearchFlags searchFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
