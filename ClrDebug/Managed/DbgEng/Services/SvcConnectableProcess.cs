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

        public string ExecutablePath
        {
            get
            {
                string executablePath;
                TryGetExecutablePath(out executablePath).ThrowDbgEngNotOK();

                return executablePath;
            }
        }

        public HRESULT TryGetExecutablePath(out string executablePath)
        {
            /*HRESULT GetExecutablePath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executablePath);*/
            return Raw.GetExecutablePath(out executablePath);
        }

        #endregion
        #region Arguments

        public string Arguments
        {
            get
            {
                string executableArguments;
                TryGetArguments(out executableArguments).ThrowDbgEngNotOK();

                return executableArguments;
            }
        }

        public HRESULT TryGetArguments(out string executableArguments)
        {
            /*HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executableArguments);*/
            return Raw.GetArguments(out executableArguments);
        }

        #endregion
        #region Id

        public long Id
        {
            get
            {
                long processId;
                TryGetId(out processId).ThrowDbgEngNotOK();

                return processId;
            }
        }

        public HRESULT TryGetId(out long processId)
        {
            /*HRESULT GetId(
            [Out] out long processId);*/
            return Raw.GetId(out processId);
        }

        #endregion
        #region User

        public string User
        {
            get
            {
                string user;
                TryGetUser(out user).ThrowDbgEngNotOK();

                return user;
            }
        }

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
