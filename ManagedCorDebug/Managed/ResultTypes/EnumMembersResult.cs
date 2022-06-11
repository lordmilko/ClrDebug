using System;

namespace ManagedCorDebug
{
    public struct EnumMembersResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMembers { get; }

        public uint PcTokens { get; }

        public EnumMembersResult(IntPtr phEnum, mdToken[] rMembers, uint pcTokens)
        {
            PhEnum = phEnum;
            RMembers = rMembers;
            PcTokens = pcTokens;
        }
    }
}