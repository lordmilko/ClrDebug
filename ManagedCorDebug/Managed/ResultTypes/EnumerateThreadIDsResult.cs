namespace ManagedCorDebug
{
    public struct EnumerateThreadIDsResult
    {
        public uint PcThreadIds { get; }

        public uint[] PThreadIds { get; }

        public EnumerateThreadIDsResult(uint pcThreadIds, uint[] pThreadIds)
        {
            PcThreadIds = pcThreadIds;
            PThreadIds = pThreadIds;
        }
    }
}