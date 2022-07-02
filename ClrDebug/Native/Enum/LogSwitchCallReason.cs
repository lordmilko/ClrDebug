namespace ClrDebug
{
    /// <summary>
    /// Indicates the operation that was performed on a debugging/tracing switch.
    /// </summary>
    public enum LogSwitchCallReason
    {
        /// <summary>
        /// A debugging/tracing switch was created.
        /// </summary>
        SWITCH_CREATE,

        /// <summary>
        /// A debugging/tracing switch was modified.
        /// </summary>
        SWITCH_MODIFY,

        /// <summary>
        /// A debugging/tracing switch was deleted.
        /// </summary>
        SWITCH_DELETE
    }
}