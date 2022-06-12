namespace ManagedCorDebug
{
    public struct GetIPResult
    {
        public int PnOffset { get; }

        public CorDebugMappingResult PMappingResult { get; }

        public GetIPResult(int pnOffset, CorDebugMappingResult pMappingResult)
        {
            PnOffset = pnOffset;
            PMappingResult = pMappingResult;
        }
    }
}