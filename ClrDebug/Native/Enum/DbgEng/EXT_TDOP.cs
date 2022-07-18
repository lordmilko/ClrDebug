namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The EXT_TDOP enumeration is used in the Operation member of the <see cref="EXT_TYPED_DATA"/> structure to specify which suboperation the DEBUG_REQUEST_EXT_TYPED_DATA_ANSI Request operation will perform.
    /// </summary>
    public enum EXT_TDOP
    {
        /// <summary>
        /// Makes a copy of a typed data description.
        /// </summary>
        EXT_TDOP_COPY,

        /// <summary>
        /// Releases a typed data description.
        /// </summary>
        EXT_TDOP_RELEASE,

        /// <summary>
        /// Returns the value of an expression.
        /// </summary>
        EXT_TDOP_SET_FROM_EXPR,

        /// <summary>
        /// Returns the value of an expression. An optional address can be provided as a parameter to the expression.
        /// </summary>
        EXT_TDOP_SET_FROM_U64_EXPR,

        /// <summary>
        /// Returns a member of a structure.
        /// </summary>
        EXT_TDOP_GET_FIELD,

        /// <summary>
        /// Returns the value of an expression. An optional value can be provided as a parameter to the expression.
        /// </summary>
        EXT_TDOP_EVALUATE,

        /// <summary>
        /// Returns the type name for typed data.
        /// </summary>
        EXT_TDOP_GET_TYPE_NAME,

        /// <summary>
        /// Prints the type name for typed data.
        /// </summary>
        EXT_TDOP_OUTPUT_TYPE_NAME,

        /// <summary>
        /// Prints the value of typed data.
        /// </summary>
        EXT_TDOP_OUTPUT_SIMPLE_VALUE,

        /// <summary>
        /// Prints the type and value for typed data.
        /// </summary>
        EXT_TDOP_OUTPUT_FULL_VALUE,

        /// <summary>
        /// Determines whether a structure contains a specified member.
        /// </summary>
        EXT_TDOP_HAS_FIELD,

        /// <summary>
        /// Returns the offset of a member within a structure.
        /// </summary>
        EXT_TDOP_GET_FIELD_OFFSET,

        /// <summary>
        /// Returns an element from an array.
        /// </summary>
        EXT_TDOP_GET_ARRAY_ELEMENT,

        /// <summary>
        /// Dereferences a pointer, returning the value it points to.
        /// </summary>
        EXT_TDOP_GET_DEREFERENCE,

        /// <summary>
        /// Returns the size of the specified typed data.
        /// </summary>
        EXT_TDOP_GET_TYPE_SIZE,

        /// <summary>
        /// Prints the definition of the type for the specified typed data.
        /// </summary>
        EXT_TDOP_OUTPUT_TYPE_DEFINITION,

        /// <summary>
        /// Returns a new typed data description that represents a pointer to specified typed data.
        /// </summary>
        EXT_TDOP_GET_POINTER_TO,

        /// <summary>
        /// Creates a typed data description from a type and memory location.
        /// </summary>
        EXT_TDOP_SET_FROM_TYPE_ID_AND_U64,

        /// <summary>
        /// Creates a typed data description representing a pointer to a specified memory location with specified type.
        /// </summary>
        EXT_TDOP_SET_PTR_FROM_TYPE_ID_AND_U64,

        /// <summary>
        /// Does not specify an operation. Instead, it represents the number of suboperations defined in the EXT_TDOP enumeration.
        /// </summary>
        EXT_TDOP_COUNT
    }
}
