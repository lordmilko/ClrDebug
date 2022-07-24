using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DBG_DUMP : uint
    {
        NO_INDENT              = 0x00000001, // Fields are not indented if this is set
        NO_OFFSET              = 0x00000002, // Offsets are not printed if this is set
        VERBOSE                = 0x00000004, // Verbose output
        CALL_FOR_EACH          = 0x00000008, // Callback is done for each of fields
        LIST                   = 0x00000020, // A list of type is dumped, listLink should have info about next element pointer
        NO_PRINT               = 0x00000040, // Nothing is printed if this is set (only callbacks and data copies done)
        GET_SIZE_ONLY          = 0x00000080, // Ioctl returns the size as usual, but will not do field prints/callbacks if this is set
        COMPACT_OUT            = 0x00002000, // No newlines are printed after each field
        ARRAY                  = 0x00008000, // An array of type is dumped, number of elements can be specified in listLink->size
        ADDRESS_OF_FIELD       = 0x00010000, // The specified addr value is actually the address of field listLink->fName
        ADDRESS_AT_END         = 0x00020000, // The specified addr value is actually the adress at the end of type
        COPY_TYPE_DATA         = 0x00040000, // This could be used to copy only the primitive types like ULONG, PVOID etc. - will not work with structures/unions
        READ_PHYSICAL          = 0x00080000, // Flag to allow read directly from physical memory
        FUNCTION_FORMAT        = 0x00100000, // This causes a function type to be dumped in format function(arg1, arg2, ...)
        BLOCK_RECURSE          = 0x00200000, // This recurses on a struct but doesn't expand pointers
        MATCH_SIZE             = 0x00400000, // Match the type size to resolve ambiguity in case multiple matches with same name are available
    }
}
