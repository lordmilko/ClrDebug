namespace ManagedCorDebug
{
    public struct GetActiveFunctionsResult
    {
        public uint PcFunctions { get; }

        public COR_ACTIVE_FUNCTION[] PFunctions { get; }

        public GetActiveFunctionsResult(uint pcFunctions, COR_ACTIVE_FUNCTION[] pFunctions)
        {
            PcFunctions = pcFunctions;
            PFunctions = pFunctions;
        }
    }
}