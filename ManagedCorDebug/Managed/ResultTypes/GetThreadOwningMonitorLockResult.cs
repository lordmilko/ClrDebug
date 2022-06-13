using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugHeapValue.ThreadOwningMonitorLock"/> property.
    /// </summary>
    [DebuggerDisplay("ppThread = {ppThread}, pAcquisitionCount = {pAcquisitionCount}")]
    public struct GetThreadOwningMonitorLockResult
    {
        /// <summary>
        /// The managed thread that owns the monitor lock on this object.
        /// </summary>
        public CorDebugThread ppThread { get; }

        /// <summary>
        /// The number of times this thread would have to release the lock before it returns to being unowned.
        /// </summary>
        public int pAcquisitionCount { get; }

        public GetThreadOwningMonitorLockResult(CorDebugThread ppThread, int pAcquisitionCount)
        {
            this.ppThread = ppThread;
            this.pAcquisitionCount = pAcquisitionCount;
        }
    }
}