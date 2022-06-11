using System;

namespace ManagedCorDebug
{
    public struct AllocateMethodBufferResult
    {
        public IntPtr LpBuffer { get; }

        public uint RVA { get; }

        public AllocateMethodBufferResult(IntPtr lpBuffer, uint rVA)
        {
            LpBuffer = lpBuffer;
            RVA = rVA;
        }
    }
}