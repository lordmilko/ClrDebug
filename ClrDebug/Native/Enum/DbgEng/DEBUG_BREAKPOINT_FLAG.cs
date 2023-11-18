using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_BREAKPOINT_FLAG : uint
    {
        /// <summary>
        /// Go-only breakpoints are only active when the engine is in unrestricted execution mode.
        /// They do not fire when the engine is stepping.
        /// </summary>
        GO_ONLY = 1,

        /// <summary>
        /// A breakpoint is flagged as deferred as long as its offset expression cannot be evaluated.
        /// A deferred breakpoint is not active.
        /// </summary>
        DEFERRED = 2,

        ENABLED = 4,

        /// <summary>
        /// The adder-only flag does not affect breakpoint operation. It is just a marker to restrict
        /// output and notifications for the breakpoint to the client that added the breakpoint.
        /// Breakpoint callbacks for adder-only breaks will only be delivered to the adding client.
        /// The breakpoint can not be enumerated and accessed by other clients.
        /// </summary>
        ADDER_ONLY = 8,

        /// <summary>
        /// One-shot breakpoints automatically clear themselves the first time they are hit.
        /// </summary>
        ONE_SHOT = 0x10,
    }
}
