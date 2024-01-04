using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("92E1C85D-C0FB-4F37-8961-F6EF486BDF09")]
    [ComImport]
    public interface ISvcSymbolChildrenByRegEx
    {
        [PreserveSig]
        HRESULT EnumerateChildrenByRegEx(
            [In] SvcSymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string regEx,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator childEnum);
    }
}
