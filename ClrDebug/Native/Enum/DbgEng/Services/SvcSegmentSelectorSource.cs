namespace ClrDebug.DbgEng
{
    public enum SvcSegmentSelectorSource : uint
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        SegmentSelectorUnknown,

        /// <summary>
        /// X86/AMD64 (cs).
        /// </summary>
        SegmentSelectorCode,

        /// <summary>
        /// X86/AMD64 (ds).
        /// </summary>
        SegmentSelectorData,

        /// <summary>
        /// X86/AMD64 (ss).
        /// </summary>
        SegmentSelectorStack,

        /// <summary>
        /// X86/AMD64 (es).
        /// </summary>
        SegmentSelectorExtra1,

        /// <summary>
        /// X86/AMD64 (fs).
        /// </summary>
        SegmentSelectorExtra2,

        /// <summary>
        /// X86/AMD64 (gs).
        /// </summary>
        SegmentSelectorExtra3
    }
}
