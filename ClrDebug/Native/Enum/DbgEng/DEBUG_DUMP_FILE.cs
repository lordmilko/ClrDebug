namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Dump information file types.
    /// </summary>
    public enum DEBUG_DUMP_FILE : uint
    {
        /// <summary>
        /// Base dump file, returned when querying for dump files.
        /// </summary>
        BASE = 0xffffffff,

        /// <summary>
        /// Single file containing packed page file information.
        /// </summary>
        PAGE_FILE_DUMP = 0,
    }
}
