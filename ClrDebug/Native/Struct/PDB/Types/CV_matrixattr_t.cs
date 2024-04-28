using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// matrix flags
    /// </summary>
    [DebuggerDisplay("row_major = {row_major}, unused = {unused}, data = {data}")]
    public struct CV_matrixattr_t
    {
        /// <summary>
        /// true if matrix has row-major layout (column-major is default)
        /// </summary>
        public bool row_major
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// unused
        /// </summary>
        public byte unused
        {
            get => GetBits(data, 2, 7);
            set => SetBits(ref data, 2, 7, value);
        }

        public byte data;
    }
}
