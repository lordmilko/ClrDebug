namespace ManagedCorDebug
{
    public struct GetSourceRangeResult
    {
        public uint PcSourceBytes { get; }

        public byte[] Source { get; }

        public GetSourceRangeResult(uint pcSourceBytes, byte[] source)
        {
            PcSourceBytes = pcSourceBytes;
            Source = source;
        }
    }
}