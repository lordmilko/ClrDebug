using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FFD73BA2-D7E9-442D-ADA6-4EF1B07D951F")]
    [ComImport]
    public interface ISvcSymbolSetSimpleSourceFileInformation
    {
        [PreserveSig]
        HRESULT GetSourceFileById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile sourceFile);
        
        [PreserveSig]
        HRESULT EnumerateSourceFiles(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFileEnumerator sourceFileEnum);
    }
}
