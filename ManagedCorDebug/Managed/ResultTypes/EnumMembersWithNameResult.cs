using System;

namespace ManagedCorDebug
{
    public struct EnumMembersWithNameResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMembers { get; }

        public uint PcTokens { get; }

        public EnumMembersWithNameResult(IntPtr phEnum, mdToken[] rMembers, uint pcTokens)
        {
            PhEnum = phEnum;
            RMembers = rMembers;
            PcTokens = pcTokens;
        }
    }
}