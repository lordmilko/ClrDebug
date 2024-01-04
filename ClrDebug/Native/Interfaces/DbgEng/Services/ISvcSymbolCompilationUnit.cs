using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("14C37CAC-496D-4916-AF75-02345E27DA3E")]
    [ComImport]
    public interface ISvcSymbolCompilationUnit
    {
        [PreserveSig]
        HRESULT GetPrimarySource(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile primarySourceFile);
        
        [PreserveSig]
        HRESULT GetLanguage(
            [Out] out SvcSourceLanguage language,
            [Out] out int version);
        
        [PreserveSig]
        HRESULT GetProducer(
            [Out, MarshalAs(UnmanagedType.BStr)] out string producerString);
    }
}
