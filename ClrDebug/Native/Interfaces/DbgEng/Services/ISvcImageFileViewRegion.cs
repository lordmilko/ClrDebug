using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E9BF1356-BA52-4B57-887F-2998499D5DCB")]
    [ComImport]
    public interface ISvcImageFileViewRegion
    {
        [PreserveSig]
        long GetFileOffset();
        
        [PreserveSig]
        long GetSize();
        
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRegionName);
        
        [PreserveSig]
        HRESULT GetMemoryViewAssociation(
            [Out] out long pMemoryViewOffset,
            [Out] out long pMemoryViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);
    }
}
