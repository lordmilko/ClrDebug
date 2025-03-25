using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedAsyncMethod.GetAsyncStepInfo"/> method.
    /// </summary>
    [DebuggerDisplay("yieldOffsets = {yieldOffsets}, breakpointOffset = {breakpointOffset}, breakpointMethod = {breakpointMethod}")]
    public struct GetAsyncStepInfoResult
    {
        public int[] yieldOffsets { get; }

        public int[] breakpointOffset { get; }

        public mdMethodDef[] breakpointMethod { get; }

        public GetAsyncStepInfoResult(int[] yieldOffsets, int[] breakpointOffset, mdMethodDef[] breakpointMethod)
        {
            this.yieldOffsets = yieldOffsets;
            this.breakpointOffset = breakpointOffset;
            this.breakpointMethod = breakpointMethod;
        }
    }
}
