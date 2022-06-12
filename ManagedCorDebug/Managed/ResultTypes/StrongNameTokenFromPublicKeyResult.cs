using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromPublicKeyResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public int PcbStrongNameToken { get; }

        public StrongNameTokenFromPublicKeyResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
        }
    }
}