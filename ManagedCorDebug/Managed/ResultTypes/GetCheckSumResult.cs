namespace ManagedCorDebug
{
    public struct GetCheckSumResult
    {
        public int PcData { get; }

        public byte[] Data { get; }

        public GetCheckSumResult(int pcData, byte[] data)
        {
            PcData = pcData;
            Data = data;
        }
    }
}