using System;

namespace ManagedCorDebug
{
    public struct GetExceptionRecordResult
    {
        public uint BufferUsed { get; }

        public byte Buffer { get; }

        public GetExceptionRecordResult(uint bufferUsed, byte buffer)
        {
            BufferUsed = bufferUsed;
            Buffer = buffer;
        }
    }
}