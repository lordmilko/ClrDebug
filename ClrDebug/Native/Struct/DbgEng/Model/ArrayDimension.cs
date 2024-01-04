using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the memory layout of one dimension of an array.
    /// </summary>
    /// <remarks>
    /// For C-style arrays, a single array dimension is returned here with values which are always:LowerBound = 0 Length
    /// = ARRAYSIZE(array) Stride = sizeof(elementType)
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct ArrayDimension
    {
        /// <summary>
        /// The lower bounds of the array. For C style zero based arrays, this will always be zero. There is no uniform restriction that all arrays represented by these interfaces are zero based.
        /// </summary>
        public long LowerBound;

        /// <summary>
        /// Defines the length of the dimension. The dimension is considered to be of the form [LowerBound, LowerBound + Length)
        /// </summary>
        public long Length;

        /// <summary>
        /// Defines how many bytes to move forward in memory to walk from index N of the dimension to index N + 1
        /// </summary>
        public long Stride;
    }
}
