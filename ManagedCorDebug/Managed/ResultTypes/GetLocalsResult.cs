using System;

namespace ManagedCorDebug
{
    public struct GetLocalsResult
    {
        public int PcLocals { get; }

        public IntPtr Locals { get; }

        public GetLocalsResult(int pcLocals, IntPtr locals)
        {
            PcLocals = pcLocals;
            Locals = locals;
        }
    }
}