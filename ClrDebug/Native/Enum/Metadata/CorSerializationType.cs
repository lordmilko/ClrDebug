namespace ClrDebug
{
    /// <summary>
    /// Specifies how an object is serialized by the common language runtime.
    /// </summary>
    public enum CorSerializationType : uint
    {
        /// <summary>
        /// Serialization of the object is undefined.
        /// </summary>
        SERIALIZATION_TYPE_UNDEFINED = 0,

        /// <summary>
        /// Object is serialized as a Boolean type
        /// </summary>
        SERIALIZATION_TYPE_BOOLEAN = CorElementType.Boolean,

        /// <summary>
        /// Object is serialized as a character type.
        /// </summary>
        SERIALIZATION_TYPE_CHAR = CorElementType.Char,

        /// <summary>
        /// Object is serialized as a signed 1-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_I1 = CorElementType.I1,

        /// <summary>
        /// Object is serialized as an unsigned 1-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_U1 = CorElementType.U1,

        /// <summary>
        /// Object is serialized as a signed 2-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_I2 = CorElementType.I2,

        /// <summary>
        /// Object is serialized as an unsigned 2-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_U2 = CorElementType.U2,

        /// <summary>
        /// Object is serialized as a signed 4-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_I4 = CorElementType.I4,

        /// <summary>
        /// Object is serialized as an unsigned 4-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_U4 = CorElementType.U4,

        /// <summary>
        /// Object is serialized as a signed 8-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_I8 = CorElementType.I8,

        /// <summary>
        /// Object is serialized as an unsigned 8-byte integer.
        /// </summary>
        SERIALIZATION_TYPE_U8 = CorElementType.U8,

        /// <summary>
        /// Object is serialized as a 4-byte floating point.
        /// </summary>
        SERIALIZATION_TYPE_R4 = CorElementType.R4,

        /// <summary>
        /// Object is serialized as an 8-byte floating point.
        /// </summary>
        SERIALIZATION_TYPE_R8 = CorElementType.R8,

        /// <summary>
        /// Object is serialized as a System.String type.
        /// </summary>
        SERIALIZATION_TYPE_STRING = CorElementType.String,

        /// <summary>
        /// Object is serialized as a single-dimensional, zero lower-bound array.
        /// </summary>
        SERIALIZATION_TYPE_SZARRAY = CorElementType.SZArray, // Shortcut for single dimension zero lower bound array

        /// <summary>
        /// Object is serialized as a generic type.
        /// </summary>
        SERIALIZATION_TYPE_TYPE = 0x50,

        /// <summary>
        /// Object is serialized as a tagged object.
        /// </summary>
        SERIALIZATION_TYPE_TAGGED_OBJECT = 0x51,

        /// <summary>
        /// Object is serialized as a field.
        /// </summary>
        SERIALIZATION_TYPE_FIELD = 0x53,

        /// <summary>
        /// Object is serialized as a property.
        /// </summary>
        SERIALIZATION_TYPE_PROPERTY = 0x54,

        /// <summary>
        /// Object is serialized as an enumeration.
        /// </summary>
        SERIALIZATION_TYPE_ENUM = 0x55
    }
}