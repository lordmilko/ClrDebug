using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("51A92871-F1D1-4DA2-9805-75A41731D636")]
    [ComImport]
    public interface ISvcEventArgumentsThreadDiscovery
    {
        [PreserveSig]
        HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);
        
        [PreserveSig]
        HRESULT GetExitCode(
            [Out] out long exitCode);
    }
}
