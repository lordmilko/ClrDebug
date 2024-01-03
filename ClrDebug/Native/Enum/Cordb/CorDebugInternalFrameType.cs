namespace ClrDebug
{
    /// <summary>
    /// Identifies the type of stack frame. This enumeration is used by the <see cref="ICorDebugInternalFrame.GetFrameType"/> method.
    /// </summary>
    public enum CorDebugInternalFrameType
    {
        /// <summary>
        /// A null value. The <see cref="ICorDebugInternalFrame.GetFrameType"/> method never returns this value.
        /// </summary>
        STUBFRAME_NONE,

        /// <summary>
        /// A managed-to-unmanaged stub frame.
        /// </summary>
        STUBFRAME_M2U,

        /// <summary>
        /// An unmanaged-to-managed stub frame.
        /// </summary>
        STUBFRAME_U2M,

        /// <summary>
        /// A transition between application domains.
        /// </summary>
        STUBFRAME_APPDOMAIN_TRANSITION,

        /// <summary>
        /// A lightweight method call.
        /// </summary>
        STUBFRAME_LIGHTWEIGHT_FUNCTION,

        /// <summary>
        /// The start of function evaluation.
        /// </summary>
        STUBFRAME_FUNC_EVAL,

        /// <summary>
        /// An internal call into the common language runtime.
        /// </summary>
        STUBFRAME_INTERNALCALL,

        /// <summary>
        /// The start of a class initialization.
        /// </summary>
        STUBFRAME_CLASS_INIT,

        /// <summary>
        /// An exception that is thrown.
        /// </summary>
        STUBFRAME_EXCEPTION,

        /// <summary>
        /// A frame used for code access security.
        /// </summary>
        STUBFRAME_SECURITY,

        /// <summary>
        /// The runtime is JIT-compiling a method.
        /// </summary>
        STUBFRAME_JIT_COMPILATION
    }
}