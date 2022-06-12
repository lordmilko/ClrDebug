namespace ManagedCorDebug
{
    public struct GetTypeFieldsResult
    {
        public COR_FIELD Fields { get; }

        public int PceltNeeded { get; }

        public GetTypeFieldsResult(COR_FIELD fields, int pceltNeeded)
        {
            Fields = fields;
            PceltNeeded = pceltNeeded;
        }
    }
}