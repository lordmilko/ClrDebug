using System;

namespace ManagedCorDebug
{
    public struct GetSymAttributePreRemapResult
    {
        public uint PcBuffer { get; }

        public byte[] Buffer { get; }

        public GetSymAttributePreRemapResult(uint pcBuffer, byte[] buffer)
        {
            PcBuffer = pcBuffer;
            Buffer = buffer;
        }
    }
}