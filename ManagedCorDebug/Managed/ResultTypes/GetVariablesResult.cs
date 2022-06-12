using System;

namespace ManagedCorDebug
{
    public struct GetVariablesResult
    {
        public int PcVars { get; }

        public IntPtr PVars { get; }

        public GetVariablesResult(int pcVars, IntPtr pVars)
        {
            PcVars = pcVars;
            PVars = pVars;
        }
    }
}