using System;

namespace ManagedCorDebug
{
    public struct GetVariablesResult
    {
        public uint PcVars { get; }

        public IntPtr PVars { get; }

        public GetVariablesResult(uint pcVars, IntPtr pVars)
        {
            PcVars = pcVars;
            PVars = pVars;
        }
    }
}