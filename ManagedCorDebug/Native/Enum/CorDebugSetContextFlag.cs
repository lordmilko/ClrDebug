namespace ManagedCorDebug
{
    /// <summary>
    /// Indicates whether the context is from the active (or leaf) frame on the stack or has been computed by unwinding from another frame.
    /// </summary>
    /// <remarks>
    /// CorDebugSetContextFlag provides values that are used by the <see cref="ICorDebugStackWalk.SetContext"/> method.
    /// </remarks>
    public enum CorDebugSetContextFlag
    {
        /// <summary>
        /// The context is the thread’s active context.
        /// </summary>
        SET_CONTEXT_FLAG_ACTIVE_FRAME = 1,

        /// <summary>
        /// The context has been computed by unwinding from another frame.
        /// </summary>
        SET_CONTEXT_FLAG_UNWIND_FRAME = 2
    }
}