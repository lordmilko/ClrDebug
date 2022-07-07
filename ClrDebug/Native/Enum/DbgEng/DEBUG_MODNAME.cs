namespace ClrDebug.DbgEng
{
    public enum DEBUG_MODNAME : uint
    {
        IMAGE = 0x00000000, //the full path to the file
        MODULE = 0x00000001, //name without path or extension
        LOADED_IMAGE = 0x00000002, //nothing?
        SYMBOL_FILE = 0x00000003, //same as image? strange :S
        MAPPED_IMAGE = 0x00000004, //nothing?
    }
}