using System;

namespace ManagedCorDebug
{
    public struct EnumMemberRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdMemberRef[] RMemberRefs { get; }

        public int PcTokens { get; }

        public EnumMemberRefsResult(IntPtr phEnum, mdMemberRef[] rMemberRefs, int pcTokens)
        {
            PhEnum = phEnum;
            RMemberRefs = rMemberRefs;
            PcTokens = pcTokens;
        }
    }
}