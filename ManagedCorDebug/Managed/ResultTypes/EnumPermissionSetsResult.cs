using System;

namespace ManagedCorDebug
{
    public struct EnumPermissionSetsResult
    {
        public IntPtr PhEnum { get; }

        public mdPermission[] RPermission { get; }

        public int PcTokens { get; }

        public EnumPermissionSetsResult(IntPtr phEnum, mdPermission[] rPermission, int pcTokens)
        {
            PhEnum = phEnum;
            RPermission = rPermission;
            PcTokens = pcTokens;
        }
    }
}