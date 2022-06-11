namespace ManagedCorDebug
{
    public struct GetCodeChunksResult
    {
        public uint PcnumChunks { get; }

        public CodeChunkInfo[] Chunks { get; }

        public GetCodeChunksResult(uint pcnumChunks, CodeChunkInfo[] chunks)
        {
            PcnumChunks = pcnumChunks;
            Chunks = chunks;
        }
    }
}