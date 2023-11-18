namespace ClrDebug.DbgEng
{
    public enum DEBUG_EINDEX : uint
    {
        //Event index description information.

        NAME = 0,

        //SetNextEventIndex relation options.

        /// <summary>
        /// Value increases forward from the first index.
        /// </summary>
        FROM_START = 0,

        /// <summary>
        /// Value increases backwards from the last index.
        /// </summary>
        FROM_END = 1,

        /// <summary>
        /// Value is a signed delta from the current index.
        /// </summary>
        FROM_CURRENT = 2,
    }
}
