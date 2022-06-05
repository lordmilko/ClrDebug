namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values indicating the level of precision required when querying for the size of a save operation.
    /// </summary>
    public enum CorSaveSize : uint
    {
        /// <summary>
        /// Specifies that the return value should be exact.
        /// </summary>
        cssAccurate,

        /// <summary>
        /// Specifies that the return value should be estimated.
        /// </summary>
        cssQuick,

        /// <summary>
        /// Specifies that discardable types should be removed.
        /// </summary>
        cssDiscardTransientCAs
    }
}