using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a contiguous range of addresses in an address space.
    /// </summary>
    [DebuggerDisplay("RangeStart = {RangeStart}, RangeLength = {RangeLength}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcAddressRange
    {
        public long RangeStart;
        public long RangeLength;
    }
}
