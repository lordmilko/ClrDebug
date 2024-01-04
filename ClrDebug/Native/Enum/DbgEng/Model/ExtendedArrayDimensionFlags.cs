namespace ClrDebug.DbgEng
{
    public enum ExtendedArrayDimensionFlags : uint
    {
        ExtendedArrayLengthIsOffset32 = 0x00000001,
        ExtendedArrayLengthIsOffset64 = 0x00000002,
        ExtendedArrayLengthIsOffset = 0x00000003,
        ExtendedArrayLowerBoundIsOffset32 = 0x00000004,
        ExtendedArrayLowerBoundIsOffset64 = 0x00000008,
        ExtendedArrayLowerBoundIsOffset = 0x0000000C,
        ExtendedArrayStrideIsOffset32 = 0x00000010,
        ExtendedArrayStrideIsOffset64 = 0x00000020,
        ExtendedArrayStrideIsOffset = 0x00000030,
        ExtendedArrayStrideIsComputedByNextRank = 0x00000040,
        ExtendedArrayStrideIsComputedByPreviousRank = 0x00000080,
        ExtendedArrayStrideIsComputed = 0x000000C0
    }
}
