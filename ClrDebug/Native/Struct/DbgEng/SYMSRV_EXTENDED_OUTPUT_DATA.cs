namespace ClrDebug.DbgEng
{
    public unsafe struct SYMSRV_EXTENDED_OUTPUT_DATA
    {
        public int sizeOfStruct;           // size of the structure
        public int version;                // version number (EXT_OUTPUT_VER)
        public fixed short filePtrMsg[261]; // File ptr message data buffer
    }
}
