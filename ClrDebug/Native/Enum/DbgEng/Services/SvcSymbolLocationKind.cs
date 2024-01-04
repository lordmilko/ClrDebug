namespace ClrDebug.DbgEng
{
    public enum SvcSymbolLocationKind : uint
    {
        SvcSymbolLocationNone,
        SvcSymbolLocationComplex,
        SvcSymbolLocationImageOffset,
        SvcSymbolLocationRegister,
        SvcSymbolLocationRegisterRelative,
        SvcSymbolLocationStructureRelative,
        SvcSymbolLocationVirtualAddress,
        SvcSymbolLocationConstantValue,
        SvcSymbolLocationRegisterRelativeIndirectOffset,
        SvcSymbolLocationStructureRelativeBitField,
        SvcSymbolLocationStructureRelativeTableOffset,
        SvcSymbolLocationTLSOffset,
        SvcSymbolLocationMultipleLocations
    }
}
