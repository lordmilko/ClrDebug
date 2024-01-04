using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcAddressRange
    {
        public long RangeStart;
        public long RangeLength;
    }
}
