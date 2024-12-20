using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The low level interface exposed from a DEBUG_SERVICE_BREAKPOINT_CONTROLLER which handles the fundamental low level breakpoint operations.<para/>
    /// Higher level breakpoint operations (e.g.: source level / deferred / etc...) are handled at the breakpoint manager level.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5D62C1F1-D49A-4749-90AA-C13443184C99")]
    [ComImport]
    public interface ISvcBreakpointController
    {
        /// <summary>
        /// Enumerates all breakpoints known to the breakpoint controller. Note that this will *ONLY* enumerate breakpoints known to the controller.<para/>
        /// There may be logically higher level breakpoints which are not realized as a single underlying breakpoint and are handled at the manager level.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateBreakpoints(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpointEnumerator ppBreakpointEnum);

        /// <summary>
        /// Creates a new code breakpoint at a given address.
        /// </summary>
        [PreserveSig]
        HRESULT CreateCodeBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);

        /// <summary>
        /// Creates a new data breakpoint at a given address.
        /// </summary>
        [PreserveSig]
        HRESULT CreateDataBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [In] long dataWidth,
            [In] DataAccessFlags accessFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);
    }
}
