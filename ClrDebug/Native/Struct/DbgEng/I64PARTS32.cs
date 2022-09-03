using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("LowPart = {LowPart}, HighPart = {HighPart}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct I64PARTS32
    {
        [FieldOffset(0)]
        public int LowPart;
        [FieldOffset(4)]
        public int HighPart;
    }
}
