namespace ManagedCorDebug
{
    /// <summary>
    /// Indicates the event that is being signaled by the callback during the unwind phase.
    /// </summary>
    public enum CorDebugExceptionUnwindCallbackType
    {
        /// <summary>
        /// The beginning of the unwind process.
        /// </summary>
        DEBUG_EXCEPTION_UNWIND_BEGIN = 1,

        /// <summary>
        /// The exception was intercepted.
        /// </summary>
        DEBUG_EXCEPTION_INTERCEPTED = 2
    }
}