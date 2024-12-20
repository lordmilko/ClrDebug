using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports the enumeration of children supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1B4FF8B8-BD87-43A2-8D53-C747C77716E0")]
    [ComImport]
    public interface ISvcSymbolChildren
    {
        /// <summary>
        /// Enumerates all children of the given symbol.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateChildren(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
