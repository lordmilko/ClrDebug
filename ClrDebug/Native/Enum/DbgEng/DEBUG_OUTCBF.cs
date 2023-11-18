using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Flags for various Output2 callbacks.
    /// </summary>
    [Flags]
    public enum DEBUG_OUTCBF : uint
    {
        /// <summary>
        /// The content string was followed by an explicit flush.
        /// This flag will be used instead of a separate DEBUG_OUTCB_EXPLICIT_FLUSH
        /// callback when a flush has text to flush, thus avoiding two callbacks.
        /// </summary>
        COMBINED_EXPLICIT_FLUSH = 1,

        /// <summary>
        /// The markup content string has embedded tags.
        /// </summary>
        DML_HAS_TAGS = 2,

        /// <summary>
        /// The markup content has encoded special characters like ", &amp;, &lt; and &gt;.
        /// </summary>
        DML_HAS_SPECIAL_CHARACTERS = 4,
    }
}
