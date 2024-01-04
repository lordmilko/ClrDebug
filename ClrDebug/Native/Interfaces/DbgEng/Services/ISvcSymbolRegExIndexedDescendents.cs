using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EAB8E16C-12F7-4878-8E0E-A59F0B25D4CB")]
    [ComImport]
    public interface ISvcSymbolRegExIndexedDescendents
    {
        [PreserveSig]
        HRESULT EnumerateIndexedDescendentsByRegEx(
            [In] SvcSymbolKind kind,
            [In] IndexSearchFlags searchFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string regEx,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
