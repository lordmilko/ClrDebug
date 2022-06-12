namespace ManagedCorDebug
{
    public struct IsStartedResult
    {
        public int PbStarted { get; }

        public int PdwStartupFlags { get; }

        public IsStartedResult(int pbStarted, int pdwStartupFlags)
        {
            PbStarted = pbStarted;
            PdwStartupFlags = pdwStartupFlags;
        }
    }
}