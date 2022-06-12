using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromAssemblyResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public int PcbStrongNameToken { get; }

        public StrongNameTokenFromAssemblyResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
        }
    }
}