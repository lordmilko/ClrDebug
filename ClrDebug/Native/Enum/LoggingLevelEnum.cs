namespace ClrDebug
{
    /// <summary>
    /// Indicates the severity level of a descriptive message that is written to the event log when a managed thread logs an event.
    /// </summary>
    /// <remarks>
    /// The common language runtime (CLR) calls the <see cref="ICorDebugManagedCallback.LogMessage"/> method to notify
    /// the debugger that a managed thread has logged an event. The CLR passes a value of the <see cref="LoggingLevelEnum"/> enumeration
    /// to indicate the severity level of the message that the managed thread wrote to the event log.
    /// </remarks>
    public enum LoggingLevelEnum
    {
        /// <summary>
        /// The message is a trace level 0.
        /// </summary>
        LTraceLevel0	= 0,

        /// <summary>
        /// The message is a trace level 1.
        /// </summary>
        LTraceLevel1	= ( LTraceLevel0 + 1 ) ,

        /// <summary>
        /// The message is a trace level 2.
        /// </summary>
        LTraceLevel2	= ( LTraceLevel1 + 1 ) ,

        /// <summary>
        /// The message is a trace level 3.
        /// </summary>
        LTraceLevel3	= ( LTraceLevel2 + 1 ) ,

        /// <summary>
        /// The message is a trace level 4.
        /// </summary>
        LTraceLevel4	= ( LTraceLevel3 + 1 ) ,

        /// <summary>
        /// The message is a status level 0.
        /// </summary>
        LStatusLevel0	= 20,

        /// <summary>
        /// The message is a status level 1.
        /// </summary>
        LStatusLevel1	= ( LStatusLevel0 + 1 ) ,

        /// <summary>
        /// The message is a status level 2.
        /// </summary>
        LStatusLevel2	= ( LStatusLevel1 + 1 ) ,

        /// <summary>
        /// The message is a status level 3.
        /// </summary>
        LStatusLevel3	= ( LStatusLevel2 + 1 ) ,

        /// <summary>
        /// The message is a status level 4.
        /// </summary>
        LStatusLevel4	= ( LStatusLevel3 + 1 ) ,

        /// <summary>
        /// The message is a warning level.
        /// </summary>
        LWarningLevel	= 40,

        /// <summary>
        /// The message is an error level.
        /// </summary>
        LErrorLevel	= 50,

        /// <summary>
        /// The message is a panic level.
        /// </summary>
        LPanicLevel	= 100
    }
}