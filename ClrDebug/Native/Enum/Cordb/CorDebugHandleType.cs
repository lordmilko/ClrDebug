namespace ClrDebug
{
    /// <summary>
    /// Indicates the handle type.
    /// </summary>
    public enum CorDebugHandleType
    {
        /// <summary>
        /// The handle is strong, which prevents an object from being reclaimed by garbage collection.
        /// </summary>
        HANDLE_STRONG = 1,

        /// <summary>
        /// The handle is weak, which does not prevent an object from being reclaimed by garbage collection. The handle becomes invalid when the object is collected.
        /// </summary>
        HANDLE_WEAK_TRACK_RESURRECTION = 2
    }
}