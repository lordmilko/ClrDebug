using System;

namespace ManagedCorDebug
{
    public struct StrongNameKeyGenResult
    {
        public IntPtr PpbKeyBlob { get; }

        public uint PcbKeyBlob { get; }

        public StrongNameKeyGenResult(IntPtr ppbKeyBlob, uint pcbKeyBlob)
        {
            PpbKeyBlob = ppbKeyBlob;
            PcbKeyBlob = pcbKeyBlob;
        }
    }
}