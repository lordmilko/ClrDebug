using System;

namespace ManagedCorDebug
{
    public struct StrongNameKeyGenResult
    {
        public IntPtr PpbKeyBlob { get; }

        public int PcbKeyBlob { get; }

        public StrongNameKeyGenResult(IntPtr ppbKeyBlob, int pcbKeyBlob)
        {
            PpbKeyBlob = ppbKeyBlob;
            PcbKeyBlob = pcbKeyBlob;
        }
    }
}