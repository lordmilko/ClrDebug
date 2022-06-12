using System;

namespace ManagedCorDebug
{
    public struct GetExceptionContextRecordResult
    {
        public int BufferUsed { get; }

        public byte Buffer { get; }

        public GetExceptionContextRecordResult(int bufferUsed, byte buffer)
        {
            BufferUsed = bufferUsed;
            Buffer = buffer;
        }
    }
}