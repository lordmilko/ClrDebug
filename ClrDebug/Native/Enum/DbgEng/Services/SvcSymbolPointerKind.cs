namespace ClrDebug.DbgEng
{
    public enum SvcSymbolPointerKind : uint
    {
        SvcSymbolPointerStandard,
        SvcSymbolPointerReference,
        SvcSymbolPointerRValueReference,
        SvcSymbolPointerCXHat,
        SvcSymbolPointerManagedReference
    }
}
