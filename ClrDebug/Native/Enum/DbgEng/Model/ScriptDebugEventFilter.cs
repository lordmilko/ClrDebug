namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the set of debug events / exceptions which the script debugger can (potentially) auto-break on.
    /// </summary>
    public enum ScriptDebugEventFilter : uint
    {
        /// <summary>
        /// Indicates that a break on EVERY ENTRY into the script from outside should break into the debugger.
        /// </summary>
        ScriptDebugEventFilterEntry,

        /// <summary>
        /// Indicates that any first chance exception should immediately break into the debugger.
        /// </summary>
        ScriptDebugEventFilterException,

        /// <summary>
        /// ScriptDebugEventFilterUnhandledException: Indicates that unhandled exceptions should immediately break into the debugger.
        /// </summary>
        ScriptDebugEventFilterUnhandledException,

        /// <summary>
        /// Indicates that an abort (core debugger BREAK/STOP this action) should break into the script debugger rather than aborting the script execution.
        /// </summary>
        ScriptDebugEventFilterAbort
    }
}
