using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0DF8C531-ECA0-48F3-94BB-0964EC6EE3F0")]
    [ComImport]
    public interface ISvcImageMemoryViewRegion
    {
        [PreserveSig]
        long GetMemoryOffset();
        
        [PreserveSig]
        long GetSize();
        
        [PreserveSig]
        long GetId();
        
        [PreserveSig]
        HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);
        
        [PreserveSig]
        HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);
        
        [PreserveSig]
        HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);
        
        [PreserveSig]
        HRESULT GetAlignment(
            [Out] out int Alignment);
        
        [PreserveSig]
        HRESULT GetFileViewAssociation(
            [Out] out long pFileViewOffset,
            [Out] out long pFileViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);
    }
}
