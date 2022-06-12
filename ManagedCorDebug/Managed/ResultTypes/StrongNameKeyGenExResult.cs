using System;

namespace ManagedCorDebug
{
    public struct StrongNameKeyGenExResult
    {
        public IntPtr PpbKeyBlob { get; }

        public int PcbKeyBlob { get; }

        public StrongNameKeyGenExResult(IntPtr ppbKeyBlob, int pcbKeyBlob)
        {
            PpbKeyBlob = ppbKeyBlob;
            PcbKeyBlob = pcbKeyBlob;
        }
    }
}