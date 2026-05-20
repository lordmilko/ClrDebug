using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface supports Process Lifecycle Management (PLM) for the debug client.
    /// </summary>
    public class DebugPlmClient : ComObject<IDebugPlmClient>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugPlmClient"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugPlmClient(IDebugPlmClient raw) : base(raw)
        {
        }

        #region IDebugPlmClient
        #region LaunchPlmPackageForDebugWide

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) application.
        /// </summary>
        /// <param name="server">[in] The server of the application.</param>
        /// <param name="timeout">[in] A time-out value.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="appName">[in] A pointer to the application name.</param>
        /// <param name="arguments">[in, optional] A pointer an arguments string.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public LaunchPlmPackageForDebugWideResult LaunchPlmPackageForDebugWide(long server, int timeout, string packageFullName, string appName, string arguments)
        {
            LaunchPlmPackageForDebugWideResult result;
            TryLaunchPlmPackageForDebugWide(server, timeout, packageFullName, appName, arguments, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) application.
        /// </summary>
        /// <param name="server">[in] The server of the application.</param>
        /// <param name="timeout">[in] A time-out value.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="appName">[in] A pointer to the application name.</param>
        /// <param name="arguments">[in, optional] A pointer an arguments string.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryLaunchPlmPackageForDebugWide(long server, int timeout, string packageFullName, string appName, string arguments, out LaunchPlmPackageForDebugWideResult result)
        {
            /*HRESULT LaunchPlmPackageForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments,
            [Out] out int ProcessId,
            [Out] out int ThreadId);*/
            int processId;
            int threadId;
            HRESULT hr = Raw.LaunchPlmPackageForDebugWide(server, timeout, packageFullName, appName, arguments, out processId, out threadId);

            if (hr == HRESULT.S_OK)
                result = new LaunchPlmPackageForDebugWideResult(processId, threadId);
            else
                result = default(LaunchPlmPackageForDebugWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugPlmClient2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugPlmClient2 Raw2 => (IDebugPlmClient2) Raw;

        #region LaunchPlmBgTaskForDebugWide

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) background task.
        /// </summary>
        /// <param name="server">[in] The server of the task.</param>
        /// <param name="timeout">[in] A time-out value.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="backgroundTaskId">[in] A pointer to the task ID.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public LaunchPlmBgTaskForDebugWideResult LaunchPlmBgTaskForDebugWide(long server, int timeout, string packageFullName, string backgroundTaskId)
        {
            LaunchPlmBgTaskForDebugWideResult result;
            TryLaunchPlmBgTaskForDebugWide(server, timeout, packageFullName, backgroundTaskId, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) background task.
        /// </summary>
        /// <param name="server">[in] The server of the task.</param>
        /// <param name="timeout">[in] A time-out value.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="backgroundTaskId">[in] A pointer to the task ID.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryLaunchPlmBgTaskForDebugWide(long server, int timeout, string packageFullName, string backgroundTaskId, out LaunchPlmBgTaskForDebugWideResult result)
        {
            /*HRESULT LaunchPlmBgTaskForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId,
            [Out] out int ProcessId,
            [Out] out int ThreadId);*/
            int processId;
            int threadId;
            HRESULT hr = Raw2.LaunchPlmBgTaskForDebugWide(server, timeout, packageFullName, backgroundTaskId, out processId, out threadId);

            if (hr == HRESULT.S_OK)
                result = new LaunchPlmBgTaskForDebugWideResult(processId, threadId);
            else
                result = default(LaunchPlmBgTaskForDebugWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugPlmClient3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugPlmClient3 Raw3 => (IDebugPlmClient3) Raw;

        #region QueryPlmPackageWide

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="stream">[in] A pointer to an output stream for results.</param>
        public void QueryPlmPackageWide(long server, string packageFullName, IDebugOutputStream stream)
        {
            TryQueryPlmPackageWide(server, packageFullName, stream).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="stream">[in] A pointer to an output stream for results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryQueryPlmPackageWide(long server, string packageFullName, IDebugOutputStream stream)
        {
            /*HRESULT QueryPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);*/
            return Raw3.QueryPlmPackageWide(server, packageFullName, stream);
        }

        #endregion
        #region QueryPlmPackageList

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package list.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="stream">[in] A pointer to an output stream for results.</param>
        public void QueryPlmPackageList(long server, IDebugOutputStream stream)
        {
            TryQueryPlmPackageList(server, stream).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package list.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="stream">[in] A pointer to an output stream for results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryQueryPlmPackageList(long server, IDebugOutputStream stream)
        {
            /*HRESULT QueryPlmPackageList(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);*/
            return Raw3.QueryPlmPackageList(server, stream);
        }

        #endregion
        #region EnablePlmPackageDebugWide

        /// <summary>
        /// Enables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        public void EnablePlmPackageDebugWide(long server, string packageFullName)
        {
            TryEnablePlmPackageDebugWide(server, packageFullName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Enables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryEnablePlmPackageDebugWide(long server, string packageFullName)
        {
            /*HRESULT EnablePlmPackageDebugWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return Raw3.EnablePlmPackageDebugWide(server, packageFullName);
        }

        #endregion
        #region DisablePlmPackageDebugWide

        /// <summary>
        /// Disables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        public void DisablePlmPackageDebugWide(ulong server, string packageFullName)
        {
            TryDisablePlmPackageDebugWide(server, packageFullName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Disables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryDisablePlmPackageDebugWide(ulong server, string packageFullName)
        {
            /*HRESULT DisablePlmPackageDebugWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return Raw3.DisablePlmPackageDebugWide(server, packageFullName);
        }

        #endregion
        #region SuspendPlmPackageWide

        /// <summary>
        /// Suspends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        public void SuspendPlmPackageWide(long server, string packageFullName)
        {
            TrySuspendPlmPackageWide(server, packageFullName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Suspends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySuspendPlmPackageWide(long server, string packageFullName)
        {
            /*HRESULT SuspendPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return Raw3.SuspendPlmPackageWide(server, packageFullName);
        }

        #endregion
        #region ResumePlmPackageWide

        /// <summary>
        /// Resumes a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        public void ResumePlmPackageWide(long server, string packageFullName)
        {
            TryResumePlmPackageWide(server, packageFullName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resumes a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryResumePlmPackageWide(long server, string packageFullName)
        {
            /*HRESULT ResumePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return Raw3.ResumePlmPackageWide(server, packageFullName);
        }

        #endregion
        #region TerminatePlmPackageWide

        /// <summary>
        /// Ends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        public void TerminatePlmPackageWide(long server, string packageFullName)
        {
            TryTerminatePlmPackageWide(server, packageFullName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Ends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="server">[in] The server of the package.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryTerminatePlmPackageWide(long server, string packageFullName)
        {
            /*HRESULT TerminatePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return Raw3.TerminatePlmPackageWide(server, packageFullName);
        }

        #endregion
        #region LaunchAndDebugPlmAppWide

        /// <param name="server">[in] The server of the application.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="appName">[in] A pointer to the application name.</param>
        /// <param name="arguments">[in] A pointer to an arguments string.</param>
        public void LaunchAndDebugPlmAppWide(long server, string packageFullName, string appName, string arguments)
        {
            TryLaunchAndDebugPlmAppWide(server, packageFullName, appName, arguments).ThrowDbgEngNotOK();
        }

        /// <param name="server">[in] The server of the application.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="appName">[in] A pointer to the application name.</param>
        /// <param name="arguments">[in] A pointer to an arguments string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. If a debugger session is not already started, this method starts one.</returns>
        public HRESULT TryLaunchAndDebugPlmAppWide(long server, string packageFullName, string appName, string arguments)
        {
            /*HRESULT LaunchAndDebugPlmAppWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);*/
            return Raw3.LaunchAndDebugPlmAppWide(server, packageFullName, appName, arguments);
        }

        #endregion
        #region ActivateAndDebugPlmBgTaskWide

        /// <param name="server">[in] The server of the task.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="backgroundTaskId">[in] A pointer to the task ID.</param>
        public void ActivateAndDebugPlmBgTaskWide(long server, string packageFullName, string backgroundTaskId)
        {
            TryActivateAndDebugPlmBgTaskWide(server, packageFullName, backgroundTaskId).ThrowDbgEngNotOK();
        }

        /// <param name="server">[in] The server of the task.</param>
        /// <param name="packageFullName">[in] A pointer to the package name.</param>
        /// <param name="backgroundTaskId">[in] A pointer to the task ID.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. If a debugger session is not already started, this method starts one.</returns>
        public HRESULT TryActivateAndDebugPlmBgTaskWide(long server, string packageFullName, string backgroundTaskId)
        {
            /*HRESULT ActivateAndDebugPlmBgTaskWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId);*/
            return Raw3.ActivateAndDebugPlmBgTaskWide(server, packageFullName, backgroundTaskId);
        }

        #endregion
        #endregion
    }
}
