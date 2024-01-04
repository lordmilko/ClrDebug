using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9F5A718-E130-46C2-AECD-D66C557027B8")]
    [ComImport]
    public interface ISvcDebugSourceFileInformation
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string fileName);
        
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string filePath);
        
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long fileSize);
    }
}
