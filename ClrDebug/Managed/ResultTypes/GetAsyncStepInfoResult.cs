using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedAsyncMethod.AsyncStepInfo"/> property.
    /// </summary>
    [DebuggerDisplay("yieldOffsets = {yieldOffsets}, breakpointOffset = {breakpointOffset}, breakpointMethod = {breakpointMethod}")]
    public struct GetAsyncStepInfoResult
    {
        public int[] yieldOffsets { get; }

        public int[] breakpointOffset { get; }

        public int[] breakpointMethod { get; }

        public GetAsyncStepInfoResult(int[] yieldOffsets, int[] breakpointOffset, int[] breakpointMethod)
        {
            this.yieldOffsets = yieldOffsets;
            this.breakpointOffset = breakpointOffset;
            this.breakpointMethod = breakpointMethod;
        }
    }
}