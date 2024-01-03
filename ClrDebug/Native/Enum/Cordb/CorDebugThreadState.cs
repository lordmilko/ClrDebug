namespace ClrDebug
{
    /// <summary>
    /// Specifies the state of a thread for debugging.
    /// </summary>
    /// <remarks>
    /// The debugger uses the <see cref="CorDebugThreadState"/> enumeration to control a thread's execution. The state of a thread can
    /// be set by using the <see cref="ICorDebugThread.SetDebugState"/> or <see cref="ICorDebugController.SetAllThreadsDebugState"/>
    /// method. A callback provided to the hosting API enables message pumping, so an interrupted state is not needed.
    /// </remarks>
    public enum CorDebugThreadState
    {
        /// <summary>
        /// The thread runs freely, unless a debug event occurs.
        /// </summary>
        THREAD_RUN,

        /// <summary>
        /// The thread cannot run.
        /// </summary>
        THREAD_SUSPEND
    }
}