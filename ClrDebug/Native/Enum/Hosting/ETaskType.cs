using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that indicate the type of task that is represented by either an <see cref="ICLRTask"/> or an <see cref="IHostTask"/> interface.
    /// </summary>
    [Flags]
    public enum ETaskType : uint
    {
        /// <summary>
        /// The interface represents a debugger helper task.
        /// </summary>
        TT_DEBUGGERHELPER = 0x1,

        /// <summary>
        /// The interface represents a garbage collection task.
        /// </summary>
        TT_GC = 0x2,

        /// <summary>
        /// The interface represents a finalizer task.
        /// </summary>
        TT_FINALIZER = 0x4,

        /// <summary>
        /// The interface represents a timer thread task.
        /// </summary>
        TT_THREADPOOL_TIMER = 0x8,

        /// <summary>
        /// The interface represents a gate thread task.
        /// </summary>
        TT_THREADPOOL_GATE = 0x10,

        /// <summary>
        /// The interface represents a worker thread task.
        /// </summary>
        TT_THREADPOOL_WORKER = 0x20,

        /// <summary>
        /// The interface represents an I/O thread task or a completion port thread task.
        /// </summary>
        TT_THREADPOOL_IOCOMPLETION = 0x40,

        /// <summary>
        /// The interface represents an application domain unloading task.
        /// </summary>
        TT_ADUNLOAD = 0x80,

        /// <summary>
        /// The interface represents a user task.
        /// </summary>
        TT_USER = 0x100,

        /// <summary>
        /// The interface represents a wait thread task.
        /// </summary>
        TT_THREADPOOL_WAIT = 0x200,

        /// <summary>
        /// The task is unknown.
        /// </summary>
        TT_UNKNOWN = 0x80000000
    }
}