using System;

namespace ManagedCorDebug
{
    public struct GetSymAttributeResult
    {
        public int PcBuffer { get; }

        public byte[] Buffer { get; }

        public GetSymAttributeResult(int pcBuffer, byte[] buffer)
        {
            PcBuffer = pcBuffer;
            Buffer = buffer;
        }
    }
}