using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface supports Process Lifecycle Management (PLM) for the debug client.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A02B66C4-AEA3-4234-A9F7-FE4C383D4E29")]
    [ComImport]
    public interface IDebugPlmClient
    {
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
        HRESULT LaunchPlmPackageForDebugWide(
            [In] long Server,
            [In] int Timeout,
            [In, MarshalAs(UnmanagedType.LPWStr)] string PackageFullName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string AppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments,
            [Out] out int ProcessId,
            [Out] out int ThreadId);
    }
}
