namespace ClrDebug.DbgEng
{
    public enum SvcSegmentFlags : uint
    {
        /// <summary>
        /// Indicates that the segment is a code segment.
        /// </summary>
        SvcSegmentCode = 0x00000001,

        /// <summary>
        /// Indicate the segment is readable.
        /// </summary>
        SvcSegmentRead = 0x00000002,

        /// <summary>
        /// Indicates the segment is writeable.
        /// </summary>
        SvcSegmentWrite = 0x00000004,

        /// <summary>
        /// Indicates the segment is executable.
        /// </summary>
        SvcSegmentExecute = 0x00000008,

        /// <summary>
        /// Indicate sthe segment is only "supervisor" accessible (e.g.: ring 0).
        /// </summary>
        SvcSegmentSupervisor = 0x00000010
    }
}
