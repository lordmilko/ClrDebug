using System.Threading;

namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the reasons why a thread may become blocked on a given object.
    /// </summary>
    /// <remarks>
    /// When the BLOCKING_MONITOR_CRITICAL_SECTION or BLOCKING_MONITOR_EVENT member is used in a <see cref="CorDebugBlockingObject"/>
    /// structure, the pBlockingObject member of the structure points to an <see cref="ICorDebugValue"/> interface that represents
    /// the object that is being entered. It is also guaranteed to implement the <see cref="ICorDebugHeapValue3"/> interface.
    /// </remarks>
    public enum CorDebugBlockingReason
    {
        /// <summary>
        /// Internal use only.
        /// </summary>
        BLOCKING_NONE,

        /// <summary>
        /// A thread is trying to acquire the critical section that is associated with the monitor lock on an object. Typically, this occurs when you call one of the <see cref="Monitor.Enter(object)"/> or <see cref="Monitor.TryEnter(object)"/> methods.
        /// </summary>
        BLOCKING_MONITOR_CRITICAL_SECTION,

        /// <summary>
        /// A thread is waiting on the event that is associated with a monitor lock for an object. Typically, this occurs when you call one of the <see cref="Monitor.Wait(object)"/> methods.
        /// </summary>
        BLOCKING_MONITOR_EVENT
    }
}