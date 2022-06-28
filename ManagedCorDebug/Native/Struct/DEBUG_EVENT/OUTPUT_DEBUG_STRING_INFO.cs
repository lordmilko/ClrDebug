using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct OUTPUT_DEBUG_STRING_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"lpDebugStringData = {lpDebugStringData}, fUnicode = {fUnicode}, nDebugStringLength = {nDebugStringLength}";

        public IntPtr lpDebugStringData;
        public short fUnicode;
        public short nDebugStringLength;
    }
}
