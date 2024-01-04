namespace ClrDebug.DbgEng
{
    public enum SvcSymbolCachePreventionFlags : uint
    {
        SvcSymbolCachePreventionNone = 0,
        SvcSymbolCachePreventionByAddress,
        SvcSymbolCachePreventionByName,
        SvcSymbolCachePreventionByQualifiedName
    }
}
