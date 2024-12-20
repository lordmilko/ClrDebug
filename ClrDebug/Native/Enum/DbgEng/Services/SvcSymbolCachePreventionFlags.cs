namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A set of flags which describe ways that a symbol should *NOT* be cached by a client. This is completely *OPTIONAL* to implement and should be treated as a hint to clients.
    /// </summary>
    public enum SvcSymbolCachePreventionFlags : uint
    {
        SvcSymbolCachePreventionNone = 0,

        /// <summary>
        /// SvcSymbolCachePreventionByAddress: Do not cache the symbol by address.
        /// </summary>
        SvcSymbolCachePreventionByAddress,

        /// <summary>
        /// SvcSymbolCachePreventionByName: Do not cache the symbol by name (lacking qualification).
        /// </summary>
        SvcSymbolCachePreventionByName,

        /// <summary>
        /// SvcSymbolCachePreventionByQualifiedName: Do not cache the symbol by qualified name.
        /// </summary>
        SvcSymbolCachePreventionByQualifiedName
    }
}
