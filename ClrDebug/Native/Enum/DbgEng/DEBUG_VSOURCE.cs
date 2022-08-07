namespace ClrDebug.DbgEng
{
    //Read from IDebugDataSpaces4::GetOffsetInformation when DEBUG_OFFSINFO.VIRTUAL_SOURCE is used
    public enum DEBUG_VSOURCE : uint
    {
        INVALID = 0,
        DEBUGGEE = 1,
        MAPPED_IMAGE = 2,
        DUMP_WITHOUT_MEMINFO = 3,
    }
}
