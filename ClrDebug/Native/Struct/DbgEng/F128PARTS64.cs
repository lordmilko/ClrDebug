using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Explicit)]
    public struct F128PARTS64
    {
        [FieldOffset(0)]
        public long LowPart;
        [FieldOffset(8)]
        public long HighPart;
    }
}