using System;

namespace ManagedCorDebug
{
    public struct ReadVirtualResult
    {
        public byte Buffer { get; }

        public int BytesRead { get; }

        public ReadVirtualResult(byte buffer, int bytesRead)
        {
            Buffer = buffer;
            BytesRead = bytesRead;
        }
    }
}