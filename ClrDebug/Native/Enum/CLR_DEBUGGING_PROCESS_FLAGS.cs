using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Provides values that are used by the <see cref="ICLRDebugging.OpenVirtualProcess"/> method.
    /// </summary>
    /// <remarks>
    /// Catch-up events include process, application domain, assembly, module, and thread creation notifications that bring
    /// the debugger up to the current state after it has attached to a process. Non-catch-up events, which are indicated
    /// by the CLR_DEBUGGING_MANAGED_EVENT_PENDING flag, include all other debugger events, such as exceptions and managed
    /// debugging assistant (MDA) notifications. The CLR_DEBUGGING_MANAGED_EVENT_DEBUGGER_LAUNCH flag enables the runtime
    /// to differentiate between a terminating exception and a request to attach a managed debugger that can be canceled.
    /// </remarks>
    public enum CLR_DEBUGGING_PROCESS_FLAGS
    {
        /// <summary>
        /// This runtime has a non-catch-up managed debugger event to send. See the Remarks section for the distinction between catch-up and non-catch-up events.
        /// </summary>
        CLR_DEBUGGING_MANAGED_EVENT_PENDING = 1,

        /// <summary>
        /// The managed event that is pending is a <see cref="Debugger.Launch"/> request.
        /// </summary>
        CLR_DEBUGGING_MANAGED_EVENT_DEBUGGER_LAUNCH = 2
    }
}