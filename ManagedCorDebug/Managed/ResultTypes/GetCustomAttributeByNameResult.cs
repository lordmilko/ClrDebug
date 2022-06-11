using System;

namespace ManagedCorDebug
{
    public struct GetCustomAttributeByNameResult
    {
        public IntPtr PpData { get; }

        public uint PcbData { get; }

        public GetCustomAttributeByNameResult(IntPtr ppData, uint pcbData)
        {
            PpData = ppData;
            PcbData = pcbData;
        }
    }
}