using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolArrayDimension
    {
        public long DimensionFlags;
        public long LowerBound;
        public long Length;
        public long Stride;
    }
}
