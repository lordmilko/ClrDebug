using System;

namespace ManagedCorDebug
{
    public struct GetUserStringResult
    {
        public uint PcbData { get; }

        public IntPtr PpData { get; }

        public GetUserStringResult(uint pcbData, IntPtr ppData)
        {
            PcbData = pcbData;
            PpData = ppData;
        }
    }
}