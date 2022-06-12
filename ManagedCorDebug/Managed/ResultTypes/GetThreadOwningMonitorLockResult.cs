namespace ManagedCorDebug
{
    public struct GetThreadOwningMonitorLockResult
    {
        public CorDebugThread PpThread { get; }

        public int PAcquisitionCount { get; }

        public GetThreadOwningMonitorLockResult(CorDebugThread ppThread, int pAcquisitionCount)
        {
            PpThread = ppThread;
            PAcquisitionCount = pAcquisitionCount;
        }
    }
}