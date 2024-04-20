using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DbgEngExtensions.GetScopeEx{T}"/> method.
    /// </summary>
    [DebuggerDisplay("InstructionOffset = {InstructionOffset.ToString(\"X\"),nq}, ScopeFrame = {ScopeFrame.ToString(),nq}")]
    public struct GetScopeExResult<T>
    {
        /// <summary>
        /// A pointer to the scope context returned.
        /// </summary>
        public T Context { get; }

        /// <summary>
        /// The offset of the instruction for the scope.
        /// </summary>
        public long InstructionOffset { get; }

        /// <summary>
        /// The scope frame returned as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.
        /// </summary>
        public DEBUG_STACK_FRAME_EX ScopeFrame { get; }

        public GetScopeExResult(in T context, long instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame)
        {
            Context = context;
            InstructionOffset = instructionOffset;
            ScopeFrame = scopeFrame;
        }
    }
}
