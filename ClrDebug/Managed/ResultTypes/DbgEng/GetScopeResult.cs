using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetScope"/> method.
    /// </summary>
    [DebuggerDisplay("InstructionOffset = {InstructionOffset}, ScopeFrame = {ScopeFrame.ToString(),nq}")]
    public struct GetScopeResult
    {
        /// <summary>
        /// Receives the location in the process's virtual address space of the current scope's current instruction.
        /// </summary>
        public ulong InstructionOffset { get; }

        /// <summary>
        /// Receives the <see cref="DEBUG_STACK_FRAME"/> structure representing the current scope's stack frame.
        /// </summary>
        public DEBUG_STACK_FRAME ScopeFrame { get; }

        public GetScopeResult(ulong instructionOffset, DEBUG_STACK_FRAME scopeFrame)
        {
            InstructionOffset = instructionOffset;
            ScopeFrame = scopeFrame;
        }
    }
}
