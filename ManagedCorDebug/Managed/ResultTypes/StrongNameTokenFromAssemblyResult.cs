using System;

namespace ManagedCorDebug
{
    public struct StrongNameTokenFromAssemblyResult
    {
        public IntPtr PpbStrongNameToken { get; }

        public uint PcbStrongNameToken { get; }

        public StrongNameTokenFromAssemblyResult(IntPtr ppbStrongNameToken, uint pcbStrongNameToken)
        {
            PpbStrongNameToken = ppbStrongNameToken;
            PcbStrongNameToken = pcbStrongNameToken;
        }
    }
}