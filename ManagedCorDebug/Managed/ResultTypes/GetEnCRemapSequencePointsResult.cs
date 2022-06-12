using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetEnCRemapSequencePoints"/> method.
    /// </summary>
    [DebuggerDisplay("pcMap = {pcMap}, offsets = {offsets}")]
    public struct GetEnCRemapSequencePointsResult
    {
        public int pcMap { get; }

        public int[] offsets { get; }

        public GetEnCRemapSequencePointsResult(int pcMap, int[] offsets)
        {
            this.pcMap = pcMap;
            this.offsets = offsets;
        }
    }
}