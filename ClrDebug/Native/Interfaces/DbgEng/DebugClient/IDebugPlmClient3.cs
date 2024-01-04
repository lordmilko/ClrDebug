using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface supports Process Lifecycle Management (PLM) for the debug client.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D4A5DBD1-CA02-4D90-856A-2A92BFD0F20F")]
    [ComImport]
    public interface IDebugPlmClient3 : IDebugPlmClient2
    {
        #region IDebugPlmClient

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) application.
        /// </summary>
        /// <param name="Server">[in] The server of the application.</param>
        /// <param name="Timeout">[in] A time-out value.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <param name="AppName">[in] A pointer to the application name.</param>
        /// <param name="Arguments">[in, optional] A pointer an arguments string.</param>
        /// <param name="ProcessId">[out] A pointer to a process ID output.</param>
        /// <param name="ThreadId">[out] A pointer to a thread ID output.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        new HRESULT LaunchPlmPackageForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments,
            [Out] out int ProcessId,
            [Out] out int ThreadId);

        #endregion
        #region IDebugPlmClient2

        /// <summary>
        /// Launches a suspended Process Lifecycle Management (PLM) background task.
        /// </summary>
        /// <param name="Server">[in] The server of the task.</param>
        /// <param name="Timeout">[in] A time-out value.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <param name="BackgroundTaskId">[in] A pointer to the task ID.</param>
        /// <param name="ProcessId">[out] A pointer to a process ID output.</param>
        /// <param name="ThreadId">[out] A pointer to a thread ID output.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        new HRESULT LaunchPlmBgTaskForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId,
            [Out] out int ProcessId,
            [Out] out int ThreadId);

        #endregion
        #region IDebugPlmClient3

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <param name="Stream">[in] A pointer to an output stream for results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT QueryPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);

        /// <summary>
        /// Query a Process Lifecycle Management (PLM) package list.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="Stream">[in] A pointer to an output stream for results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT QueryPlmPackageList(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputStream Stream);

        /// <summary>
        /// Enables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT EnablePlmPackageDebugWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);

        /// <summary>
        /// Disables a Process Lifecycle Management (PLM) package debug.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT DisablePlmPackageDebugWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);

        /// <summary>
        /// Suspends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT SuspendPlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);

        /// <summary>
        /// Resumes a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT ResumePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);

        /// <summary>
        /// Ends a Process Lifecycle Management (PLM) package.
        /// </summary>
        /// <param name="Server">[in] The server of the package.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT TerminatePlmPackageWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName);

        /// <param name="Server">[in] The server of the application.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <param name="AppName">[in] A pointer to the application name.</param>
        /// <param name="Arguments">[in] A pointer to an arguments string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. If a debugger session is not already started, this method starts one.</returns>
        [PreserveSig]
        HRESULT LaunchAndDebugPlmAppWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);

        /// <param name="Server">[in] The server of the task.</param>
        /// <param name="PackageFullName">[in] A pointer to the package name.</param>
        /// <param name="BackgroundTaskId">[in] A pointer to the task ID.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. If a debugger session is not already started, this method starts one.</returns>
        [PreserveSig]
        HRESULT ActivateAndDebugPlmBgTaskWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId);

        #endregion
    }
}
