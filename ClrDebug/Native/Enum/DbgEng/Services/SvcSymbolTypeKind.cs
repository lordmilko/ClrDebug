namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of type that a given type is. While the interfaces are somewhat different in this layer, the definitions here mirror the data model's "debug host" definitions.
    /// </summary>
    public enum SvcSymbolTypeKind : uint
    {
        /// <summary>
        /// The type is a UDT (user defined type -- a struct, class, etc...).
        /// </summary>
        SvcSymbolTypeUDT,

        /// <summary>
        /// The type is a pointer The base type of a pointer as returned by GetBaseType() is the type pointed to.
        /// </summary>
        SvcSymbolTypePointer,

        /// <summary>
        /// The type is a member pointer.
        /// </summary>
        SvcSymbolTypeMemberPointer,

        /// <summary>
        /// The type is an array The base type of an array as returned by GetBaseType() is the type of each element of the array.
        /// </summary>
        SvcSymbolTypeArray,

        /// <summary>
        /// The type is a function.
        /// </summary>
        SvcSymbolTypeFunction,

        /// <summary>
        /// The type is a typedef The base type of a typedef as returned by GetBaseType() is the type of the definition.
        /// </summary>
        SvcSymbolTypeTypedef,

        /// <summary>
        /// The type is an enum.
        /// </summary>
        SvcSymbolTypeEnum,

        /// <summary>
        /// The type is an intrinsic (basic type).
        /// </summary>
        SvcSymbolTypeIntrinsic
    }
}
