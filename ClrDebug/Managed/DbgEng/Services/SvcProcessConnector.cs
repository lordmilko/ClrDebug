namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: A process connector service which acts as a "process server" similar to a DbgSrv or. "gdbserver --multi" instance.
    /// </summary>
    public class SvcProcessConnector : ComObject<ISvcProcessConnector>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcProcessConnector"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcProcessConnector(ISvcProcessConnector raw) : base(raw)
        {
        }

        #region ISvcProcessConnector
        #region EnumerateConnectableProcesses

        /// <summary>
        /// Enumerates all of the processes on the server which are connectable.
        /// </summary>
        public SvcConnectableProcessEnumerator EnumerateConnectableProcesses()
        {
            SvcConnectableProcessEnumerator connectableProcessEnumResult;
            TryEnumerateConnectableProcesses(out connectableProcessEnumResult).ThrowDbgEngNotOK();

            return connectableProcessEnumResult;
        }

        /// <summary>
        /// Enumerates all of the processes on the server which are connectable.
        /// </summary>
        public HRESULT TryEnumerateConnectableProcesses(out SvcConnectableProcessEnumerator connectableProcessEnumResult)
        {
            /*HRESULT EnumerateConnectableProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcessEnumerator connectableProcessEnum);*/
            ISvcConnectableProcessEnumerator connectableProcessEnum;
            HRESULT hr = Raw.EnumerateConnectableProcesses(out connectableProcessEnum);

            if (hr == HRESULT.S_OK)
                connectableProcessEnumResult = connectableProcessEnum == null ? null : new SvcConnectableProcessEnumerator(connectableProcessEnum);
            else
                connectableProcessEnumResult = default(SvcConnectableProcessEnumerator);

            return hr;
        }

        #endregion
        #region AttachProcess

        /// <summary>
        /// Attaches to a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.
        /// </summary>
        public SvcProcess AttachProcess(long pid, SvcAttachFlags attachFlags)
        {
            SvcProcess ppProcessResult;
            TryAttachProcess(pid, attachFlags, out ppProcessResult).ThrowDbgEngNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Attaches to a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.
        /// </summary>
        public HRESULT TryAttachProcess(long pid, SvcAttachFlags attachFlags, out SvcProcess ppProcessResult)
        {
            /*HRESULT AttachProcess(
            [In] long pid,
            [In] SvcAttachFlags attachFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);*/
            ISvcProcess ppProcess;
            HRESULT hr = Raw.AttachProcess(pid, attachFlags, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new SvcProcess(ppProcess);
            else
                ppProcessResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #region CreateProcess

        /// <summary>
        /// Creates a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.<para/>
        /// The 'executablePath' and 'commandLine' arguments behave similarly to Windows CreateProcess* call. If both are specified, 'executablePath' is the path to the executable and 'commandLine' is the full command line (which a plug-in may or may not need to parse/separate depending on the underlying system) If 'executablePath' is nullptr and 'commandLine' is not, the first argument of 'commandLine' is the executable to utilize.<para/>
        /// Such argument must be separated by standard means (white space separated allowing for the use of quotation marks) If 'executablePath' is not nullptr and 'commandLine' is, it is assumed that 'executablePath' is also the command line.
        /// </summary>
        public SvcProcess CreateProcess(string executablePath, string commandLine, SvcAttachFlags attachFlags, string workingDirectory)
        {
            SvcProcess ppProcessResult;
            TryCreateProcess(executablePath, commandLine, attachFlags, workingDirectory, out ppProcessResult).ThrowDbgEngNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Creates a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.<para/>
        /// The 'executablePath' and 'commandLine' arguments behave similarly to Windows CreateProcess* call. If both are specified, 'executablePath' is the path to the executable and 'commandLine' is the full command line (which a plug-in may or may not need to parse/separate depending on the underlying system) If 'executablePath' is nullptr and 'commandLine' is not, the first argument of 'commandLine' is the executable to utilize.<para/>
        /// Such argument must be separated by standard means (white space separated allowing for the use of quotation marks) If 'executablePath' is not nullptr and 'commandLine' is, it is assumed that 'executablePath' is also the command line.
        /// </summary>
        public HRESULT TryCreateProcess(string executablePath, string commandLine, SvcAttachFlags attachFlags, string workingDirectory, out SvcProcess ppProcessResult)
        {
            /*HRESULT CreateProcess(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executablePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string commandLine,
            [In] SvcAttachFlags attachFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string workingDirectory,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);*/
            ISvcProcess ppProcess;
            HRESULT hr = Raw.CreateProcess(executablePath, commandLine, attachFlags, workingDirectory, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new SvcProcess(ppProcess);
            else
                ppProcessResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #endregion
    }
}
