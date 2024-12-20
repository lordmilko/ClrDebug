namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsThreadDiscovery : ComObject<ISvcEventArgumentsThreadDiscovery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsThreadDiscovery"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsThreadDiscovery(ISvcEventArgumentsThreadDiscovery raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsThreadDiscovery
        #region Thread

        /// <summary>
        /// Gets the thread which is (dis)appearing. For a thread arrival event, the returned thread must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a thread disappearance event, the interfaces on the returned thread *MUST* continue to operate as if the thread were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the thread may be considered detached/orphaned for anyone continuing to hold the ISvcThread interface.
        /// </summary>
        public SvcThread Thread
        {
            get
            {
                SvcThread threadResult;
                TryGetThread(out threadResult).ThrowDbgEngNotOK();

                return threadResult;
            }
        }

        /// <summary>
        /// Gets the thread which is (dis)appearing. For a thread arrival event, the returned thread must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a thread disappearance event, the interfaces on the returned thread *MUST* continue to operate as if the thread were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the thread may be considered detached/orphaned for anyone continuing to hold the ISvcThread interface.
        /// </summary>
        public HRESULT TryGetThread(out SvcThread threadResult)
        {
            /*HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);*/
            ISvcThread thread;
            HRESULT hr = Raw.GetThread(out thread);

            if (hr == HRESULT.S_OK)
                threadResult = thread == null ? null : new SvcThread(thread);
            else
                threadResult = default(SvcThread);

            return hr;
        }

        #endregion
        #region ExitCode

        /// <summary>
        /// Gets the exit code of the thread. This may only be called for a thread exit event. It returns E_ILLEGAL_METHOD_CALL for a thread arrival event.
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
        /// Gets the exit code of the thread. This may only be called for a thread exit event. It returns E_ILLEGAL_METHOD_CALL for a thread arrival event.
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
