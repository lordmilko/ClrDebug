using System;

namespace ManagedCorDebug
{
    public struct GetLocalsResult
    {
        public uint PcLocals { get; }

        public IntPtr Locals { get; }

        public GetLocalsResult(uint pcLocals, IntPtr locals)
        {
            PcLocals = pcLocals;
            Locals = locals;
        }
    }
}