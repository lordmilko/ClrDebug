using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetRunningProcessDescription flags.
    /// </summary>
    [Flags]
    public enum DEBUG_PROC_DESC : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// Return only filenames, not full paths.
        /// </summary>
        NO_PATHS = 1,

        /// <summary>
        /// Dont look up service names.
        /// </summary>
        NO_SERVICES = 2,

        /// <summary>
        /// Dont look up MTS package names.
        /// </summary>
        NO_MTS_PACKAGES = 4,

        /// <summary>
        /// Dont retrieve the command line.
        /// </summary>
        NO_COMMAND_LINE = 8,

        /// <summary>
        /// Dont retrieve the session ID.
        /// </summary>
        NO_SESSION_ID = 0x10,

        /// <summary>
        /// Dont retrieve the process's user name.
        /// </summary>
        NO_USER_NAME = 0x20,

        /// <summary>
        /// Retrieve the process's package family name.
        /// </summary>
        WITH_PACKAGEFAMILY = 0x40,

        /// <summary>
        /// Retrieve the process's architecture.
        /// </summary>
        WITH_ARCHITECTURE = 0x80
    }
}
