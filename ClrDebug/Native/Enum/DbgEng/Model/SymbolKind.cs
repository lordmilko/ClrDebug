namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of a symbol.
    /// </summary>
    public enum SymbolKind : uint
    {
        /// <summary>
        /// Unspecified symbol type.
        /// </summary>
        Symbol,

        /// <summary>
        /// The symbol is a module and can be queried for <see cref="IDebugHostModule"/>.
        /// </summary>
        SymbolModule,

        /// <summary>
        /// The symbol is a type and can be queried for <see cref="IDebugHostType"/>.
        /// </summary>
        SymbolType,

        /// <summary>
        /// The symbol is a field (a data member within a structure or class) and can be queried for <see cref="IDebugHostField"/>.
        /// </summary>
        SymbolField,

        /// <summary>
        /// The symbol is a constant value and can be queried for <see cref="IDebugHostConstant"/>.
        /// </summary>
        SymbolConstant,

        /// <summary>
        /// The symbol is data which is not a member of a structure or class and is queryable for <see cref="IDebugHostData"/>.
        /// </summary>
        SymbolData,

        /// <summary>
        /// The symbol is a base class and is queryable for <see cref="IDebugHostBaseClass"/>.
        /// </summary>
        SymbolBaseClass,

        /// <summary>
        /// The symbol is an entry in a module's publics table (having no type information) and is queryable for <see cref="IDebugHostPublic"/>.
        /// </summary>
        SymbolPublic,

        /// <summary>
        /// The symbol is a function and is queryable for <see cref="IDebugHostData"/>.
        /// </summary>
        SymbolFunction
    }
}
