using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("91DC29CD-F06E-46FE-8C5F-AC6787B79C6E")]
    [ComImport]
    public interface ISvcSymbolCompilationUnitSources
    {
        [PreserveSig]
        HRESULT EnumerateSourceFiles(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFileEnumerator sourceFileEnum);
    }
}
