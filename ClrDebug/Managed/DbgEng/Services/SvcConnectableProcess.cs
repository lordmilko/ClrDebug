namespace ClrDebug.DbgEng
{
    public class SvcConnectableProcess : ComObject<ISvcConnectableProcess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcConnectableProcess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcConnectableProcess(ISvcConnectableProcess raw) : base(raw)
        {
        }

        #region ISvcConnectableProcess
        #region ExecutablePath

        /// <summary>
        /// Gets the full path to the process executable.
        /// </summary>
        public string ExecutablePath
        {
            get
            {
                string executablePath;
                TryGetExecutablePath(out executablePath).ThrowDbgEngNotOK();

                return executablePath;
            }
        }

        /// <summary>
        /// Gets the full path to the process executable.
        /// </summary>
        public HRESULT TryGetExecutablePath(out string executablePath)
        {
            /*HRESULT GetExecutablePath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executablePath);*/
            return Raw.GetExecutablePath(out executablePath);
        }

        #endregion
        #region Arguments

        /// <summary>
        /// Gets the arguments to the executable (if available). A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        public string Arguments
        {
            get
            {
                string executableArguments;
                TryGetArguments(out executableArguments).ThrowDbgEngNotOK();

                return executableArguments;
            }
        }

        /// <summary>
        /// Gets the arguments to the executable (if available). A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        public HRESULT TryGetArguments(out string executableArguments)
        {
            /*HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executableArguments);*/
            return Raw.GetArguments(out executableArguments);
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the process ID as identified by the underlying system.
        /// </summary>
        public long Id
        {
            get
            {
                long processId;
                TryGetId(out processId).ThrowDbgEngNotOK();

                return processId;
            }
        }

        /// <summary>
        /// Gets the process ID as identified by the underlying system.
        /// </summary>
        public HRESULT TryGetId(out long processId)
        {
            /*HRESULT GetId(
            [Out] out long processId);*/
            return Raw.GetId(out processId);
        }

        #endregion
        #region User

        /// <summary>
        /// Gets the user name as identified by the underlying system. A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        public string User
        {
            get
            {
                string user;
                TryGetUser(out user).ThrowDbgEngNotOK();

                return user;
            }
        }

        /// <summary>
        /// Gets the user name as identified by the underlying system. A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        public HRESULT TryGetUser(out string user)
        {
            /*HRESULT GetUser(
            [Out, MarshalAs(UnmanagedType.BStr)] out string user);*/
            return Raw.GetUser(out user);
        }

        #endregion
        #endregion
    }
}
