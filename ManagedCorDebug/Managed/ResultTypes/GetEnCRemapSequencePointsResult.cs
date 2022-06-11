namespace ManagedCorDebug
{
    public struct GetEnCRemapSequencePointsResult
    {
        public uint PcMap { get; }

        public uint[] Offsets { get; }

        public GetEnCRemapSequencePointsResult(uint pcMap, uint[] offsets)
        {
            PcMap = pcMap;
            Offsets = offsets;
        }
    }
}