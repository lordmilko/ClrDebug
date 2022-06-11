using System;

namespace ManagedCorDebug
{
    public struct ReadMemoryResult
    {
        public byte[] Buffer { get; }

        public ulong Read { get; }

        public ReadMemoryResult(byte[] buffer, ulong read)
        {
            Buffer = buffer;
            Read = read;
        }
    }
}