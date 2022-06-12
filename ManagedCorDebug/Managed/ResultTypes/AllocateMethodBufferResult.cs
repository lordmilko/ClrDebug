using System;

namespace ManagedCorDebug
{
    public struct AllocateMethodBufferResult
    {
        public IntPtr LpBuffer { get; }

        public int RVA { get; }

        public AllocateMethodBufferResult(IntPtr lpBuffer, int rVA)
        {
            LpBuffer = lpBuffer;
            RVA = rVA;
        }
    }
}