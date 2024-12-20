using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("51A92871-F1D1-4DA2-9805-75A41731D636")]
    [ComImport]
    public interface ISvcEventArgumentsThreadDiscovery
    {
        /// <summary>
        /// Gets the thread which is (dis)appearing. For a thread arrival event, the returned thread must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a thread disappearance event, the interfaces on the returned thread *MUST* continue to operate as if the thread were targeted until the event notification has completed.<para/>
        /// After the event notification is complete, the thread may be considered detached/orphaned for anyone continuing to hold the ISvcThread interface.
        /// </summary>
        [PreserveSig]
        HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);

        /// <summary>
        /// Gets the exit code of the thread. This may only be called for a thread exit event. It returns E_ILLEGAL_METHOD_CALL for a thread arrival event.
        /// </summary>
        [PreserveSig]
        HRESULT GetExitCode(
            [Out] out long exitCode);
    }
}
