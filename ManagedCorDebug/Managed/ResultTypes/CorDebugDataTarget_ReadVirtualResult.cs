namespace ManagedCorDebug
{
    public struct CorDebugDataTarget_ReadVirtualResult
    {
        public byte PBuffer { get; }

        public uint PBytesRead { get; }

        public CorDebugDataTarget_ReadVirtualResult(byte pBuffer, uint pBytesRead)
        {
            PBuffer = pBuffer;
            PBytesRead = pBytesRead;
        }
    }
}