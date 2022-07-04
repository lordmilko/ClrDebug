using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides support for out of process execution control.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and isn't exposed through any headers or library files. However, it's a
    /// COM interface that derives from IUnknown with GUID E930C679-78AF-4953-8AB7-B0AABF0F9F80 that can be obtained through
    /// the usual COM mechanisms.
    /// </remarks>
    [Guid("E930C679-78AF-4953-8AB7-B0AABF0F9F80")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess4
    {
        [PreserveSig]
        HRESULT Filter(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] pRecord,
            [In] int countBytes,
            [In] CorDebugRecordFormat format,
            [In] int dwFlags,
            [In] int dwThreadId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent,
            [In, Out] ref int pContinueStatus);

        /// <summary>
        /// Notifies the ICorDebug pipeline that the out of process debugger is continuing the debugee's execution.
        /// </summary>
        /// <param name="change">[in] A member of the <see cref="CorDebugStateChange"/> describing a change in the process's execution state.</param>
        /// <remarks>
        /// The provided method is part of the ICorDebugProcess4 interface and corresponds to the fourth slot of the virtual
        /// method table.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProcessStateChanged([In] CorDebugStateChange change);
    }
}
