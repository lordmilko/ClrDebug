namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Event filter execution options.
    /// </summary>
    public enum DEBUG_FILTER_EXEC_OPTION : uint
    {
        /// <summary>
        /// Break in always.
        /// </summary>
        BREAK = 0x00000000,

        /// <summary>
        /// Break in on second-chance exceptions.
        /// For events that are not exceptions this is the same as BREAK.
        /// </summary>
        SECOND_CHANCE_BREAK = 0x00000001,

        /// <summary>
        /// Output a message about the event but continue.
        /// </summary>
        OUTPUT = 0x00000002,

        /// <summary>
        /// Continue the event.
        /// </summary>
        IGNORE = 0x00000003,

        /// <summary>
        /// Used to remove general exception filters.
        /// </summary>
        REMOVE = 0x00000004,
    }
}
