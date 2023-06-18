using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides notification of native events that are not directly related to the common language runtime (CLR).
    /// </summary>
    [Guid("5263E909-8CB5-11D3-BD2F-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugUnmanagedCallback
    {
        /// <summary>
        /// Notifies the debugger that a native event has been fired.
        /// </summary>
        /// <param name="pDebugEvent">[in] A pointer to the native event.</param>
        /// <param name="fOutOfBand">[in] true, if interaction with the managed process state is impossible after an unmanaged event occurs, until the debugger calls <see cref="ICorDebugController.Continue"/>; otherwise, false.</param>
        /// <remarks>
        /// If the thread being debugged is a Win32 thread, do not use any members of the Win32 debugging interface. You can
        /// call <see cref="ICorDebugController.Continue"/> only on a Win32 thread and only when continuing past an out-of-band event. The
        /// DebugEvent callback does not follow the standard rules for callbacks. When you call DebugEvent, the process will
        /// be in the raw, OS-debug stopped state. The process will not be synchronized. It will automatically enter the synchronized
        /// state when necessary to satisfy requests for information about managed code, which may result in other nested DebugEvent
        /// callbacks. Call <see cref="ICorDebugProcess.ClearCurrentException"/> on the process to ignore an exception event
        /// before continuing the process. Calling this method sends DBG_CONTINUE instead of DBG_EXCEPTION_NOT_HANDLED on the
        /// continue request, and automatically clears out-of-band breakpoints and single-step exceptions. Out-of-band events
        /// can come at any time, even when the application being debugged appears stopped and when an outstanding in-band
        /// event already exists. In the .NET Framework version 2.0, the debugger should immediately continue past an out-of-band
        /// breakpoint event. The debugger should be using the <see cref="ICorDebugProcess2.SetUnmanagedBreakpoint"/> and <see
        /// cref="ICorDebugProcess2.ClearUnmanagedBreakpoint"/> methods to add and remove breakpoints. These methods will skip
        /// over any out-of-band breakpoints automatically. Thus, the only out-of-band breakpoints that get dispatched should
        /// be raw breakpoints that are already in the instruction stream, such as a call to the Win32 DebugBreak function.
        /// Do not try to use <see cref="ICorDebugProcess.ClearCurrentException"/>, <see cref="ICorDebugProcess.GetThreadContext"/>, <see
        /// cref="ICorDebugProcess.SetThreadContext"/>, or any other member of the debugging API.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DebugEvent(
            [In] ref DEBUG_EVENT pDebugEvent,
            [In, MarshalAs(UnmanagedType.Bool)] bool fOutOfBand);
    }
}
