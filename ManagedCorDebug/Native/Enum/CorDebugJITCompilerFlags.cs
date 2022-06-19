using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that influence the behavior of the managed just-in-time (JIT) compiler.
    /// </summary>
    [Flags]
    public enum CorDebugJITCompilerFlags
    {
        /// <summary>
        /// Specifies that the compiler should track compilation data, and allows optimizations.
        /// </summary>
        CORDEBUG_JIT_DEFAULT = 0x1,

        /// <summary>
        /// Specifies that the compiler should track compilation data, but disables optimizations.
        /// </summary>
        CORDEBUG_JIT_DISABLE_OPTIMIZATION = 0x3,

        /// <summary>
        /// Specifies that the compiler should track compilation data, disables optimizations, and enables Edit and Continue technologies.
        /// </summary>
        CORDEBUG_JIT_ENABLE_ENC = 0x7
    }
}
