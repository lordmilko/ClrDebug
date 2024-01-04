namespace ClrDebug.DbgEng
{
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

        public SvcConnectableProcessEnumerator EnumerateConnectableProcesses()
        {
            SvcConnectableProcessEnumerator connectableProcessEnumResult;
            TryEnumerateConnectableProcesses(out connectableProcessEnumResult).ThrowDbgEngNotOK();

            return connectableProcessEnumResult;
        }

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

        public SvcProcess AttachProcess(long pid, SvcAttachFlags attachFlags)
        {
            SvcProcess ppProcessResult;
            TryAttachProcess(pid, attachFlags, out ppProcessResult).ThrowDbgEngNotOK();

            return ppProcessResult;
        }

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

        public SvcProcess CreateProcess(string executablePath, string commandLine, SvcAttachFlags attachFlags, string workingDirectory)
        {
            SvcProcess ppProcessResult;
            TryCreateProcess(executablePath, commandLine, attachFlags, workingDirectory, out ppProcessResult).ThrowDbgEngNotOK();

            return ppProcessResult;
        }

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
