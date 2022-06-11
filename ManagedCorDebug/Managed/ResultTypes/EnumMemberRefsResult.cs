using System;

namespace ManagedCorDebug
{
    public struct EnumMemberRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdMemberRef[] RMemberRefs { get; }

        public uint PcTokens { get; }

        public EnumMemberRefsResult(IntPtr phEnum, mdMemberRef[] rMemberRefs, uint pcTokens)
        {
            PhEnum = phEnum;
            RMemberRefs = rMemberRefs;
            PcTokens = pcTokens;
        }
    }
}