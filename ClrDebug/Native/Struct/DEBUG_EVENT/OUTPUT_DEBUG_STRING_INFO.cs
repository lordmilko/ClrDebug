using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct OUTPUT_DEBUG_STRING_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"lpDebugStringData = 0x{((ulong)(void*)lpDebugStringData):X}, fUnicode = {fUnicode}, nDebugStringLength = {nDebugStringLength}";

        public IntPtr lpDebugStringData;
        public short fUnicode;
        public short nDebugStringLength;
    }
}
