namespace ClrDebug.DbgEng
{
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

        public long GetDirectoryBase(DirectoryBaseKind dirKind, ISvcProcess pProcess)
        {
            long pDirectoryBase;
            TryGetDirectoryBase(dirKind, pProcess, out pDirectoryBase).ThrowDbgEngNotOK();

            return pDirectoryBase;
        }

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

        public int GetPagingLevels(ISvcProcess pProcess)
        {
            int pPagingLevels;
            TryGetPagingLevels(pProcess, out pPagingLevels).ThrowDbgEngNotOK();

            return pPagingLevels;
        }

        public HRESULT TryGetPagingLevels(ISvcProcess pProcess, out int pPagingLevels)
        {
            /*HRESULT GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out] out int pPagingLevels);*/
            return Raw.GetPagingLevels(pProcess, out pPagingLevels);
        }

        #endregion
        #region GetExecutionState

        public GetExecutionStateResult GetExecutionState(ISvcExecutionUnit pProcessor)
        {
            GetExecutionStateResult result;
            TryGetExecutionState(pProcessor, out result).ThrowDbgEngNotOK();

            return result;
        }

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
