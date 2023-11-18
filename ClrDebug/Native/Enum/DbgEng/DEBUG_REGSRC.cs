namespace ClrDebug.DbgEng
{
    public enum DEBUG_REGSRC : uint
    {
        /// <summary>
        /// Get register information from the debuggee.
        /// </summary>
        DEBUGGEE = 0,

        /// <summary>
        /// Get register information from an explicit override context, such as one set by .cxr.
        /// If there is no override context the request will fail.
        /// </summary>
        EXPLICIT = 1,

        /// <summary>
        /// Get register information from the current scope frame. Note that stack unwinding does
        /// not guarantee accurate updating of the register context, so scope frame register context
        /// may not be accurate in all cases.
        /// </summary>
        FRAME = 2,
    }
}
