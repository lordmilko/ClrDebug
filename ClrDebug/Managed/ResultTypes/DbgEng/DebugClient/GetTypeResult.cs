using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugBreakpoint.Type"/> property.
    /// </summary>
    [DebuggerDisplay("BreakType = {BreakType.ToString(),nq}, ProcType = {ProcType}")]
    public struct GetTypeResult
    {
        /// <summary>
        /// The type of the breakpoint. The type can be one of the following values.
        /// </summary>
        public DEBUG_BREAKPOINT_TYPE BreakType { get; }

        /// <summary>
        /// The type of the processor that the breakpoint is set for.
        /// </summary>
        public int ProcType { get; }

        public GetTypeResult(DEBUG_BREAKPOINT_TYPE breakType, int procType)
        {
            BreakType = breakType;
            ProcType = procType;
        }
    }
}
