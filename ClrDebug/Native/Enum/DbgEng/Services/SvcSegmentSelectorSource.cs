namespace ClrDebug.DbgEng
{
    public enum SvcSegmentSelectorSource : uint
    {
        SegmentSelectorUnknown,
        SegmentSelectorCode,
        SegmentSelectorData,
        SegmentSelectorStack,
        SegmentSelectorExtra1,
        SegmentSelectorExtra2,
        SegmentSelectorExtra3
    }
}
