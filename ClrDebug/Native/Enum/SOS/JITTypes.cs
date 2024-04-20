using System;

namespace ClrDebug
{
    [Flags]
    public enum JITTypes : uint
    {
        /// <summary>
        /// Indicates that a method has not yet been jitted.
        /// </summary>
        TYPE_UNKNOWN,

        /// <summary>
        /// Indicates that a method has been jitted.
        /// </summary>
        TYPE_JIT,

        /// <summary>
        /// Indicates that a method was pre-jitted as part of an NGEN assembly.
        /// </summary>
        TYPE_PJIT,
    }
}
