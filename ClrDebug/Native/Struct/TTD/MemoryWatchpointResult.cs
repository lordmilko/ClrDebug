namespace ClrDebug.TTD
{
    public struct MemoryWatchpointResult
    {
        public GuestAddress address;
        public long size;
        public BP_FLAGS flags;
    }
}