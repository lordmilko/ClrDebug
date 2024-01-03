namespace ClrDebug
{
    /// <summary>
    /// Indicates the outcome of an individual step.
    /// </summary>
    public enum CorDebugStepReason
    {
        /// <summary>
        /// Stepping completed normally, within the same function.
        /// </summary>
        STEP_NORMAL,

        /// <summary>
        /// Stepping continued normally, after the function returned.
        /// </summary>
        STEP_RETURN,

        /// <summary>
        /// Stepping continued normally, at the beginning of a newly called function.
        /// </summary>
        STEP_CALL,

        /// <summary>
        /// An exception was generated and control was passed to an exception filter.
        /// </summary>
        STEP_EXCEPTION_FILTER,

        /// <summary>
        /// An exception was generated and control was passed to an exception handler.
        /// </summary>
        STEP_EXCEPTION_HANDLER,

        /// <summary>
        /// Control was passed to an interceptor.
        /// </summary>
        STEP_INTERCEPT,

        /// <summary>
        /// The thread exited before the step was completed.
        /// </summary>
        STEP_EXIT
    }
}