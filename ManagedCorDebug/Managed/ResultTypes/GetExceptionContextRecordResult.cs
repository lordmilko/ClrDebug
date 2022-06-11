using System;

namespace ManagedCorDebug
{
    public struct GetExceptionContextRecordResult
    {
        public uint BufferUsed { get; }

        public byte Buffer { get; }

        public GetExceptionContextRecordResult(uint bufferUsed, byte buffer)
        {
            BufferUsed = bufferUsed;
            Buffer = buffer;
        }
    }
}