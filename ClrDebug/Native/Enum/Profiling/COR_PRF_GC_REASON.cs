using System;

namespace ClrDebug
{
    /// <summary>
    /// Indicates the reason that garbage collection is occurring.
    /// </summary>
    public enum COR_PRF_GC_REASON
    {
        /// <summary>
        /// The reason is unspecified.
        /// </summary>
        COR_PRF_GC_OTHER,

        /// <summary>
        /// The garbage collection was induced by a <see cref="GC.Collect()"/> method.
        /// </summary>
        COR_PRF_GC_INDUCED,
    }
}
