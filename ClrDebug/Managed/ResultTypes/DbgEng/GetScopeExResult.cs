using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetScopeEx"/> method.
    /// </summary>
    [DebuggerDisplay("InstructionOffset = {InstructionOffset}, ScopeFrame = {ScopeFrame.ToString(),nq}")]
    public struct GetScopeExResult
    {
        /// <summary>
        /// The offset of the instruction for the scope.
        /// </summary>
        public ulong InstructionOffset { get; }

        /// <summary>
        /// The scope frame returned as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.
        /// </summary>
        public DEBUG_STACK_FRAME_EX ScopeFrame { get; }

        public GetScopeExResult(ulong instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame)
        {
            InstructionOffset = instructionOffset;
            ScopeFrame = scopeFrame;
        }
    }
}
