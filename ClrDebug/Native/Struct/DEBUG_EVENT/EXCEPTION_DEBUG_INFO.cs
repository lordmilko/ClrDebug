using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct EXCEPTION_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"{ExceptionRecord.ExceptionCode} ({(dwFirstChance ? "First Chance" : "SECOND CHANCE")})";

        public EXCEPTION_RECORD ExceptionRecord;
        public bool dwFirstChance;
    }
}
