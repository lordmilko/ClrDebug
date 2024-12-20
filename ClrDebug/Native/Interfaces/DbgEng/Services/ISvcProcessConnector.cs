using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: A process connector service which acts as a "process server" similar to a DbgSrv or. "gdbserver --multi" instance.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B751FDDF-3B41-4F4B-9EFE-EA310EEFE8D2")]
    [ComImport]
    public interface ISvcProcessConnector
    {
        /// <summary>
        /// Enumerates all of the processes on the server which are connectable.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateConnectableProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcessEnumerator connectableProcessEnum);

        /// <summary>
        /// Attaches to a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.
        /// </summary>
        [PreserveSig]
        HRESULT AttachProcess(
            [In] long pid,
            [In] SvcAttachFlags attachFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);

        /// <summary>
        /// Creates a process on the process server. After a successful call to this method, the process enumeration service is expected to enumerate the process.<para/>
        /// The 'executablePath' and 'commandLine' arguments behave similarly to Windows CreateProcess* call. If both are specified, 'executablePath' is the path to the executable and 'commandLine' is the full command line (which a plug-in may or may not need to parse/separate depending on the underlying system) If 'executablePath' is nullptr and 'commandLine' is not, the first argument of 'commandLine' is the executable to utilize.<para/>
        /// Such argument must be separated by standard means (white space separated allowing for the use of quotation marks) If 'executablePath' is not nullptr and 'commandLine' is, it is assumed that 'executablePath' is also the command line.
        /// </summary>
        [PreserveSig]
        HRESULT CreateProcess(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executablePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string commandLine,
            [In] SvcAttachFlags attachFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string workingDirectory,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);
    }
}
