using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_BREAKPOINT_PARAMETERS structure contains most of the parameters for describing a breakpoint.
    /// </summary>
    /// <remarks>
    /// For an overview of how to use breakpoints, and a description of all breakpoint-related methods, see Breakpoints.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_BREAKPOINT_PARAMETERS
    {
        /// <summary>
        /// The location in the target's memory address space that will trigger the breakpoint. If the breakpoint is deferred (see <see cref="IDebugBreakpoint.GetFlags"/>), Offset is DEBUG_INVALID_OFFSET.<para/>
        /// See <see cref="IDebugBreakpoint.GetOffset"/>.
        /// </summary>
        public long Offset;

        /// <summary>
        /// The breakpoint ID. See <see cref="IDebugBreakpoint.GetId"/>.
        /// </summary>
        public int Id;

        /// <summary>
        /// Specifies if the breakpoint is a software breakpoint or a processor breakpoint. See GetType.
        /// </summary>
        public DEBUG_BREAKPOINT_TYPE BreakType;

        /// <summary>
        /// The processor type for which the breakpoint is set. See GetType.
        /// </summary>
        public int ProcType;

        /// <summary>
        /// The flags for the breakpoint. See <see cref="IDebugBreakpoint.GetFlags"/>.
        /// </summary>
        public DEBUG_BREAKPOINT_FLAG Flags;

        /// <summary>
        /// The size, in bytes, of the memory block whose access will trigger the breakpoint. If the type of the breakpoint is not a data breakpoint, this is zero.<para/>
        /// See <see cref="IDebugBreakpoint.GetDataParameters"/>.
        /// </summary>
        public int DataSize;

        /// <summary>
        /// The type of access that will trigger the breakpoint. If the type of the breakpoint is not a data breakpoint, this is zero.<para/>
        /// See <see cref="IDebugBreakpoint.GetDataParameters"/>.
        /// </summary>
        public DEBUG_BREAKPOINT_ACCESS_TYPE DataAccessType;

        /// <summary>
        /// The number of times the target will hit the breakpoint before it is triggered. See <see cref="IDebugBreakpoint.GetPassCount"/>.
        /// </summary>
        public int PassCount;

        /// <summary>
        /// The remaining number of times that the target will hit the breakpoint before it is triggered. See <see cref="IDebugBreakpoint.GetCurrentPassCount"/>.
        /// </summary>
        public int CurrentPassCount;

        /// <summary>
        /// The engine thread ID of the thread that can trigger this breakpoint. If any thread can trigger this breakpoint, MatchThread is DEBUG_ANY_ID.<para/>
        /// See <see cref="IDebugBreakpoint.GetMatchThreadId"/>.
        /// </summary>
        public int MatchThread;

        /// <summary>
        /// The size, in characters, of the command string that will be executed when the breakpoint is triggered. If no command is set, CommandSize is zero.<para/>
        /// See <see cref="IDebugBreakpoint.GetCommand"/>.
        /// </summary>
        public int CommandSize;

        /// <summary>
        /// The size, in characters, of the expression string that evaluates to the location in the target's memory address space where the breakpoint is triggered.<para/>
        /// If no expression string is set, OffsetExpressionSize is zero. See <see cref="IDebugBreakpoint.GetOffsetExpression"/>.
        /// </summary>
        public int OffsetExpressionSize;
    }
}