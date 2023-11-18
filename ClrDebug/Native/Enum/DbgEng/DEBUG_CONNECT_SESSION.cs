using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ConnectSession flags.
    /// </summary>
    [Flags]
    public enum DEBUG_CONNECT_SESSION : uint
    {
        /// <summary>
        /// Default connect.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// Do not output the debugger version.
        /// </summary>
        NO_VERSION = 1,

        /// <summary>
        /// Do not announce the connection.
        /// </summary>
        NO_ANNOUNCE = 2,
    }
}
