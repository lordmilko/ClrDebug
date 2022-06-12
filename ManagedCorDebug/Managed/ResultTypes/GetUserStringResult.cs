using System;

namespace ManagedCorDebug
{
    public struct GetUserStringResult
    {
        public int PcbData { get; }

        public IntPtr PpData { get; }

        public GetUserStringResult(int pcbData, IntPtr ppData)
        {
            PcbData = pcbData;
            PpData = ppData;
        }
    }
}