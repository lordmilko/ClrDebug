namespace ClrDebug.DbgEng
{
    public enum SvcSymbolKind : uint
    {
        SvcSymbol,
        SvcSymbolReserved1,
        SvcSymbolType,
        SvcSymbolField,
        SvcSymbolConstant,
        SvcSymbolData,
        SvcSymbolBaseClass,
        SvcSymbolPublic,
        SvcSymbolFunction,
        SvcSymbolDataParameter,
        SvcSymbolDataLocal,
        SvcSymbolNamespace,
        SvcSymbolInlinedFunction,
        SvcSymbolCompilationUnit,
        SvcSymbolTaggedUnionCase
    }
}
