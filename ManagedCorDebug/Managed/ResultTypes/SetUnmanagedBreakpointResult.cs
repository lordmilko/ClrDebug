using System;

namespace ManagedCorDebug
{
    public struct SetUnmanagedBreakpointResult
    {
        public byte[] Buffer { get; }

        public int BufLen { get; }

        public SetUnmanagedBreakpointResult(byte[] buffer, int bufLen)
        {
            Buffer = buffer;
            BufLen = bufLen;
        }
    }
}