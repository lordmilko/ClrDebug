namespace ClrDebug.DbgEng
{
    public struct DEBUG_LAST_EVENT_INFO_SERVICE_EXCEPTION
    {
        public int Kind;
        public int DataSize;
        public long Address;

        //
        // (Kind) Specific Data... (e.g.: an EXCEPTION_RECORD64 or another definition given by
        //                                a specific platform service)
        //
    }
}