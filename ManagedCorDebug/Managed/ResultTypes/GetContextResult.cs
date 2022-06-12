namespace ManagedCorDebug
{
    public struct GetContextResult
    {
        public int ContextSize { get; }

        public byte ContextBuf { get; }

        public GetContextResult(int contextSize, byte contextBuf)
        {
            ContextSize = contextSize;
            ContextBuf = contextBuf;
        }
    }
}