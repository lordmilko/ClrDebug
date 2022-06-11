namespace ManagedCorDebug
{
    public struct GetThreadOwningMonitorLockResult
    {
        public CorDebugThread PpThread { get; }

        public uint PAcquisitionCount { get; }

        public GetThreadOwningMonitorLockResult(CorDebugThread ppThread, uint pAcquisitionCount)
        {
            PpThread = ppThread;
            PAcquisitionCount = pAcquisitionCount;
        }
    }
}