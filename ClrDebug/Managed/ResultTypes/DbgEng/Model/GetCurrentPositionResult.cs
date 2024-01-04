using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelScriptDebug.CurrentPosition"/> property.
    /// </summary>
    [DebuggerDisplay("currentPosition = {currentPosition.ToString(),nq}, positionSpanEnd = {positionSpanEnd.ToString(),nq}, lineText = {lineText}")]
    public struct GetCurrentPositionResult
    {
        /// <summary>
        /// The current break position of the script must be returned here. The Line and Column fields of the returned structure are one based.<para/>
        /// A zero value in either indicates that the information is unavailable.
        /// </summary>
        public ScriptDebugPosition currentPosition { get; }

        /// <summary>
        /// If the debugger is capable of determining the full span of the break position, the ending position of the span can be returned here.<para/>
        /// If not, zero values should be filled into the Line and Column fields of the returned structure.
        /// </summary>
        public ScriptDebugPosition positionSpanEnd { get; }

        /// <summary>
        /// If the debugger is capable of returning the source code for the line (or the span) of the break, such can be returned here as a string allocated by the SysAllocString function.<para/>
        /// The caller is responsible for freeing the returned string with SysFreeString. If the debugger is incapable of producing this source information, nullptr should be returned.
        /// </summary>
        public string lineText { get; }

        public GetCurrentPositionResult(ScriptDebugPosition currentPosition, ScriptDebugPosition positionSpanEnd, string lineText)
        {
            this.currentPosition = currentPosition;
            this.positionSpanEnd = positionSpanEnd;
            this.lineText = lineText;
        }
    }
}
