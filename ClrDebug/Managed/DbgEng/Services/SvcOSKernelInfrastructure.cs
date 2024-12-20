namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_KERNELINFRASTRUCTURE.
    /// </summary>
    public class SvcOSKernelInfrastructure : ComObject<ISvcOSKernelInfrastructure>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSKernelInfrastructure"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSKernelInfrastructure(ISvcOSKernelInfrastructure raw) : base(raw)
        {
        }

        #region ISvcOSKernelInfrastructure
        #region GetDirectoryBase

        /// <summary>
        /// Gets the pointer to the top level paging structures for a particular process (e.g.: The PDE base that would go into CR3 on AMD64).<para/>
        /// If these structures are not in memory, an error will be returned.
        /// </summary>
        public long GetDirectoryBase(DirectoryBaseKind dirKind, ISvcProcess pProcess)
        {
            long pDirectoryBase;
            TryGetDirectoryBase(dirKind, pProcess, out pDirectoryBase).ThrowDbgEngNotOK();

            return pDirectoryBase;
        }

        /// <summary>
        /// Gets the pointer to the top level paging structures for a particular process (e.g.: The PDE base that would go into CR3 on AMD64).<para/>
        /// If these structures are not in memory, an error will be returned.
        /// </summary>
        public HRESULT TryGetDirectoryBase(DirectoryBaseKind dirKind, ISvcProcess pProcess, out long pDirectoryBase)
        {
            /*HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out long pDirectoryBase);*/
            return Raw.GetDirectoryBase(dirKind, pProcess, out pDirectoryBase);
        }

        #endregion
        #region GetPagingLevels

        /// <summary>
        /// Gets the number of paging levels that a particular process will use.
        /// </summary>
        public int GetPagingLevels(ISvcProcess pProcess)
        {
            int pPagingLevels;
            TryGetPagingLevels(pProcess, out pPagingLevels).ThrowDbgEngNotOK();

            return pPagingLevels;
        }

        /// <summary>
        /// Gets the number of paging levels that a particular process will use.
        /// </summary>
        public HRESULT TryGetPagingLevels(ISvcProcess pProcess, out int pPagingLevels)
        {
            /*HRESULT GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out int pPagingLevels);*/
            return Raw.GetPagingLevels(pProcess, out pPagingLevels);
        }

        #endregion
        #region GetExecutionState

        /// <summary>
        /// For a hardware execution unit (a CPU), return information about the process/thread that is running on that particular CPU.
        /// </summary>
        public GetExecutionStateResult GetExecutionState(ISvcExecutionUnit pProcessor)
        {
            GetExecutionStateResult result;
            TryGetExecutionState(pProcessor, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// For a hardware execution unit (a CPU), return information about the process/thread that is running on that particular CPU.
        /// </summary>
        public HRESULT TryGetExecutionState(ISvcExecutionUnit pProcessor, out GetExecutionStateResult result)
        {
            /*HRESULT GetExecutionState(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pProcessor,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread ppExecutingThread,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppExecutingProcess);*/
            ISvcThread ppExecutingThread;
            ISvcProcess ppExecutingProcess;
            HRESULT hr = Raw.GetExecutionState(pProcessor, out ppExecutingThread, out ppExecutingProcess);

            if (hr == HRESULT.S_OK)
                result = new GetExecutionStateResult(ppExecutingThread == null ? null : new SvcThread(ppExecutingThread), ppExecutingProcess == null ? null : new SvcProcess(ppExecutingProcess));
            else
                result = default(GetExecutionStateResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
