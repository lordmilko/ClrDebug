namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the current debugging state of a script.
    /// </summary>
    public enum ScriptDebugState : uint
    {
        /// <summary>
        /// Indicates that debugging is not active on the script.
        /// </summary>
        ScriptDebugNoDebugger,

        /// <summary>
        /// Indicates that no code within the script is actively executing.
        /// </summary>
        ScriptDebugNotExecuting,

        /// <summary>
        /// Indicates that the script is executing code.
        /// </summary>
        ScriptDebugExecuting,

        /// <summary>
        /// The script status is that it is broken into the script debugger.
        /// </summary>
        ScriptDebugBreak
    }
}
