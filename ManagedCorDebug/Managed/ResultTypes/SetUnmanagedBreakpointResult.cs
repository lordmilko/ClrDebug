using System;

namespace ManagedCorDebug
{
    public struct SetUnmanagedBreakpointResult
    {
        public byte[] Buffer { get; }

        public uint BufLen { get; }

        public SetUnmanagedBreakpointResult(byte[] buffer, uint bufLen)
        {
            Buffer = buffer;
            BufLen = bufLen;
        }
    }
}