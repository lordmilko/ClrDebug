namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of a symbol and what it will respond to. While the interfaces are somewhat different in this layer, the definitions here mirror the data model's "debug host" definitions.
    /// </summary>
    public enum SvcSymbolKind : uint
    {
        /// <summary>
        /// Unspecified symbol type.
        /// </summary>
        SvcSymbol,

        /// <summary>
        /// Reserved: Unused (no "module level symbol" here).
        /// </summary>
        SvcSymbolReserved1,

        /// <summary>
        /// The symbol is a type.
        /// </summary>
        SvcSymbolType,

        /// <summary>
        /// The symbol is a field.
        /// </summary>
        SvcSymbolField,

        /// <summary>
        /// The symbol is a constant.
        /// </summary>
        SvcSymbolConstant,

        /// <summary>
        /// The symbol is data which is not a field of a structure and is QI'able for IDebugHostData.
        /// </summary>
        SvcSymbolData,

        /// <summary>
        /// The symbol is a base class.
        /// </summary>
        SvcSymbolBaseClass,

        /// <summary>
        /// The symbol is a public symbol.
        /// </summary>
        SvcSymbolPublic,

        /// <summary>
        /// The symbol is a function symbol.
        /// </summary>
        SvcSymbolFunction,

        /// <summary>
        /// The symbol is data which is a parameter to a function.
        /// </summary>
        SvcSymbolDataParameter,

        /// <summary>
        /// The symbol is data which is a function local.
        /// </summary>
        SvcSymbolDataLocal,

        /// <summary>
        /// The symbol is a namespace.
        /// </summary>
        SvcSymbolNamespace,

        /// <summary>
        /// The symbol is an inline function (other than being inlined, this behaves much like SvcSymbolFunction).
        /// </summary>
        SvcSymbolInlinedFunction,

        /// <summary>
        /// The symbol is a compilation unit / compiland.
        /// </summary>
        SvcSymbolCompilationUnit,

        /// <summary>
        /// The symbol is a case of a tagged union UDT
        /// </summary>
        SvcSymbolTaggedUnionCase
    }
}
