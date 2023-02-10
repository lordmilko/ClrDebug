namespace ClrDebug
{
    /// <summary>
    /// Defines the code generation flags that can be set with the <see cref="ICorProfilerFunctionControl.SetCodegenFlags"/> method.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_CODEGEN_FLAGS enumeration is used by the <see cref="ICorProfilerFunctionControl.SetCodegenFlags"/>
    /// method to enable the profiler to control the code generation for the JIT-recompiled function.
    /// </remarks>
    public enum COR_PRF_CODEGEN_FLAGS
    {
        /// <summary>
        /// No functions will be inlined into this function’s body. However, the function itself may be inlined into its callers.
        /// </summary>
        COR_PRF_CODEGEN_DISABLE_INLINING = 0x0001,

        /// <summary>
        /// All optimizations will be disabled for this function’s body. However, the function itself may still be inlined into its callers.
        /// </summary>
        COR_PRF_CODEGEN_DISABLE_ALL_OPTIMIZATIONS = 0x0002,
    }
}
