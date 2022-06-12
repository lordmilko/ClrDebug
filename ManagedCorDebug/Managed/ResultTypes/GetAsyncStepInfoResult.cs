namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedAsyncMethod.GetAsyncStepInfo"/> method.
    /// </summary>
    public struct GetAsyncStepInfoResult
    {
        public int pcStepInfo { get; }

        public int[] yieldOffsets { get; }

        public int[] breakpointOffset { get; }

        public int[] breakpointMethod { get; }

        public GetAsyncStepInfoResult(int pcStepInfo, int[] yieldOffsets, int[] breakpointOffset, int[] breakpointMethod)
        {
            this.pcStepInfo = pcStepInfo;
            this.yieldOffsets = yieldOffsets;
            this.breakpointOffset = breakpointOffset;
            this.breakpointMethod = breakpointMethod;
        }
    }
}