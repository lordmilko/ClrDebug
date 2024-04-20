using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("DimensionFlags = {DimensionFlags}, LowerBound = {LowerBound}, Length = {Length}, Stride = {Stride}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct ExtendedArrayDimension
    {
        public long DimensionFlags;
        public long LowerBound;
        public long Length;
        public long Stride;
    }
}
