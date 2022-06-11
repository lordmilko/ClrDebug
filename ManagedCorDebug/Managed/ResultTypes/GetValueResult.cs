namespace ManagedCorDebug
{
    public struct GetValueResult
    {
        public uint PcbValue { get; }

        public byte[] PValue { get; }

        public GetValueResult(uint pcbValue, byte[] pValue)
        {
            PcbValue = pcbValue;
            PValue = pValue;
        }
    }
}