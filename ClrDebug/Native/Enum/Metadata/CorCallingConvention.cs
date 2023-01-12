using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the types of calling conventions that are made in managed code.
    /// </summary>
    [Flags]
    public enum CorCallingConvention
    {
        /// <summary>
        /// Indicates a default calling convention.
        /// </summary>
        DEFAULT = 0x0,

        /// <summary>
        /// Indicates that the method takes a variable number of parameters.
        /// </summary>
        VARARG = 0x5,

        /// <summary>
        /// Indicates that the call is to a field.
        /// </summary>
        FIELD = 0x6,

        /// <summary>
        /// Indicates that the call is to a local method.
        /// </summary>
        LOCAL_SIG = 0x7,

        /// <summary>
        /// Indicates that the call is to a property.
        /// </summary>
        PROPERTY = 0x8,

        /// <summary>
        /// Indicates that the call is unmanaged.
        /// </summary>
        UNMGD = 0x9,

        /// <summary>
        /// Indicates a generic method instantiation.
        /// </summary>
        GENERICINST = 0xa,

        /// <summary>
        /// Indicates a 64-bit PInvoke call to a method that takes a variable number of parameters.
        /// </summary>
        NATIVEVARARG = 0xb,

        /// <summary>
        /// Describes an invalid 4-bit value.
        /// </summary>
        MAX = 0xc,

        /// <summary>
        /// Indicates that the calling convention is described by the bottom four bits.
        /// </summary>
        MASK = 0x0f,
        UPMASK = 0xf0,

        /// <summary>
        /// Indicates that the top bit describes a this parameter.
        /// </summary>
        HASTHIS = 0x20,

        /// <summary>
        /// Indicates that a this parameter is explicitly described in the signature.
        /// </summary>
        EXPLICITTHIS = 0x40,

        /// <summary>
        /// Indicates a generic method signature with an explicit number of type arguments. This precedes an ordinary parameter count.
        /// </summary>
        GENERIC = 0x10
    }
}
