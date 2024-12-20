using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports the enumeration of children by regular expression supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// This interface should be considered *OPTIONAL* -- even in the presence of ISvcSymbolChildren. It is intended for providers which can provide for optimization of regular expression lookups.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("92E1C85D-C0FB-4F37-8961-F6EF486BDF09")]
    [ComImport]
    public interface ISvcSymbolChildrenByRegEx
    {
        /// <summary>
        /// Enumerates all children of the given symbol whose name matches a given regular expression.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateChildrenByRegEx(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string regEx,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
