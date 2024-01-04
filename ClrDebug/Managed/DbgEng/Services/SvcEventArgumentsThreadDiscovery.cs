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

        public SvcThread Thread
        {
            get
            {
                SvcThread threadResult;
                TryGetThread(out threadResult).ThrowDbgEngNotOK();

                return threadResult;
            }
        }

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

        public long ExitCode
        {
            get
            {
                long exitCode;
                TryGetExitCode(out exitCode).ThrowDbgEngNotOK();

                return exitCode;
            }
        }

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
