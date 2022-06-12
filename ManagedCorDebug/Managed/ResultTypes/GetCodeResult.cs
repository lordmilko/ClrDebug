using System;

namespace ManagedCorDebug
{
    public struct GetCodeResult
    {
        public byte[] Buffer { get; }

        public int PcBufferSize { get; }

        public GetCodeResult(byte[] buffer, int pcBufferSize)
        {
            Buffer = buffer;
            PcBufferSize = pcBufferSize;
        }
    }
}