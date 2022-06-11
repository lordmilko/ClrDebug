using System;

namespace ManagedCorDebug
{
    public struct GetParametersResult
    {
        public uint PcParams { get; }

        public IntPtr Params { get; }

        public GetParametersResult(uint pcParams, IntPtr @params)
        {
            PcParams = pcParams;
            Params = @params;
        }
    }
}