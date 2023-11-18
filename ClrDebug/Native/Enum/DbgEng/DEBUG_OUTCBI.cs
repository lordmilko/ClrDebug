using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// IDebugOutputCallbacks2 interest mask flags.
    /// </summary>
    [Flags]
    public enum DEBUG_OUTCBI : uint
    {
        /// <summary>
        /// Indicates that the callback wants notifications of all explicit flushes.
        /// </summary>
        EXPLICIT_FLUSH = 1,

        /// <summary>
        /// Indicates that the callback wants content in text form.
        /// </summary>
        TEXT = 2,

        /// <summary>
        /// Indicates that the callback wants content in markup form.
        /// </summary>
        DML = 4,

        ANY_FORMAT = 6,
    }
}
