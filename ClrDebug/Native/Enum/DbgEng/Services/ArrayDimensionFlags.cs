namespace ClrDebug.DbgEng
{
    public enum ArrayDimensionFlags : uint
    {
        SvcArrayLengthIsOffset32 = 0x00000001,
        SvcArrayLengthIsOffset64 = 0x00000002,
        SvcArrayLengthIsOffset = 0x00000003,
        SvcArrayLowerBoundIsOffset32 = 0x00000004,
        SvcArrayLowerBoundIsOffset64 = 0x00000008,
        SvcArrayLowerBoundIsOffset = 0x0000000C,
        SvcArrayStrideIsOffset32 = 0x00000010,
        SvcArrayStrideIsOffset64 = 0x00000020,
        SvcArrayStrideIsOffset = 0x00000030,
        SvcArrayStrideIsComputedByNextRank = 0x00000040,
        SvcArrayStrideIsComputedByPreviousRank = 0x00000080,
        SvcArrayStrideIsComputed = 0x000000C0
    }
}
