namespace ManagedCorDebug
{
    public struct GetDebugInfoResult
    {
        public ulong PIDD { get; }

        public uint PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoResult(ulong pIDD, uint pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}