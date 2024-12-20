using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a dimension of an array.
    /// </summary>
    [DebuggerDisplay("DimensionFlags = {DimensionFlags}, LowerBound = {LowerBound}, Length = {Length}, Stride = {Stride}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolArrayDimension
    {
        /// <summary>
        /// Information about how to interpret the remainder of the information in the array dimension Presently, these are reserved and should always be set to zero.
        /// </summary>
        public long DimensionFlags;

        /// <summary>
        /// The lower bounds of the array. For C style zero based arrays, this will always be zero. There is no uniform restriction that all arrays represented by these interfaces are zero based.
        /// </summary>
        public long LowerBound;

        /// <summary>
        /// Defines the length of the dimension. The dimension is considered to be of the form i [LowerBound, LowerBound + Length).
        /// </summary>
        public long Length;

        /// <summary>
        /// Defines how many bytes to move forward in memory to walk from index N of the dimension to index N + 1.
        /// </summary>
        public long Stride;
    }
}
