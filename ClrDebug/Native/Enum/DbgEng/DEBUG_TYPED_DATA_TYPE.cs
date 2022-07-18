namespace ClrDebug.DbgEng
{
    public enum DEBUG_TYPED_DATA_TYPE : uint
    {
        IS_IN_MEMORY = 0x01,
        PHYSICAL_DEFAULT = 0x02,
        PHYSICAL_CACHED = 0x04,
        PHYSICAL_UNCACHED = 0x06,
        PHYSICAL_WRITE_COMBINED = 0x08,
    }
}