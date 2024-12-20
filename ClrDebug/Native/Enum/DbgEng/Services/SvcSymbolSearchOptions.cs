namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes search options for symbol enumeration. This directly corresponds to definitions in the data model.
    /// </summary>
    public enum SvcSymbolSearchOptions : uint
    {
        SvcSymbolSearchNone = 0x00000000,
        SvcSymbolSearchQualifiedName = 0x00000002
    }
}
