namespace ManagedCorDebug
{
    public struct GetDebugInfoResult
    {
        public long PIDD { get; }

        public int PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoResult(long pIDD, int pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}