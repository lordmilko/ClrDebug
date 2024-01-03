using System;

namespace ClrDebug
{
    /// <summary>
    /// Indicates the types of code that can be intercepted (that is, stepped into).
    /// </summary>
    /// <remarks>
    /// Use the <see cref="ICorDebugStepper.SetInterceptMask"/> method to establish the types of code that can be intercepted.
    /// </remarks>
    [Flags]
    public enum CorDebugIntercept
    {
        /// <summary>
        /// No code can be intercepted.
        /// </summary>
        INTERCEPT_NONE = 0,

        /// <summary>
        /// A constructor can be intercepted.
        /// </summary>
        INTERCEPT_CLASS_INIT = 1,

        /// <summary>
        /// An exception filter can be intercepted.
        /// </summary>
        INTERCEPT_EXCEPTION_FILTER = 2,

        /// <summary>
        /// Code that enforces security can be intercepted.
        /// </summary>
        INTERCEPT_SECURITY = 4,

        /// <summary>
        /// A context policy can be intercepted.
        /// </summary>
        INTERCEPT_CONTEXT_POLICY = 8,

        /// <summary>
        /// Not used.
        /// </summary>
        INTERCEPT_INTERCEPTION = 16, // 0x00000010

        /// <summary>
        /// All code can be intercepted.
        /// </summary>
        INTERCEPT_ALL = 65535 // 0x0000FFFF
    }
}