using System;

namespace ManagedCorDebug
{
    public struct GetSourceServerDataResult
    {
        public uint PDataByteCount { get; }

        public IntPtr PpData { get; }

        public GetSourceServerDataResult(uint pDataByteCount, IntPtr ppData)
        {
            PDataByteCount = pDataByteCount;
            PpData = ppData;
        }
    }
}