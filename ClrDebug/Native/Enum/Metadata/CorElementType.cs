using System;

namespace ClrDebug
{
    /// <summary>
    /// Specifies a common language runtime <see cref="Type"/>, a type modifier, or information about a type in a metadata type signature.
    /// </summary>
    /// <remarks>
    /// The type modifiers form the basis for representing more complex types. A <see cref="CorElementType"/> type modifier value is
    /// applied to the value that immediately follows it in the type signature. The value that follows the <see cref="CorElementType"/>
    /// type modifier value can be a <see cref="CorElementType"/> simple type value, a metadata token, or other value, as specified in
    /// the following table.
    /// </remarks>
    public enum CorElementType : uint
    {
        /// <summary>
        /// Used internally.
        /// </summary>
        End = 0x00,

        /// <summary>
        /// A void type.
        /// </summary>
        Void = 0x01,

        /// <summary>
        /// A Boolean type
        /// </summary>
        Boolean = 0x02,

        /// <summary>
        /// A character type.
        /// </summary>
        Char = 0x03,

        /// <summary>
        /// A signed 1-byte integer.
        /// </summary>
        I1 = 0x04,

        /// <summary>
        /// An unsigned 1-byte integer.
        /// </summary>
        U1 = 0x05,

        /// <summary>
        /// A signed 2-byte integer.
        /// </summary>
        I2 = 0x06,

        /// <summary>
        /// An unsigned 2-byte integer.
        /// </summary>
        U2 = 0x07,

        /// <summary>
        /// A signed 4-byte integer.
        /// </summary>
        I4 = 0x08,

        /// <summary>
        /// An unsigned 4-byte integer.
        /// </summary>
        U4 = 0x09,

        /// <summary>
        /// A signed 8-byte integer.
        /// </summary>
        I8 = 0x0A,

        /// <summary>
        /// An unsigned 8-byte integer.
        /// </summary>
        U8 = 0x0B,

        /// <summary>
        /// A 4-byte floating point.
        /// </summary>
        R4 = 0x0C,

        /// <summary>
        /// An 8-byte floating point.
        /// </summary>
        R8 = 0x0D,

        /// <summary>
        /// A System.String type.
        /// </summary>
        String = 0x0E,

        /// <summary>
        /// A pointer type modifier.
        /// </summary>
        Ptr = 0x0F,

        /// <summary>
        /// A reference type modifier.
        /// </summary>
        ByRef = 0x10,

        /// <summary>
        /// A value type modifier.
        /// </summary>
        ValueType = 0x11,

        /// <summary>
        /// A class type modifier.
        /// </summary>
        Class = 0x12,

        /// <summary>
        /// A class variable type modifier.
        /// </summary>
        Var = 0x13,

        /// <summary>
        /// A multi-dimensional array type modifier.
        /// </summary>
        Array = 0x14,

        /// <summary>
        /// A type modifier for generic types.
        /// </summary>
        GenericInst = 0x15,

        /// <summary>
        /// A typed reference.
        /// </summary>
        TypedByRef = 0x16,
        ValueArray = 0x17,

        /// <summary>
        /// Size of a native integer.
        /// </summary>
        I = 0x18,

        /// <summary>
        /// Size of an unsigned native integer.
        /// </summary>
        U = 0x19,
        R = 0x1A,

        /// <summary>
        /// A pointer to a function.
        /// </summary>
        FnPtr = 0x1B,

        /// <summary>
        /// A System.Object type.
        /// </summary>
        Object = 0x1C,

        /// <summary>
        /// A single-dimensional, zero lower-bound array type modifier.
        /// </summary>
        SZArray = 0x1D,

        /// <summary>
        /// A method variable type modifier.
        /// </summary>
        MVar = 0x1E,

        /// <summary>
        /// A C language required modifier.
        /// </summary>
        CModReqd = 0x1F,

        /// <summary>
        /// A C language optional modifier.
        /// </summary>
        CModOpt = 0x20,

        /// <summary>
        /// Used internally.
        /// </summary>
        Internal = 0x21,
        Module = 0x3F,

        /// <summary>
        /// A type modifier that is a sentinel for a list of a variable number of parameters.
        /// </summary>
        Sentinel = 0x41,

        /// <summary>
        /// Used internally.
        /// </summary>
        Pinned = 0x45,
    }
}
