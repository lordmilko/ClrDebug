namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of execution to do.
    /// </summary>
    public enum ScriptExecutionKind : uint
    {
        /// <summary>
        /// Indicates that you would like the script to execute normally
        /// </summary>
        ScriptExecutionNormal,

        /// <summary>
        /// Indicates that you want to perform a "step in" operation
        /// </summary>
        ScriptExecutionStepIn,

        /// <summary>
        /// Indicates that you want to perform a "step out" operation
        /// </summary>
        ScriptExecutionStepOut,

        /// <summary>
        /// Indicates that you want to perform a "step over" operation
        /// </summary>
        ScriptExecutionStepOver
    }
}
