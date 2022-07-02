namespace ClrDebug
{
    /// <summary>
    /// Provides additional information about an exception.
    /// </summary>
    /// <remarks>
    /// New values may be added to this enumeration in later versions, so you should prepare code that uses <see cref="CorDebugExceptionFlags"/>
    /// for unexpected values.
    /// </remarks>
    public enum CorDebugExceptionFlags
    {
        /// <summary>
        /// There is no exception.
        /// </summary>
        DEBUG_EXCEPTION_NONE,

        /// <summary>
        /// The exception is interceptable. The timing of the exception may still be such that the debugger cannot intercept it.<para/>
        /// For example, if there is no managed code below the current callback or the exception event resulted from a just-in-time (JIT) attachment, the exception cannot be intercepted.
        /// </summary>
        DEBUG_EXCEPTION_CAN_BE_INTERCEPTED
    }
}