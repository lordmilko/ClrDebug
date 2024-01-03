namespace ClrDebug
{
    /// <summary>
    /// Describes the amount of cached data that must be discarded based on changes to the process.
    /// </summary>
    /// <remarks>
    /// A member of the <see cref="CorDebugStateChange"/> enumeration is provided as an argument when the debugger calls the ProcessStateChanged
    /// method either with ICorDebugProcess4.ProcessStateChanged or <see cref="ICorDebugProcess6.ProcessStateChanged"/>
    /// </remarks>
    public enum CorDebugStateChange
    {
        /// <summary>
        /// The process reached a new memory state via forward execution.
        /// </summary>
        PROCESS_RUNNING = 1,

        /// <summary>
        /// The process' memory may be arbitrarily different than it was previously.
        /// </summary>
        FLUSH_ALL = 2
    }
}