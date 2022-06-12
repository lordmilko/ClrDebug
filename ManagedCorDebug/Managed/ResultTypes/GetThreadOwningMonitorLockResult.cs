namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugHeapValue.ThreadOwningMonitorLock"/> property.
    /// </summary>
    public struct GetThreadOwningMonitorLockResult
    {
        /// <summary>
        /// [out] The managed thread that owns the monitor lock on this object.
        /// </summary>
        public CorDebugThread ppThread { get; }

        /// <summary>
        /// [out] The number of times this thread would have to release the lock before it returns to being unowned.
        /// </summary>
        public int pAcquisitionCount { get; }

        public GetThreadOwningMonitorLockResult(CorDebugThread ppThread, int pAcquisitionCount)
        {
            this.ppThread = ppThread;
            this.pAcquisitionCount = pAcquisitionCount;
        }
    }
}