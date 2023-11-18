namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Different kinds of output callback notifications that can be sent to Output2.
    /// </summary>
    public enum DEBUG_OUTCB : uint
    {
        /// <summary>
        /// Plain text content, flags are below, argument is mask.
        /// </summary>
        TEXT = 0,

        /// <summary>
        /// Debugger markup content, flags are below, argument is mask.
        /// </summary>
        DML = 1,

        /// <summary>
        /// Notification of an explicit output flush, flags and argument are zero.
        /// </summary>
        EXPLICIT_FLUSH = 2,
    }
}
