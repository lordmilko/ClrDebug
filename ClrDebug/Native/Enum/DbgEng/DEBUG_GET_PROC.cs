using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetRunningProcessSystemIdByExecutableName flags.
    /// </summary>
    [Flags]
    public enum DEBUG_GET_PROC : uint
    {
        /// <summary>
        /// By default the match allows a tail match on just the filename. The match returns the
        /// first hit even if multiple matches exist.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// The name must match fully.
        /// </summary>
        FULL_MATCH = 1,

        /// <summary>
        /// The match must be the only match.
        /// </summary>
        ONLY_MATCH = 2,

        /// <summary>
        /// The name is a service name instead of an executable name.
        /// </summary>
        SERVICE_NAME = 4,
    }
}
