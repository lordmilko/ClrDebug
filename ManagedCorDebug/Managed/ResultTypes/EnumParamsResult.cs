using System;

namespace ManagedCorDebug
{
    public struct EnumParamsResult
    {
        public IntPtr PhEnum { get; }

        public mdParamDef[] RParams { get; }

        public int PcTokens { get; }

        public EnumParamsResult(IntPtr phEnum, mdParamDef[] rParams, int pcTokens)
        {
            PhEnum = phEnum;
            RParams = rParams;
            PcTokens = pcTokens;
        }
    }
}