namespace ManagedCorDebug
{
    public struct GetReturnValueLiveOffsetResult
    {
        public int PFetched { get; }

        public int POffsets { get; }

        public GetReturnValueLiveOffsetResult(int pFetched, int pOffsets)
        {
            PFetched = pFetched;
            POffsets = pOffsets;
        }
    }
}