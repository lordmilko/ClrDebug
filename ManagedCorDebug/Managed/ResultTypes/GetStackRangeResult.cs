namespace ManagedCorDebug
{
    public struct GetStackRangeResult
    {
        public CORDB_ADDRESS PStart { get; }

        public CORDB_ADDRESS PEnd { get; }

        public GetStackRangeResult(CORDB_ADDRESS pStart, CORDB_ADDRESS pEnd)
        {
            PStart = pStart;
            PEnd = pEnd;
        }
    }
}