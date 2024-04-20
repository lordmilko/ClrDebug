using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("RangeStart = {RangeStart}, RangeLength = {RangeLength}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcAddressRange
    {
        public long RangeStart;
        public long RangeLength;
    }
}
