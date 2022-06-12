using System;

namespace ManagedCorDebug
{
    public struct ReadMemoryResult
    {
        public byte[] Buffer { get; }

        public long Read { get; }

        public ReadMemoryResult(byte[] buffer, long read)
        {
            Buffer = buffer;
            Read = read;
        }
    }
}