using System;

namespace ManagedCorDebug
{
    public struct StrongNameKeyGenExResult
    {
        public IntPtr PpbKeyBlob { get; }

        public uint PcbKeyBlob { get; }

        public StrongNameKeyGenExResult(IntPtr ppbKeyBlob, uint pcbKeyBlob)
        {
            PpbKeyBlob = ppbKeyBlob;
            PcbKeyBlob = pcbKeyBlob;
        }
    }
}