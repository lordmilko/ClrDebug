using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CREATE_THREAD_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"hThread = {hThread}, lpThreadLocalBase = 0x{((ulong)(void*)lpThreadLocalBase):X}, lpStartAddress = 0x{((ulong)(void*)lpStartAddress):X}";

        public IntPtr hThread;
        public IntPtr lpThreadLocalBase;
        public IntPtr lpStartAddress;
    }
}
