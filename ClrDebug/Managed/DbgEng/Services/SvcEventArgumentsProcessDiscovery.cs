namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsProcessDiscovery : ComObject<ISvcEventArgumentsProcessDiscovery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsProcessDiscovery"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsProcessDiscovery(ISvcEventArgumentsProcessDiscovery raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsProcessDiscovery
        #region Process

        /// <summary>
        /// Gets the process which is (dis)appearing. For a process arrival event, the returned process must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a process disappearance event, the interfaces on the returned module *MUST* continue to operate as if the process were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the process may be considered detached/orphaned for anyone continuing to hold the ISvcProcess interface.
        /// </summary>
        public SvcProcess Process
        {
            get
            {
                SvcProcess processResult;
                TryGetProcess(out processResult).ThrowDbgEngNotOK();

                return processResult;
            }
        }

        /// <summary>
        /// Gets the process which is (dis)appearing. For a process arrival event, the returned process must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a process disappearance event, the interfaces on the returned module *MUST* continue to operate as if the process were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the process may be considered detached/orphaned for anyone continuing to hold the ISvcProcess interface.
        /// </summary>
        public HRESULT TryGetProcess(out SvcProcess processResult)
        {
            /*HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);*/
            ISvcProcess process;
            HRESULT hr = Raw.GetProcess(out process);

            if (hr == HRESULT.S_OK)
                processResult = process == null ? null : new SvcProcess(process);
            else
                processResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #region ExitCode

        /// <summary>
        /// Gets the exit code of the process. This may only be called for a process exit event. It returns E_ILLEGAL_METHOD_CALL for a process arrival event.
        /// </summary>
        public long ExitCode
        {
            get
            {
                long exitCode;
                TryGetExitCode(out exitCode).ThrowDbgEngNotOK();

                return exitCode;
            }
        }

        /// <summary>
        /// Gets the exit code of the process. This may only be called for a process exit event. It returns E_ILLEGAL_METHOD_CALL for a process arrival event.
        /// </summary>
        public HRESULT TryGetExitCode(out long exitCode)
        {
            /*HRESULT GetExitCode(
            [Out] out long exitCode);*/
            return Raw.GetExitCode(out exitCode);
        }

        #endregion
        #endregion
    }
}
