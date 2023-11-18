namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetSystemObjectInformation requests.
    /// </summary>
    public enum DEBUG_SYSOBJINFO : uint
    {
        /// <summary>
        /// Arg64 - Unused.
        /// Arg32 - Debugger thread ID.
        /// Buffer - DEBUG_THREAD_BASIC_INFORMATION.
        /// </summary>
        THREAD_BASIC_INFORMATION = 0,

        /// <summary>
        /// Arg64 - Unused.
        /// Arg32 - Debugger thread ID.
        /// Buffer - Unicode name string.
        /// </summary>
        THREAD_NAME_WIDE = 1,

        /// <summary>
        /// Arg64 - Unused.
        /// Arg32 - Unused.
        /// Buffer - ULONG cookie value.
        /// </summary>
        CURRENT_PROCESS_COOKIE = 2,
    }
}
