using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B751FDDF-3B41-4F4B-9EFE-EA310EEFE8D2")]
    [ComImport]
    public interface ISvcProcessConnector
    {
        [PreserveSig]
        HRESULT EnumerateConnectableProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcessEnumerator connectableProcessEnum);
        
        [PreserveSig]
        HRESULT AttachProcess(
            [In] long pid,
            [In] SvcAttachFlags attachFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);
        
        [PreserveSig]
        HRESULT CreateProcess(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executablePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string commandLine,
            [In] SvcAttachFlags attachFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string workingDirectory,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);
    }
}
