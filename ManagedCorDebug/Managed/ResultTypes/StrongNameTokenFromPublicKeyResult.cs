using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromPublicKeyResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public uint PcbStrongNameToken { get; }

        public StrongNameTokenFromPublicKeyResult(IntPtr ppbStrongNameToken, uint pcbStrongNameToken)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
        }
    }
}