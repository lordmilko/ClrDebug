namespace ClrDebug.DbgEng
{
    public enum SvcSegmentFlags : uint
    {
        SvcSegmentCode = 0x00000001,
        SvcSegmentRead = 0x00000002,
        SvcSegmentWrite = 0x00000004,
        SvcSegmentExecute = 0x00000008,
        SvcSegmentSupervisor = 0x00000010
    }
}
