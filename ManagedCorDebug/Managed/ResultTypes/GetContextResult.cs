namespace ManagedCorDebug
{
    public struct GetContextResult
    {
        public uint ContextSize { get; }

        public byte ContextBuf { get; }

        public GetContextResult(uint contextSize, byte contextBuf)
        {
            ContextSize = contextSize;
            ContextBuf = contextBuf;
        }
    }
}