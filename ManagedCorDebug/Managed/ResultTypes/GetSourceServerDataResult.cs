using System;

namespace ManagedCorDebug
{
    public struct GetSourceServerDataResult
    {
        public int PDataByteCount { get; }

        public IntPtr PpData { get; }

        public GetSourceServerDataResult(int pDataByteCount, IntPtr ppData)
        {
            PDataByteCount = pDataByteCount;
            PpData = ppData;
        }
    }
}