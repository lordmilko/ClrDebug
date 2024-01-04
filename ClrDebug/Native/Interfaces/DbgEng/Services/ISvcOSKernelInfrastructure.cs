using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("92F3C9F5-5B7B-4202-8163-44D86E4C051E")]
    [ComImport]
    public interface ISvcOSKernelInfrastructure
    {
        [PreserveSig]
        HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out long pDirectoryBase);
        
        [PreserveSig]
        HRESULT GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out int pPagingLevels);
        
        [PreserveSig]
        HRESULT GetExecutionState(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pProcessor,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread ppExecutingThread,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppExecutingProcess);
    }
}
