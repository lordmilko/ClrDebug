using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_ATTACH : uint
    {
        KERNEL_CONNECTION = 0,

        /// <summary>
        /// Attach to the local machine. If this flag is not set a connection is made to a separate
        /// target machine using the given connection options.
        /// </summary>
        LOCAL_KERNEL = 1,

        /// <summary>
        /// Attach to an eXDI driver.
        /// </summary>
        EXDI_DRIVER = 2,

        /// <summary>
        /// Just install client-side transpotr drivers
        /// </summary>
        INSTALL_DRIVER = 4,

        /// <summary>
        /// Call DebugActiveProcess when attaching.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// When attaching to a process just examine the process state and suspend the threads.
        /// DebugActiveProcess is not called so the process is not actually being debugged.
        /// This is useful for debugging processes holding locks which interfere with the operation
        /// of DebugActiveProcess or in situations where it is not desirable to actually set up as a
        /// debugger.
        /// </summary>
        NONINVASIVE = 1,

        /// <summary>
        /// Attempt to attach to a process that was abandoned when being debugged. This is only supported
        /// in some system versions. This flag also allows multiple debuggers to attach to the same
        /// process, which can result in numerous problems unless very carefully managed.
        /// </summary>
        EXISTING = 2,

        /// <summary>
        /// When attaching non-invasively, do not suspend threads. It is the callers responsibility to
        /// either suspend the threads itself or be aware that the attach state may not reflect the
        /// current state of the process if threads are still running.
        /// </summary>
        NONINVASIVE_NO_SUSPEND = 4,

        /// <summary>
        /// When doing an invasive attach do not inject a break-in thread to generate the initial
        /// break-in event. This can be useful to save resources when an initial break is not
        /// necessary or when injecting a thread might affect the debuggee's state. This option is
        /// only supported on Windows XP and above.
        /// </summary>
        INVASIVE_NO_INITIAL_BREAK = 8,

        /// <summary>
        /// When doing an invasive attach resume all threads at the time of attach. This makes it
        /// possible to attach to a process created suspended and cause it to start running.
        /// </summary>
        INVASIVE_RESUME_PROCESS = 0x10,

        /// <summary>
        /// When doing a non-invasive attach the engine must recover information for all debuggee
        /// elements. The engine may not have permissions for all elements, for example it may not
        /// be able to open all threads, and that would ordinarily block the attach. This flag allows
        /// unusable elements to be ignored.
        /// </summary>
        NONINVASIVE_ALLOW_PARTIAL = 0x20,
    }
}
