namespace ClrDebug.DbgEng
{
    public enum IoctlDumpError : uint
    {
        MEMORY_READ_ERROR = 0x01,
        SYMBOL_TYPE_INDEX_NOT_FOUND = 0x02,
        SYMBOL_TYPE_INFO_NOT_FOUND = 0x03,
        FIELDS_DID_NOT_MATCH = 0x04,
        NULL_SYM_DUMP_PARAM = 0x05,
        NULL_FIELD_NAME = 0x06,
        INCORRECT_VERSION_INFO = 0x07,
        EXIT_ON_CONTROLC = 0x08,
        CANNOT_ALLOCATE_MEMORY = 0x09,
        INSUFFICIENT_SPACE_TO_COPY = 0x0a,
        ADDRESS_TYPE_INDEX_NOT_FOUND = 0x0b,
        UNAVAILABLE_ERROR = 0x0c
    }
}
