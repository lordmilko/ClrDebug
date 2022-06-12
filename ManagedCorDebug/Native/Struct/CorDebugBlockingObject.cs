using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Defines an object that is blocking a thread and the specific reason that the thread is blocked.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CorDebugBlockingObject
    {
        /// <summary>
        /// The object on which the thread is blocking. This object is valid only for the duration of the current synchronized state.<para/>
        /// If two threads are blocking on the same object within the same synchronized state, you may expect the <see cref="ICorDebugValue.GetAddress"/> method to return the same value.<para/>
        /// However, the interfaces may or may not be pointer equivalent.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugValue pBlockingObject;

        /// <summary>
        /// The number of milliseconds before the blocking operation will time out, or the value INFINITE, which indicates that it will not time out.<para/>
        /// The time-out value specifies the total length of time for the blocking operation, not the time that is still remaining.
        /// </summary>
        public int dwTimeout;

        /// <summary>
        /// The reason that the thread is blocked on this object.
        /// </summary>
        public CorDebugBlockingReason blockingReason;
    }
}