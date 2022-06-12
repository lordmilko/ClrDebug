namespace ManagedCorDebug
{
    public struct GetEnCRemapSequencePointsResult
    {
        public int PcMap { get; }

        public int[] Offsets { get; }

        public GetEnCRemapSequencePointsResult(int pcMap, int[] offsets)
        {
            PcMap = pcMap;
            Offsets = offsets;
        }
    }
}