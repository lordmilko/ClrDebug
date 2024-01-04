using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8F815608-A145-4CF9-8488-9E0EAEA1F2B9")]
    [ComImport]
    public interface ISvcEventArgumentsProcessDiscovery
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);
        
        [PreserveSig]
        HRESULT GetExitCode(
            [Out] out long exitCode);
    }
}
