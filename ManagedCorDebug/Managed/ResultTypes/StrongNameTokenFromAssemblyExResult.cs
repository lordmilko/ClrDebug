using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromAssemblyExResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public uint PcbStrongNameToken { get; }

        public IntPtr PpbPublicKeyBlob { get; }

        public uint PcbPublicKeyBlob { get; }

        public StrongNameTokenFromAssemblyExResult(IntPtr ppbStrongNameToken, uint pcbStrongNameToken, IntPtr ppbPublicKeyBlob, uint pcbPublicKeyBlob)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
            PpbPublicKeyBlob = ppbPublicKeyBlob;
            PcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}