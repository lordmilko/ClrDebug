namespace ManagedCorDebug
{
    public struct GetActiveFunctionsResult
    {
        public int PcFunctions { get; }

        public COR_ACTIVE_FUNCTION[] PFunctions { get; }

        public GetActiveFunctionsResult(int pcFunctions, COR_ACTIVE_FUNCTION[] pFunctions)
        {
            PcFunctions = pcFunctions;
            PFunctions = pFunctions;
        }
    }
}