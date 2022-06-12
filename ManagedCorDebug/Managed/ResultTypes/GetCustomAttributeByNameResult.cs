using System;

namespace ManagedCorDebug
{
    public struct GetCustomAttributeByNameResult
    {
        public IntPtr PpData { get; }

        public int PcbData { get; }

        public GetCustomAttributeByNameResult(IntPtr ppData, int pcbData)
        {
            PpData = ppData;
            PcbData = pcbData;
        }
    }
}