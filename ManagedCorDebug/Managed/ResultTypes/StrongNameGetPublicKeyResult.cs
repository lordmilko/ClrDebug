using System;

namespace ManagedCorDebug
{
    public struct StrongNameGetPublicKeyResult
    {
        public IntPtr PpbPublicKeyBlob { get; }

        public int PcbPublicKeyBlob { get; }

        public StrongNameGetPublicKeyResult(IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            PpbPublicKeyBlob = ppbPublicKeyBlob;
            PcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}