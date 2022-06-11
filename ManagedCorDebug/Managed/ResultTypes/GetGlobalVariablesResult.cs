using System;

namespace ManagedCorDebug
{
    public struct GetGlobalVariablesResult
    {
        public uint PcVars { get; }

        public IntPtr PVars { get; }

        public GetGlobalVariablesResult(uint pcVars, IntPtr pVars)
        {
            PcVars = pcVars;
            PVars = pVars;
        }
    }
}