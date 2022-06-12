using System;

namespace ManagedCorDebug
{
    public struct EnumMembersWithNameResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMembers { get; }

        public int PcTokens { get; }

        public EnumMembersWithNameResult(IntPtr phEnum, mdToken[] rMembers, int pcTokens)
        {
            PhEnum = phEnum;
            RMembers = rMembers;
            PcTokens = pcTokens;
        }
    }
}