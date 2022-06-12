using System;

namespace ManagedCorDebug
{
    public struct GetGlobalVariablesResult
    {
        public int PcVars { get; }

        public IntPtr PVars { get; }

        public GetGlobalVariablesResult(int pcVars, IntPtr pVars)
        {
            PcVars = pcVars;
            PVars = pVars;
        }
    }
}