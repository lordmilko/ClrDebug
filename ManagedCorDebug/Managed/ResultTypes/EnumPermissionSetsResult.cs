using System;

namespace ManagedCorDebug
{
    public struct EnumPermissionSetsResult
    {
        public IntPtr PhEnum { get; }

        public mdPermission[] RPermission { get; }

        public uint PcTokens { get; }

        public EnumPermissionSetsResult(IntPtr phEnum, mdPermission[] rPermission, uint pcTokens)
        {
            PhEnum = phEnum;
            RPermission = rPermission;
            PcTokens = pcTokens;
        }
    }
}