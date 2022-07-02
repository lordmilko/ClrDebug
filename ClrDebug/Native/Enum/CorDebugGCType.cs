namespace ClrDebug
{
    /// <summary>
    /// Indicates whether the garbage collector is running on a workstation or a server.
    /// </summary>
    public enum CorDebugGCType
    {
        /// <summary>
        /// The garbage collector is running on a workstation.
        /// </summary>
        CorDebugWorkstationGC,

        /// <summary>
        /// The garbage collector is running on a server.
        /// </summary>
        CorDebugServerGC
    }
}