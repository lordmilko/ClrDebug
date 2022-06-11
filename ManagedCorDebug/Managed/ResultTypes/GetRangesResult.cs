namespace ManagedCorDebug
{
    public struct GetRangesResult
    {
        public uint PcRanges { get; }

        public uint[] Ranges { get; }

        public GetRangesResult(uint pcRanges, uint[] ranges)
        {
            PcRanges = pcRanges;
            Ranges = ranges;
        }
    }
}