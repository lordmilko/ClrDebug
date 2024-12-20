using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_KERNELINFRASTRUCTURE.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("92F3C9F5-5B7B-4202-8163-44D86E4C051E")]
    [ComImport]
    public interface ISvcOSKernelInfrastructure
    {
        /// <summary>
        /// Gets the pointer to the top level paging structures for a particular process (e.g.: The PDE base that would go into CR3 on AMD64).<para/>
        /// If these structures are not in memory, an error will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out long pDirectoryBase);

        /// <summary>
        /// Gets the number of paging levels that a particular process will use.
        /// </summary>
        [PreserveSig]
        HRESULT GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out int pPagingLevels);

        /// <summary>
        /// For a hardware execution unit (a CPU), return information about the process/thread that is running on that particular CPU.
        /// </summary>
        [PreserveSig]
        HRESULT GetExecutionState(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pProcessor,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread ppExecutingThread,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppExecutingProcess);
    }
}
