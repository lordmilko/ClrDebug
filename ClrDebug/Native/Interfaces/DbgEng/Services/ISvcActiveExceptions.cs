using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_ACTIVE_EXCEPTIONS. Defines a means of getting the currently active exceptions on execution units or stored within post-mortem data associated with a process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1579B0C9-A848-447D-BB65-0CFFE3F985FB")]
    [ComImport]
    public interface ISvcActiveExceptions
    {
        /// <summary>
        /// Gets the last exception event for a particular process. For a post-mortem target, this is often the "reason" for a snapshot.<para/>
        /// Such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "last exception event", E_NOT_SET may be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetLastExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);

        /// <summary>
        /// Gets the active exception event for a particular execution unit. As with GetLastExceptionEvent, such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "active exception event", E_NOT_SET may be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetActiveExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pExecutionUnit,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);
    }
}
