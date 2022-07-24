using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DBG_DUMP_FIELD
    {
        CALL_BEFORE_PRINT = 0x00000001,
        NO_CALLBACK_REQ = 0x00000002,
        RECUR_ON_THIS = 0x00000004,
        FULL_NAME = 0x00000008,
        ARRAY = 0x00000010,
        COPY_FIELD_DATA = 0x00000020,
        RETURN_ADDRESS = 0x00001000,
        SIZE_IN_BITS = 0x00002000,
        NO_PRINT = 0x00004000,
        DEFAULT_STRING = 0x00010000,
        WCHAR_STRING = 0x00020000,
        MULTI_STRING = 0x00040000,
        GUID_STRING = 0x00080000
    }
}
