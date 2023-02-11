namespace ClrDebug
{
    /// <summary>
    /// Describes the level of an EventPipe event.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EVENTPIPE_LEVEL enumeration is used by the <see cref="ICorProfilerInfo12.EventPipeDefineEvent"/> method
    /// to indicate the level of the event being defined.
    /// </remarks>
    public enum COR_PRF_EVENTPIPE_LEVEL
    {
        /// <summary>
        /// The event is always logged.
        /// </summary>
        COR_PRF_EVENTPIPE_LOGALWAYS = 0,

        /// <summary>
        /// The event represents a critical message.
        /// </summary>
        COR_PRF_EVENTPIPE_CRITICAL = 1,

        /// <summary>
        /// The event represents an error message.
        /// </summary>
        COR_PRF_EVENTPIPE_ERROR = 2,

        /// <summary>
        /// The event represents a warning message.
        /// </summary>
        COR_PRF_EVENTPIPE_WARNING = 3,

        /// <summary>
        /// The event represents an informational message.
        /// </summary>
        COR_PRF_EVENTPIPE_INFORMATIONAL = 4,

        /// <summary>
        /// The event represents a verbose message.
        /// </summary>
        COR_PRF_EVENTPIPE_VERBOSE = 5
    }
}
