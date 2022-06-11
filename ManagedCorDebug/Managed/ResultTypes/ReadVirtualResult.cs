using System;

namespace ManagedCorDebug
{
    public struct ReadVirtualResult
    {
        public byte Buffer { get; }

        public uint BytesRead { get; }

        public ReadVirtualResult(byte buffer, uint bytesRead)
        {
            Buffer = buffer;
            BytesRead = bytesRead;
        }
    }
}