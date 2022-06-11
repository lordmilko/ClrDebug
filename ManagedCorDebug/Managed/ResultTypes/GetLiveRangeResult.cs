namespace ManagedCorDebug
{
    public struct GetLiveRangeResult
    {
        public uint PStartOffset { get; }

        public uint PEndOffset { get; }

        public GetLiveRangeResult(uint pStartOffset, uint pEndOffset)
        {
            PStartOffset = pStartOffset;
            PEndOffset = pEndOffset;
        }
    }
}