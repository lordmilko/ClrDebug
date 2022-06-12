using System;

namespace ManagedCorDebug
{
    public struct EnumMembersResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMembers { get; }

        public int PcTokens { get; }

        public EnumMembersResult(IntPtr phEnum, mdToken[] rMembers, int pcTokens)
        {
            PhEnum = phEnum;
            RMembers = rMembers;
            PcTokens = pcTokens;
        }
    }
}