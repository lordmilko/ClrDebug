namespace ClrDebug
{
    /// <summary>
    /// Identifies the type of process to be enumerated.
    /// </summary>
    /// <remarks>
    /// The current version of the unmanaged debugging API enumerates only managed processes.
    /// </remarks>
    public enum COR_PUB_ENUMPROCESS
    {
        /// <summary>
        /// A managed process.
        /// </summary>
        COR_PUB_MANAGEDONLY = 1,
    }
}
