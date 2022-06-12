using System;

namespace ManagedCorDebug
{
    public struct GetBlobResult
    {
        public int PcbData { get; }

        public IntPtr PpData { get; }

        public GetBlobResult(int pcbData, IntPtr ppData)
        {
            PcbData = pcbData;
            PpData = ppData;
        }
    }
}