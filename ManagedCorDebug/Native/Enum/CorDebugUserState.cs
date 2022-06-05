namespace ManagedCorDebug
{
    /// <summary>
    /// Indicates the user state of a thread.
    /// </summary>
    /// <remarks>
    /// The user state of a thread is the state that the thread has when the debugger examines it. A thread may have a
    /// combination of user states. Use the <see cref="ICorDebugThread.GetUserState"/> method to retrieve a thread's user
    /// state.
    /// </remarks>
    public enum CorDebugUserState
    {
        /// <summary>
        /// A termination of the thread has been requested.
        /// </summary>
        USER_STOP_REQUESTED = 1,

        /// <summary>
        /// A suspension of the thread has been requested.
        /// </summary>
        USER_SUSPEND_REQUESTED = 2,

        /// <summary>
        /// The thread is running in the background.
        /// </summary>
        USER_BACKGROUND = 4,

        /// <summary>
        /// The thread has not started executing.
        /// </summary>
        USER_UNSTARTED = 8,

        /// <summary>
        /// The thread has been terminated.
        /// </summary>
        USER_STOPPED = 16, // 0x00000010

        /// <summary>
        /// The thread is waiting for another thread to complete a task.
        /// </summary>
        USER_WAIT_SLEEP_JOIN = 32, // 0x00000020

        /// <summary>
        /// The thread has been suspended.
        /// </summary>
        USER_SUSPENDED = 64, // 0x00000040

        /// <summary>
        /// The thread is at an unsafe point. That is, the thread is at a point in execution where it may block garbage collection. Debug events may be dispatched from unsafe points, but suspending a thread at an unsafe point  will very likely cause a deadlock until the thread is resumed. The safe and unsafe points are determined by the just-in-time (JIT) and garbage collection implementation.
        /// </summary>
        USER_UNSAFE_POINT = 128, // 0x00000080

        /// <summary>
        /// The thread is from the thread pool.
        /// </summary>
        USER_THREADPOOL = 256 // 0x00000100
    }
}