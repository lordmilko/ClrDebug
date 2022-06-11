using System;

namespace ManagedCorDebug
{
    public struct EnumParamsResult
    {
        public IntPtr PhEnum { get; }

        public mdParamDef[] RParams { get; }

        public uint PcTokens { get; }

        public EnumParamsResult(IntPtr phEnum, mdParamDef[] rParams, uint pcTokens)
        {
            PhEnum = phEnum;
            RParams = rParams;
            PcTokens = pcTokens;
        }
    }
}