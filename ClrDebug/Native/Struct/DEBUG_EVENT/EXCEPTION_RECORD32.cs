namespace ClrDebug
{
    public unsafe struct EXCEPTION_RECORD32
    {
        public NTSTATUS ExceptionCode;
        public ExceptionFlags ExceptionFlags;
        public int ExceptionRecord;
        public int ExceptionAddress;
        public int NumberParameters;
        public fixed int ExceptionInformation[15];
    }
}