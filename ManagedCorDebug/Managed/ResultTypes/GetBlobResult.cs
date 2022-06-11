using System;

namespace ManagedCorDebug
{
    public struct GetBlobResult
    {
        public uint PcbData { get; }

        public IntPtr PpData { get; }

        public GetBlobResult(uint pcbData, IntPtr ppData)
        {
            PcbData = pcbData;
            PpData = ppData;
        }
    }
}