namespace ClrDebug.DbgEng
{
    public struct PROCESS_NAME_ENTRY
    {
        public int ProcessId;
        public int NameOffset;  // offset for the process name string.
        public int NameSize;    // ProcessName will always be NULL terminated, NameSize is for struct align and safeguard.
        public int NextEntry;   // offset for next entry, 0 if the last.
    }
}