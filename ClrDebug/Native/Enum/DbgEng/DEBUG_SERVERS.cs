namespace ClrDebug.DbgEng
{
    /// <summary>
    /// OutputServers flags.
    /// </summary>
    public enum DEBUG_SERVERS : uint
    {
        /// <summary>
        /// Debugger servers from StartSever.
        /// </summary>
        DEBUGGER = 1,

        /// <summary>
        /// Process servers from StartProcessServer.
        /// </summary>
        PROCESS = 2,

        ALL = 3,
    }
}
