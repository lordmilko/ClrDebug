namespace ManagedCorDebug
{
    public struct IsStartedResult
    {
        public int PbStarted { get; }

        public uint PdwStartupFlags { get; }

        public IsStartedResult(int pbStarted, uint pdwStartupFlags)
        {
            PbStarted = pbStarted;
            PdwStartupFlags = pdwStartupFlags;
        }
    }
}