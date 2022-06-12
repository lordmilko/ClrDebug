namespace ManagedCorDebug
{
    public struct GetCodeChunksResult
    {
        public int PcnumChunks { get; }

        public CodeChunkInfo[] Chunks { get; }

        public GetCodeChunksResult(int pcnumChunks, CodeChunkInfo[] chunks)
        {
            PcnumChunks = pcnumChunks;
            Chunks = chunks;
        }
    }
}