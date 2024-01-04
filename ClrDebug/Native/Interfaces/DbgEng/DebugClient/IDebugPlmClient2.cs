using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface supports Process Lifecycle Management (PLM) for the debug client.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("597C980D-E7BD-4309-962C-9D9B69A7372C")]
    [ComImport]
    public interface IDebugPlmClient2 : IDebugPlmClient
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
        HRESULT LaunchPlmBgTaskForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string BackgroundTaskId,
            [Out] out int ProcessId,
            [Out] out int ThreadId);

        #endregion
    }
}
