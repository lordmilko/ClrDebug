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

        public SvcProcess Process
        {
            get
            {
                SvcProcess processResult;
                TryGetProcess(out processResult).ThrowDbgEngNotOK();

                return processResult;
            }
        }

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
