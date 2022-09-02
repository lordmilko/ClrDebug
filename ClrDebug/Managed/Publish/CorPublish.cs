namespace ClrDebug
{
    /// <summary>
    /// Serves as the general interface for publishing information about processes and information about the application domains in those processes.
    /// </summary>
    public class CorPublish : ComObject<ICorPublish>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublish"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorPublish(ICorPublish raw) : base(raw)
        {
        }

        #region ICorPublish
        #region EnumProcesses

        /// <summary>
        /// Gets an enumerator for the managed processes running on this computer.
        /// </summary>
        /// <param name="type">A value of the <see cref="COR_PUB_ENUMPROCESS"/> enumeration that specifies the type of process to be retrieved.<para/>
        /// In the current version, only COR_PUB_MANAGEDONLY is valid.</param>
        /// <returns>A pointer to the address of an <see cref="ICorPublishProcessEnum"/> instance that is the enumerator of the processes.</returns>
        /// <remarks>
        /// The enumerator's collection of processes is based on a snapshot of the processes that are running when the EnumProcesses
        /// method is called. The enumerator will not include any processes that terminate before or start after EnumProcesses
        /// is called. The EnumProcesses method may be called more than once on this <see cref="ICorPublish"/> instance to
        /// create a new up-to-date collection of processes. Existing collections will not be affected by subsequent calls
        /// of the EnumProcesses method.
        /// </remarks>
        public CorPublishProcessEnum EnumProcesses(COR_PUB_ENUMPROCESS type)
        {
            CorPublishProcessEnum ppIEnumResult;
            TryEnumProcesses(type, out ppIEnumResult).ThrowOnNotOK();

            return ppIEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for the managed processes running on this computer.
        /// </summary>
        /// <param name="type">A value of the <see cref="COR_PUB_ENUMPROCESS"/> enumeration that specifies the type of process to be retrieved.<para/>
        /// In the current version, only COR_PUB_MANAGEDONLY is valid.</param>
        /// <param name="ppIEnumResult">A pointer to the address of an <see cref="ICorPublishProcessEnum"/> instance that is the enumerator of the processes.</param>
        /// <remarks>
        /// The enumerator's collection of processes is based on a snapshot of the processes that are running when the EnumProcesses
        /// method is called. The enumerator will not include any processes that terminate before or start after EnumProcesses
        /// is called. The EnumProcesses method may be called more than once on this <see cref="ICorPublish"/> instance to
        /// create a new up-to-date collection of processes. Existing collections will not be affected by subsequent calls
        /// of the EnumProcesses method.
        /// </remarks>
        public HRESULT TryEnumProcesses(COR_PUB_ENUMPROCESS type, out CorPublishProcessEnum ppIEnumResult)
        {
            /*HRESULT EnumProcesses(
            [In] COR_PUB_ENUMPROCESS Type,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcessEnum ppIEnum);*/
            ICorPublishProcessEnum ppIEnum;
            HRESULT hr = Raw.EnumProcesses(type, out ppIEnum);

            if (hr == HRESULT.S_OK)
                ppIEnumResult = new CorPublishProcessEnum(ppIEnum);
            else
                ppIEnumResult = default(CorPublishProcessEnum);

            return hr;
        }

        #endregion
        #region GetProcess

        /// <summary>
        /// Gets an <see cref="ICorPublishProcess"/> instance that represents the process with the specified identifier.
        /// </summary>
        /// <param name="pid">[in] The identifier of the process.</param>
        /// <returns>[out] A pointer to the address of an ICorPublishProcess instance that represents the process.</returns>
        /// <remarks>
        /// GetProcess fails if the process doesn't exist, or isn't a managed process that can be debugged by the current user.
        /// </remarks>
        public CorPublishProcess GetProcess(int pid)
        {
            CorPublishProcess ppProcessResult;
            TryGetProcess(pid, out ppProcessResult).ThrowOnNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Gets an <see cref="ICorPublishProcess"/> instance that represents the process with the specified identifier.
        /// </summary>
        /// <param name="pid">[in] The identifier of the process.</param>
        /// <param name="ppProcessResult">[out] A pointer to the address of an ICorPublishProcess instance that represents the process.</param>
        /// <remarks>
        /// GetProcess fails if the process doesn't exist, or isn't a managed process that can be debugged by the current user.
        /// </remarks>
        public HRESULT TryGetProcess(int pid, out CorPublishProcess ppProcessResult)
        {
            /*HRESULT GetProcess(
            [In] int pid,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess ppProcess);*/
            ICorPublishProcess ppProcess;
            HRESULT hr = Raw.GetProcess(pid, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorPublishProcess(ppProcess);
            else
                ppProcessResult = default(CorPublishProcess);

            return hr;
        }

        #endregion
        #endregion
    }
}
