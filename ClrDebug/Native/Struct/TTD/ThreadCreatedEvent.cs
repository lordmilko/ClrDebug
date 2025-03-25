namespace ClrDebug.TTD
{
    public unsafe struct ThreadCreatedEvent
    {
        public Position position;
        public ThreadInfo* info;
    }
}