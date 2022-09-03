using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("LowPart = {LowPart}, HighPart = {HighPart}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct F128PARTS64
    {
        [FieldOffset(0)]
        public long LowPart;
        [FieldOffset(8)]
        public long HighPart;
    }
}
