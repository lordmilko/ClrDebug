using System;

namespace ManagedCorDebug
{
    public struct GetCodeResult
    {
        public byte[] Buffer { get; }

        public uint PcBufferSize { get; }

        public GetCodeResult(byte[] buffer, uint pcBufferSize)
        {
            Buffer = buffer;
            PcBufferSize = pcBufferSize;
        }
    }
}