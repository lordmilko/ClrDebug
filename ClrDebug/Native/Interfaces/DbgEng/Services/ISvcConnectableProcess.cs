using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0CA4DC6B-1070-4AA1-8C6C-1F626962A475")]
    [ComImport]
    public interface ISvcConnectableProcess
    {
        [PreserveSig]
        HRESULT GetExecutablePath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executablePath);
        
        [PreserveSig]
        HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executableArguments);
        
        [PreserveSig]
        HRESULT GetId(
            [Out] out long processId);
        
        [PreserveSig]
        HRESULT GetUser(
            [Out, MarshalAs(UnmanagedType.BStr)] out string user);
    }
}
