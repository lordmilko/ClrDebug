using System;

namespace ClrDebug
{
    [Flags]
    public enum ThreadState : uint
    {
        /// <summary>
        /// Threads are initialized this way
        /// </summary>
        TS_Unknown = 0x00000000,

        /// <summary>
        /// Abort the thread
        /// </summary>
        TS_AbortRequested = 0x00000001,

        /// <summary>
        /// ThreadSuspend::SuspendRuntime watches this thread to leave coop mode.
        /// </summary>
        TS_GCSuspendPending = 0x00000002,

        /// <summary>
        /// ThreadSuspend::SuspendRuntime has redirected the thread to suspention routine.
        /// </summary>
        TS_GCSuspendRedirected = 0x00000004,

        /// <summary>
        /// Used to track suspension progress. Only SuspendRuntime writes/resets these.
        /// </summary>
        TS_GCSuspendFlags = TS_GCSuspendPending | TS_GCSuspendRedirected,

        /// <summary>
        /// Is the debugger suspending threads?
        /// </summary>
        TS_DebugSuspendPending = 0x00000008,

        /// <summary>
        /// Force a GC on stub transitions (GCStress only)
        /// </summary>
        TS_GCOnTransitions = 0x00000010,

        /// <summary>
        /// Is it now legal to attempt a Join()
        /// </summary>
        TS_LegalToJoin = 0x00000020,

        /// <summary>
        /// Runtime is executing on an alternate stack located anywhere in the memory
        /// </summary>
        TS_ExecutingOnAltStack = 0x00000040,

        /// <summary>
        /// Return address has been hijacked
        /// </summary>
        TS_Hijacked = 0x00000080,

        // unused                 = 0x00000100,

        /// <summary>
        /// Thread is a background thread
        /// </summary>
        TS_Background = 0x00000200,

        /// <summary>
        /// Thread has never been started
        /// </summary>
        TS_Unstarted = 0x00000400,

        /// <summary>
        /// Thread is dead
        /// </summary>
        TS_Dead = 0x00000800,

        /// <summary>
        /// Exposed object initiated this thread
        /// </summary>
        TS_WeOwn = 0x00001000,

        /// <summary>
        /// CoInitialize has been called for this thread
        /// </summary>
        TS_CoInitialized = 0x00002000,

        /// <summary>
        /// Thread hosts an STA
        /// </summary>
        TS_InSTA = 0x00004000,

        /// <summary>
        /// Thread is part of the MTA
        /// </summary>
        TS_InMTA = 0x00008000,

        // Some bits that only have meaning for reporting the state to clients.

        /// <summary>
        /// In WaitForOtherThreads()
        /// </summary>
        TS_ReportDead = 0x00010000,

        /// <summary>
        /// Thread is fully initialized and we are ready to broadcast its existence to external clients
        /// </summary>
        TS_FullyInitialized = 0x00020000,

        /// <summary>
        /// The task is reset
        /// </summary>
        TS_TaskReset = 0x00040000,

        /// <summary>
        /// Suspended via WaitSuspendEvent
        /// </summary>
        TS_SyncSuspended = 0x00080000,

        /// <summary>
        /// Debugger will wait for this thread to sync
        /// </summary>
        TS_DebugWillSync = 0x00100000,

        /// <summary>
        /// A stackcrawl is needed on this thread, such as for thread abort
        /// </summary>
        TS_StackCrawlNeeded = 0x00200000,

        // unused                 = 0x00400000,
        // unused                 = 0x00800000,

        /// <summary>
        /// Is this a threadpool worker thread?
        /// </summary>
        TS_TPWorkerThread = 0x01000000,

        /// <summary>
        /// Sitting in a Sleep(), Wait(), Join()
        /// </summary>
        TS_Interruptible = 0x02000000,

        /// <summary>
        /// Was awakened by an interrupt APC. !!! This can be moved to TSNC
        /// </summary>
        TS_Interrupted = 0x04000000,

        /// <summary>
        /// Completion port thread
        /// </summary>
        TS_CompletionPortThread = 0x08000000,

        /// <summary>
        /// Set when abort is begun
        /// </summary>
        TS_AbortInitiated = 0x10000000,

        /// <summary>
        /// The associated managed Thread object has been finalized. We can clean up the unmanaged part now.
        /// </summary>
        TS_Finalized = 0x20000000,

        /// <summary>
        /// The thread fails during startup.
        /// </summary>
        TS_FailStarted = 0x40000000,

        /// <summary>
        /// Thread was detached by DllMain
        /// </summary>
        TS_Detached = 0x80000000,

        /// <summary>
        /// We require (and assert) that the following bits are less than 0x100.
        /// </summary>
        TS_CatchAtSafePoint = (TS_AbortRequested | TS_GCSuspendPending |
                               TS_DebugSuspendPending | TS_GCOnTransitions),
    }
}
