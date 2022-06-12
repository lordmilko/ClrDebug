namespace ManagedCorDebug
{
    public struct GetValueResult
    {
        public int PcbValue { get; }

        public byte[] PValue { get; }

        public GetValueResult(int pcbValue, byte[] pValue)
        {
            PcbValue = pcbValue;
            PValue = pValue;
        }
    }
}