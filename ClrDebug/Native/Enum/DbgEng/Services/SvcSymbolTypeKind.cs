namespace ClrDebug.DbgEng
{
    public enum SvcSymbolTypeKind : uint
    {
        SvcSymbolTypeUDT,
        SvcSymbolTypePointer,
        SvcSymbolTypeMemberPointer,
        SvcSymbolTypeArray,
        SvcSymbolTypeFunction,
        SvcSymbolTypeTypedef,
        SvcSymbolTypeEnum,
        SvcSymbolTypeIntrinsic
    }
}
