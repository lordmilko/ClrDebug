using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B76E15E2-132E-42ED-9EFA-D798ED6EA6A5")]
    [ComImport]
    public interface ISvcSymbolNameIndexedDescendents
    {
        [PreserveSig]
        HRESULT EnumerateIndexedDescendents(
            [In] SvcSymbolKind kind,
            [In] IndexSearchFlags searchFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
