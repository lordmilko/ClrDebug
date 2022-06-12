namespace ManagedCorDebug
{
    public struct GetLiveRangeResult
    {
        public int PStartOffset { get; }

        public int PEndOffset { get; }

        public GetLiveRangeResult(int pStartOffset, int pEndOffset)
        {
            PStartOffset = pStartOffset;
            PEndOffset = pEndOffset;
        }
    }
}