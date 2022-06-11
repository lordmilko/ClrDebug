using System;

namespace ManagedCorDebug
{
    public struct GetSymAttributeResult
    {
        public uint PcBuffer { get; }

        public byte[] Buffer { get; }

        public GetSymAttributeResult(uint pcBuffer, byte[] buffer)
        {
            PcBuffer = pcBuffer;
            Buffer = buffer;
        }
    }
}