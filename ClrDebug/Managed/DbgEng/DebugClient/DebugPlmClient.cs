using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface supports Process Lifecycle Management (PLM) for the debug client.
    /// </summary>
    public unsafe class DebugPlmClient : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugPlmClient = new Guid("A02B66C4-AEA3-4234-A9F7-FE4C383D4E29");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugPlmClientVtbl* Vtbl => (IDebugPlmClientVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugPlmClient2Vtbl* Vtbl2 => (IDebugPlmClient2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugPlmClient3Vtbl* Vtbl3 => (IDebugPlmClient3Vtbl*) base.Vtbl;

        #endregion

        public DebugPlmClient(IntPtr raw) : base(raw, IID_IDebugPlmClient)
        {
        }

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
            InitDelegate(ref launchPlmPackageForDebugWide, Vtbl->LaunchPlmPackageForDebugWide);
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
            HRESULT hr = launchPlmPackageForDebugWide(Raw, server, timeout, packageFullName, appName, arguments, out processId, out threadId);

            if (hr == HRESULT.S_OK)
                result = new LaunchPlmPackageForDebugWideResult(processId, threadId);
            else
                result = default(LaunchPlmPackageForDebugWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugPlmClient2
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
            InitDelegate(ref launchPlmBgTaskForDebugWide, Vtbl2->LaunchPlmBgTaskForDebugWide);
            /*HRESULT LaunchPlmBgTaskForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId,
            [Out] out int ProcessId,
            [Out] out int ThreadId);*/
            int processId;
            int threadId;
            HRESULT hr = launchPlmBgTaskForDebugWide(Raw, server, timeout, packageFullName, backgroundTaskId, out processId, out threadId);

            if (hr == HRESULT.S_OK)
                result = new LaunchPlmBgTaskForDebugWideResult(processId, threadId);
            else
                result = default(LaunchPlmBgTaskForDebugWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugPlmClient3
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
            InitDelegate(ref queryPlmPackageWide, Vtbl3->QueryPlmPackageWide);

            /*HRESULT QueryPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);*/
            return queryPlmPackageWide(Raw, server, packageFullName, stream);
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
            InitDelegate(ref queryPlmPackageList, Vtbl3->QueryPlmPackageList);

            /*HRESULT QueryPlmPackageList(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);*/
            return queryPlmPackageList(Raw, server, stream);
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
            InitDelegate(ref enablePlmPackageDebugWide, Vtbl3->EnablePlmPackageDebugWide);

            /*HRESULT EnablePlmPackageDebugWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return enablePlmPackageDebugWide(Raw, server, packageFullName);
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
            InitDelegate(ref disablePlmPackageDebugWide, Vtbl3->DisablePlmPackageDebugWide);

            /*HRESULT DisablePlmPackageDebugWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return disablePlmPackageDebugWide(Raw, server, packageFullName);
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
            InitDelegate(ref suspendPlmPackageWide, Vtbl3->SuspendPlmPackageWide);

            /*HRESULT SuspendPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return suspendPlmPackageWide(Raw, server, packageFullName);
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
            InitDelegate(ref resumePlmPackageWide, Vtbl3->ResumePlmPackageWide);

            /*HRESULT ResumePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return resumePlmPackageWide(Raw, server, packageFullName);
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
            InitDelegate(ref terminatePlmPackageWide, Vtbl3->TerminatePlmPackageWide);

            /*HRESULT TerminatePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);*/
            return terminatePlmPackageWide(Raw, server, packageFullName);
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
            InitDelegate(ref launchAndDebugPlmAppWide, Vtbl3->LaunchAndDebugPlmAppWide);

            /*HRESULT LaunchAndDebugPlmAppWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);*/
            return launchAndDebugPlmAppWide(Raw, server, packageFullName, appName, arguments);
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
            InitDelegate(ref activateAndDebugPlmBgTaskWide, Vtbl3->ActivateAndDebugPlmBgTaskWide);

            /*HRESULT ActivateAndDebugPlmBgTaskWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId);*/
            return activateAndDebugPlmBgTaskWide(Raw, server, packageFullName, backgroundTaskId);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugPlmClient

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LaunchPlmPackageForDebugWideDelegate launchPlmPackageForDebugWide;

        #endregion
        #region IDebugPlmClient2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LaunchPlmBgTaskForDebugWideDelegate launchPlmBgTaskForDebugWide;

        #endregion
        #region IDebugPlmClient3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryPlmPackageWideDelegate queryPlmPackageWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryPlmPackageListDelegate queryPlmPackageList;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EnablePlmPackageDebugWideDelegate enablePlmPackageDebugWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DisablePlmPackageDebugWideDelegate disablePlmPackageDebugWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SuspendPlmPackageWideDelegate suspendPlmPackageWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ResumePlmPackageWideDelegate resumePlmPackageWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TerminatePlmPackageWideDelegate terminatePlmPackageWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LaunchAndDebugPlmAppWideDelegate launchAndDebugPlmAppWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ActivateAndDebugPlmBgTaskWideDelegate activateAndDebugPlmBgTaskWide;

        #endregion
        #endregion
        #region Delegates
        #region IDebugPlmClient

        private delegate HRESULT LaunchPlmPackageForDebugWideDelegate(IntPtr self, [In] long Server, [In] int Timeout, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName, [In, MarshalAs(UnmanagedType.LPWStr)] string AppName, [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments, [Out] out int ProcessId, [Out] out int ThreadId);

        #endregion
        #region IDebugPlmClient2

        private delegate HRESULT LaunchPlmBgTaskForDebugWideDelegate(IntPtr self, [In] long Server, [In] int Timeout, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName, [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId, [Out] out int ProcessId, [Out] out int ThreadId);

        #endregion
        #region IDebugPlmClient3

        private delegate HRESULT QueryPlmPackageWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName, [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);
        private delegate HRESULT QueryPlmPackageListDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);
        private delegate HRESULT EnablePlmPackageDebugWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);
        private delegate HRESULT DisablePlmPackageDebugWideDelegate(IntPtr self, [In] ulong Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);
        private delegate HRESULT SuspendPlmPackageWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);
        private delegate HRESULT ResumePlmPackageWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);
        private delegate HRESULT TerminatePlmPackageWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);
        private delegate HRESULT LaunchAndDebugPlmAppWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName, [In, MarshalAs(UnmanagedType.LPWStr)] string AppName, [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);
        private delegate HRESULT ActivateAndDebugPlmBgTaskWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName, [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId);

        #endregion
        #endregion
    }
}
