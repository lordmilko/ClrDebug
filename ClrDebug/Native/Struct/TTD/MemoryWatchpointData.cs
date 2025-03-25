namespace ClrDebug.TTD
{
    public struct MemoryWatchpointData
    {
        public GuestAddress address;
        public long size;
        public BP_FLAGS flags;

        //Based on how TtdTargetInfo::InsertCodeBreakpoint uses this, I think flags is 1 byte and there's just padding after it
    }
}