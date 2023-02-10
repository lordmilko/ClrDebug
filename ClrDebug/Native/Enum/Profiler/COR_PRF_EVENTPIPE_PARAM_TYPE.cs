namespace ClrDebug
{
    /// <summary>
    /// Describes the type of a parameter for an EventPipe event.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EVENTPIPE_PARAM_TYPE enumeration is used by the <see cref="COR_PRF_EVENTPIPE_PARAM_DESC"/> structure
    /// to indicate the type of the parameter.
    /// </remarks>
    public enum COR_PRF_EVENTPIPE_PARAM_TYPE
    {
        /// <summary>
        /// The parameter type is a self describing object.
        /// </summary>
        COR_PRF_EVENTPIPE_OBJECT = 1,         // Instance that isn't a value

        /// <summary>
        /// The parameter type is a boolean.
        /// </summary>
        COR_PRF_EVENTPIPE_BOOLEAN = 3,        // Boolean

        /// <summary>
        /// The parameter type is a 16 bit wide character.
        /// </summary>
        COR_PRF_EVENTPIPE_CHAR = 4,           // Unicode character

        /// <summary>
        /// The parameter type is a signed 8 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_SBYTE = 5,          // Signed 8-bit integer

        /// <summary>
        /// The parameter type is an unsigned 8 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_BYTE = 6,           // Unsigned 8-bit integer

        /// <summary>
        /// The parameter type is a signed 16 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_INT16 = 7,          // Signed 16-bit integer

        /// <summary>
        /// The parameter type is an unsigned 16 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_UINT16 = 8,         // Unsigned 16-bit integer

        /// <summary>
        /// The parameter type is a signed 32 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_INT32 = 9,          // Signed 32-bit integer

        /// <summary>
        /// The parameter type is an unsigned 32 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_UINT32 = 10,        // Unsigned 32-bit integer

        /// <summary>
        /// The parameter type is a signed 64 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_INT64 = 11,         // Signed 64-bit integer

        /// <summary>
        /// The parameter type is an unsigned 64 bit integer.
        /// </summary>
        COR_PRF_EVENTPIPE_UINT64 = 12,        // Unsigned 64-bit integer

        /// <summary>
        /// The parameter type is a 32 bit floating point number.
        /// </summary>
        COR_PRF_EVENTPIPE_SINGLE = 13,        // IEEE 32-bit float

        /// <summary>
        /// The parameter type is a 64 bit floating point number.
        /// </summary>
        COR_PRF_EVENTPIPE_DOUBLE = 14,        // IEEE 64-bit double

        /// <summary>
        /// The parameter type is a 128 bit floating point number.
        /// </summary>
        COR_PRF_EVENTPIPE_DECIMAL = 15,       // Decimal

        /// <summary>
        /// The parameter type is a serialized DataTime structure.
        /// </summary>
        COR_PRF_EVENTPIPE_DATETIME = 16,      // DateTime

        /// <summary>
        /// The parameter type is a GUID.
        /// </summary>
        COR_PRF_EVENTPIPE_GUID = 17,          // Guid

        /// <summary>
        /// The parameter type is a 16 bit null terminated wide character string.
        /// </summary>
        COR_PRF_EVENTPIPE_STRING = 18,        // Unicode character string

        /// <summary>
        /// The parameter type is an array of one of the preceding types.
        /// </summary>
        COR_PRF_EVENTPIPE_ARRAY = 19,         // Arbitrary length array
    }
}
