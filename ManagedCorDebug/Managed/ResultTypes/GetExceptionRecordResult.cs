using System;

namespace ManagedCorDebug
{
    public struct GetExceptionRecordResult
    {
        public int BufferUsed { get; }

        public byte Buffer { get; }

        public GetExceptionRecordResult(int bufferUsed, byte buffer)
        {
            BufferUsed = bufferUsed;
            Buffer = buffer;
        }
    }
}