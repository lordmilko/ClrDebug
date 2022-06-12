using System;

namespace ManagedCorDebug
{
    public struct GetParametersResult
    {
        public int PcParams { get; }

        public IntPtr Params { get; }

        public GetParametersResult(int pcParams, IntPtr @params)
        {
            PcParams = pcParams;
            Params = @params;
        }
    }
}