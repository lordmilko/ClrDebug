namespace ManagedCorDebug
{
    public struct GetIPResult
    {
        public uint PnOffset { get; }

        public CorDebugMappingResult PMappingResult { get; }

        public GetIPResult(uint pnOffset, CorDebugMappingResult pMappingResult)
        {
            PnOffset = pnOffset;
            PMappingResult = pMappingResult;
        }
    }
}