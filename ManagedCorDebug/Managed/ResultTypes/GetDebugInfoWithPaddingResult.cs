namespace ManagedCorDebug
{
    public struct GetDebugInfoWithPaddingResult
    {
        public long PIDD { get; }

        public int PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoWithPaddingResult(long pIDD, int pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}