using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelScriptDebugStackFrame.Position"/> property.
    /// </summary>
    [DebuggerDisplay("position = {position.ToString(),nq}, positionSpanEnd = {positionSpanEnd.ToString(),nq}, lineText = {lineText}")]
    public struct GetPositionResult
    {
        /// <summary>
        /// The debugger should fill in the line and column positions of the frame in this argument.
        /// </summary>
        public ScriptDebugPosition position { get; }

        /// <summary>
        /// The caller can optionally request the end of the span of text representing this stack frame by passing a non-nullptr value here.<para/>
        /// If the debugger can support such a request, it returns the line and column positions here; otherwise, the Line and Column fields of the data structure should be set to zero indicating that the values cannot be determined.
        /// </summary>
        public ScriptDebugPosition positionSpanEnd { get; }

        /// <summary>
        /// The caller can optionally request the line of source code (or the span) representing the frame position. If the debugger is capable of returning this, it should return such here as a string allocated by the SysAllocString function.<para/>
        /// The caller is responsible for freeing the allocated string with SysFreeString. If the debugger is not capable of returning this, nullptr should be returned here.
        /// </summary>
        public string lineText { get; }

        public GetPositionResult(ScriptDebugPosition position, ScriptDebugPosition positionSpanEnd, string lineText)
        {
            this.position = position;
            this.positionSpanEnd = positionSpanEnd;
            this.lineText = lineText;
        }
    }
}
