namespace ManagedCorDebug
{
    public struct GetTypeFieldsResult
    {
        public COR_FIELD Fields { get; }

        public uint PceltNeeded { get; }

        public GetTypeFieldsResult(COR_FIELD fields, uint pceltNeeded)
        {
            Fields = fields;
            PceltNeeded = pceltNeeded;
        }
    }
}