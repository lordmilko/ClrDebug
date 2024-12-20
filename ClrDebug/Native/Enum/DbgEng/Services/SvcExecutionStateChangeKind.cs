namespace ClrDebug.DbgEng
{
    public enum SvcExecutionStateChangeKind : uint
    {
        /// <summary>
        /// The target has (or is about to) resume execution.
        /// </summary>
        SvcExecutionStateContinue,

        /// <summary>
        /// The target has (or is about to) break into the debugger.
        /// </summary>
        SvcExecutionStateBreak
    }
}
