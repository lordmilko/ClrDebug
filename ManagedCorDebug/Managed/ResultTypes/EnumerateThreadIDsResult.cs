namespace ManagedCorDebug
{
    public struct EnumerateThreadIDsResult
    {
        public int PcThreadIds { get; }

        public int[] PThreadIds { get; }

        public EnumerateThreadIDsResult(int pcThreadIds, int[] pThreadIds)
        {
            PcThreadIds = pcThreadIds;
            PThreadIds = pThreadIds;
        }
    }
}