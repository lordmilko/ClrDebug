namespace ClrDebug.TTD
{
    public unsafe struct ThreadTerminatedEvent
    {
        public Position position;
        public ThreadInfo* info;
    }
}