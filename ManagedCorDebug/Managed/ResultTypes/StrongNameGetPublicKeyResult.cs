using System;

namespace ManagedCorDebug
{
    public struct StrongNameGetPublicKeyResult
    {
        public IntPtr PpbPublicKeyBlob { get; }

        public uint PcbPublicKeyBlob { get; }

        public StrongNameGetPublicKeyResult(IntPtr ppbPublicKeyBlob, uint pcbPublicKeyBlob)
        {
            PpbPublicKeyBlob = ppbPublicKeyBlob;
            PcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}