namespace ClrDebug.DbgEng
{
    /// <summary>
    /// SessionStatus flags.
    /// </summary>
    public enum DEBUG_SESSION : uint
    {
        /// <summary>
        /// A debuggee has been discovered for the session.
        /// </summary>
        ACTIVE = 0,

        //The session has been ended by EndSession.

        END_SESSION_ACTIVE_TERMINATE = 1,
        END_SESSION_ACTIVE_DETACH = 2,
        END_SESSION_PASSIVE = 3,

        /// <summary>
        /// The debuggee has run to completion. User-mode only.
        /// </summary>
        END = 4,

        /// <summary>
        /// The target machine has rebooted. Kernel-mode only.
        /// </summary>
        REBOOT = 5,

        /// <summary>
        /// The target machine has hibernated. Kernel-mode only.
        /// </summary>
        HIBERNATE = 6,

        /// <summary>
        /// The engine was unable to continue the session.
        /// </summary>
        FAILURE = 7,
    }
}
