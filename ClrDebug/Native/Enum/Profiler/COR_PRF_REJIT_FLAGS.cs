namespace ClrDebug
{
    /// <summary>
    /// Contains values that indicate how the <see cref="ICorProfilerInfo10.RequestReJITWithInliners"/> API should behave.
    /// </summary>
    public enum COR_PRF_REJIT_FLAGS
    {
        /// <summary>
        /// ReJITted methods will be blocked from being inlined in other methods.
        /// </summary>
        COR_PRF_REJIT_BLOCK_INLINING = 0x1,

        /// <summary>
        /// Receive GetFunctionParameters callbacks for any methods that inline the methods requested to be ReJITted.
        /// </summary>
        COR_PRF_REJIT_INLINING_CALLBACKS = 0x2
    }
}
