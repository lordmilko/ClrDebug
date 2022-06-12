using System;

namespace ManagedCorDebug
{
    public struct GetSymAttributePreRemapResult
    {
        public int PcBuffer { get; }

        public byte[] Buffer { get; }

        public GetSymAttributePreRemapResult(int pcBuffer, byte[] buffer)
        {
            PcBuffer = pcBuffer;
            Buffer = buffer;
        }
    }
}