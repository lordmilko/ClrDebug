using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1B4FF8B8-BD87-43A2-8D53-C747C77716E0")]
    [ComImport]
    public interface ISvcSymbolChildren
    {
        [PreserveSig]
        HRESULT EnumerateChildren(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
