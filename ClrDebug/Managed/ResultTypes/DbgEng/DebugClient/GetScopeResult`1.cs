using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DbgEngExtensions.GetScope{T}"/> method.
    /// </summary>
    [DebuggerDisplay("InstructionOffset = {InstructionOffset.ToString(\"X\"),nq}, ScopeFrame = {ScopeFrame.ToString(),nq}")]
    public struct GetScopeResult<T>
    {
        /// <summary>
        /// Receives the current scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.
        /// </summary>
        public T Context { get; }

        /// <summary>
        /// Receives the location in the process's virtual address space of the current scope's current instruction.
        /// </summary>
        public long InstructionOffset { get; }

        /// <summary>
        /// Receives the <see cref="DEBUG_STACK_FRAME"/> structure representing the current scope's stack frame.
        /// </summary>
        public DEBUG_STACK_FRAME ScopeFrame { get; }

        public GetScopeResult(in T context, long instructionOffset, DEBUG_STACK_FRAME scopeFrame)
        {
            Context = context;
            InstructionOffset = instructionOffset;
            ScopeFrame = scopeFrame;
        }
    }
}
