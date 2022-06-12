using System;

namespace ManagedCorDebug
{
    public struct EnumMethodImplsResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMethodBody { get; }

        public mdToken[] RMethodDecl { get; }

        public int PcTokens { get; }

        public EnumMethodImplsResult(IntPtr phEnum, mdToken[] rMethodBody, mdToken[] rMethodDecl, int pcTokens)
        {
            PhEnum = phEnum;
            RMethodBody = rMethodBody;
            RMethodDecl = rMethodDecl;
            PcTokens = pcTokens;
        }
    }
}