namespace ManagedCorDebug
{
    public struct GetCheckSumResult
    {
        public uint PcData { get; }

        public byte[] Data { get; }

        public GetCheckSumResult(uint pcData, byte[] data)
        {
            PcData = pcData;
            Data = data;
        }
    }
}