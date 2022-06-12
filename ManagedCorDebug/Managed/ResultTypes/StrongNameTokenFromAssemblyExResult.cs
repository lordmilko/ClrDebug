using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromAssemblyExResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public int PcbStrongNameToken { get; }

        public IntPtr PpbPublicKeyBlob { get; }

        public int PcbPublicKeyBlob { get; }

        public StrongNameTokenFromAssemblyExResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken, IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
            PpbPublicKeyBlob = ppbPublicKeyBlob;
            PcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}