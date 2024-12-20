using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8F815608-A145-4CF9-8488-9E0EAEA1F2B9")]
    [ComImport]
    public interface ISvcEventArgumentsProcessDiscovery
    {
        /// <summary>
        /// Gets the process which is (dis)appearing. For a process arrival event, the returned process must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a process disappearance event, the interfaces on the returned module *MUST* continue to operate as if the process were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the process may be considered detached/orphaned for anyone continuing to hold the ISvcProcess interface.
        /// </summary>
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);

        /// <summary>
        /// Gets the exit code of the process. This may only be called for a process exit event. It returns E_ILLEGAL_METHOD_CALL for a process arrival event.
        /// </summary>
        [PreserveSig]
        HRESULT GetExitCode(
            [Out] out long exitCode);
    }
}
