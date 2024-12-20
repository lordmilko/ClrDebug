namespace ClrDebug.DbgEng
{
    public enum ArrayDimensionFlags : uint
    {
        /// <summary>
        /// Indicates that the "Length" field of the array dimension is an offset from the base address of the array as to where to find a dynamic size.
        /// </summary>
        SvcArrayLengthIsOffset32 = 0x00000001,
        SvcArrayLengthIsOffset64 = 0x00000002,
        SvcArrayLengthIsOffset = 0x00000003,

        /// <summary>
        /// Indicates that the "LowerBound" field of the array dimension is an offset from the base address of the array as to where to find a dynamic bound.
        /// </summary>
        SvcArrayLowerBoundIsOffset32 = 0x00000004,
        SvcArrayLowerBoundIsOffset64 = 0x00000008,
        SvcArrayLowerBoundIsOffset = 0x0000000C,

        /// <summary>
        /// Indicates that the "Stride" field of the array dimension is an offset from the base address of the array as to where to find a dynamic stride.
        /// </summary>
        SvcArrayStrideIsOffset32 = 0x00000010,
        SvcArrayStrideIsOffset64 = 0x00000020,
        SvcArrayStrideIsOffset = 0x00000030,

        /// <summary>
        /// Indicates that the "Stride" field is computed from the element size and the computed sizes of each dimension as indicated by other fields.<para/>
        /// Next indicates that the stride of this dimension is based on the stride of the next (e.g.: dim[0] is the largest) Previous indicates that the stride of this dimension is based on the stride of the previous (e.g.: dim[0] is the smallest).
        /// </summary>
        SvcArrayStrideIsComputedByNextRank = 0x00000040,
        SvcArrayStrideIsComputedByPreviousRank = 0x00000080,
        SvcArrayStrideIsComputed = 0x000000C0
    }
}
