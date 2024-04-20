namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the type of memory to access.
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are passed to the <see cref="IDiaStackWalkHelper.readMemory"/> method to limit access
    /// to different types of memory.
    /// </remarks>
    public enum MemoryTypeEnum
    {
        /// <summary>
        /// Accesses any kind of memory.
        /// </summary>
        MemTypeAny = -1, // 0xFFFFFFFF

        /// <summary>
        /// Accesses only code memory.
        /// </summary>
        MemTypeCode = 0,

        /// <summary>
        /// Accesses data or stack memory.
        /// </summary>
        MemTypeData = 1,

        /// <summary>
        /// Accesses only stack memory.
        /// </summary>
        MemTypeStack = 2,

        MemTypeCodeOnHeap = 3
    }
}
