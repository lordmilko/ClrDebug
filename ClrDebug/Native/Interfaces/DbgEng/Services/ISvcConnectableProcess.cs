using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0CA4DC6B-1070-4AA1-8C6C-1F626962A475")]
    [ComImport]
    public interface ISvcConnectableProcess
    {
        /// <summary>
        /// Gets the full path to the process executable.
        /// </summary>
        [PreserveSig]
        HRESULT GetExecutablePath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executablePath);

        /// <summary>
        /// Gets the arguments to the executable (if available). A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        [PreserveSig]
        HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string executableArguments);

        /// <summary>
        /// Gets the process ID as identified by the underlying system.
        /// </summary>
        [PreserveSig]
        HRESULT GetId(
            [Out] out long processId);

        /// <summary>
        /// Gets the user name as identified by the underlying system. A connectable process may return E_NOTIMPL here if this cannot be determined for the given platform.
        /// </summary>
        [PreserveSig]
        HRESULT GetUser(
            [Out, MarshalAs(UnmanagedType.BStr)] out string user);
    }
}
