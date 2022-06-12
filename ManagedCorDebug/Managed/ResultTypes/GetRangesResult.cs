namespace ManagedCorDebug
{
    public struct GetRangesResult
    {
        public int PcRanges { get; }

        public int[] Ranges { get; }

        public GetRangesResult(int pcRanges, int[] ranges)
        {
            PcRanges = pcRanges;
            Ranges = ranges;
        }
    }
}