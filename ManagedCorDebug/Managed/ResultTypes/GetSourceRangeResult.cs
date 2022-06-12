namespace ManagedCorDebug
{
    public struct GetSourceRangeResult
    {
        public int PcSourceBytes { get; }

        public byte[] Source { get; }

        public GetSourceRangeResult(int pcSourceBytes, byte[] source)
        {
            PcSourceBytes = pcSourceBytes;
            Source = source;
        }
    }
}