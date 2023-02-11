namespace ClrDebug
{
    /// <summary>
    /// Describes the type of an object handle.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_HANDLE_TYPE enumeration is used by the ICorProfilerInfo13.CreateHandle method to indicate the type
    /// of handle being created.
    /// </remarks>
    public enum COR_PRF_HANDLE_TYPE
    {
        /// <summary>
        /// The handle tracks an object as long as it is alive. It does not act as a root for the garbage collector.
        /// </summary>
        COR_PRF_HANDLE_TYPE_WEAK = 0x1,

        /// <summary>
        /// The handle acts as a normal object reference. The object will stay alive and be promoted during the next garbage collection.
        /// </summary>
        COR_PRF_HANDLE_TYPE_STRONG = 0x2,

        /// <summary>
        /// The handle acts as a strong handle with an added property to prevent the object from moving in memory during any garbage collection.
        /// </summary>
        COR_PRF_HANDLE_TYPE_PINNED = 0x3
    }
}
