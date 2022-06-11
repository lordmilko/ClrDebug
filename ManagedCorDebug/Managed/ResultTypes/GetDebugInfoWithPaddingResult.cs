namespace ManagedCorDebug
{
    public struct GetDebugInfoWithPaddingResult
    {
        public ulong PIDD { get; }

        public uint PcData { get; }

        public byte[] Data { get; }

        public GetDebugInfoWithPaddingResult(ulong pIDD, uint pcData, byte[] data)
        {
            PIDD = pIDD;
            PcData = pcData;
            Data = data;
        }
    }
}