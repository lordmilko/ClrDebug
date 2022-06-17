using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains per-thread statistics pertaining to garbage collection.
    /// </summary>
    /// <remarks>
    /// <see cref="ICLRTask.GetMemStats"/> takes an output parameter of type <see cref="COR_GC_THREAD_STATS"/>.
    /// </remarks>
    [DebuggerDisplay("PerThreadAllocation = {PerThreadAllocation}, Flags = {Flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_GC_THREAD_STATS
    {
        /// <summary>
        /// The number of bytes of memory allocated on the thread that is associated with the current <see cref="COR_GC_THREAD_STATS"/> instance.<para/>
        /// This number is cleared to zero each time a generation-zero garbage collection occurs.
        /// </summary>
        public long PerThreadAllocation;

        /// <summary>
        /// The number of bytes promoted to a higher generation at the most recent garbage collection.
        /// </summary>
        public long Flags;
    }
}
