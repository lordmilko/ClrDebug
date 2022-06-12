namespace ManagedCorDebug
{
    public struct CorDebugDataTarget_ReadVirtualResult
    {
        public byte PBuffer { get; }

        public int PBytesRead { get; }

        public CorDebugDataTarget_ReadVirtualResult(byte pBuffer, int pBytesRead)
        {
            PBuffer = pBuffer;
            PBytesRead = pBytesRead;
        }
    }
}