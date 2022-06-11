namespace ManagedCorDebug
{
    public struct GetReturnValueLiveOffsetResult
    {
        public uint PFetched { get; }

        public uint POffsets { get; }

        public GetReturnValueLiveOffsetResult(uint pFetched, uint pOffsets)
        {
            PFetched = pFetched;
            POffsets = pOffsets;
        }
    }
}