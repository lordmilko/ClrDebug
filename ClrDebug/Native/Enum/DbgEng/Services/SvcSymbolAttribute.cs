namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a set of extensibile and simple "attributes" of symbols which can be queried.
    /// </summary>
    public enum SvcSymbolAttribute : uint
    {
        SvcSymbolAttributeNone = 0,

        /// <summary>
        /// SvcSymbolAttributeConst: (VT_BOOL) Indicates that the symbol has a const modifier.
        /// </summary>
        SvcSymbolAttributeConst,

        /// <summary>
        /// SvcSymbolAttributeVolatile: (VT_BOOL) Indicates that the symbol has a volatile modifier.
        /// </summary>
        SvcSymbolAttributeVolatile,

        /// <summary>
        /// SvcSymbolAttributeVirtual: (VT_BOOL) Indicates that the symbol is virtual (or pure virtual).
        /// </summary>
        SvcSymbolAttributeVirtual,

        /// <summary>
        /// SvcSymbolAttributeVariant: (VT_BOOL) Indicates that the symbol has variant information.
        /// </summary>
        SvcSymbolAttributeVariant,

        /// <summary>
        /// SvcSymbolAttributeCachePrevention: (VT_UI8) A flags field indicating whether the symbol can be cached in certain ways.<para/>
        /// If this attribute is missing, it is assumed the symbol can be cached in *ANY* way that the caller sees fit. The bits here are described by SvcSymbolCachePreventionFlags Any bit in this value being '0' indicates that it is legal to cache the symbol via the described means.<para/>
        /// Values of '1' indicate that a client should not cache the symbol by such means.
        /// </summary>
        SvcSymbolAttributeCachePrevention
    }
}
