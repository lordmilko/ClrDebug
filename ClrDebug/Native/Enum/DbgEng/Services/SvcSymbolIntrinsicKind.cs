namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of intrinsic that an intrinsic type is. While the interfaces are somewhat different in this layer, the definitions here mirror the data model's "debug host" definitions.
    /// </summary>
    public enum SvcSymbolIntrinsicKind : uint
    {
        /// <summary>
        /// void.
        /// </summary>
        SvcSymbolIntrinsicVoid,

        /// <summary>
        /// bool.
        /// </summary>
        SvcSymbolIntrinsicBool,

        /// <summary>
        /// char.
        /// </summary>
        SvcSymbolIntrinsicChar,

        /// <summary>
        /// wchar_t.
        /// </summary>
        SvcSymbolIntrinsicWChar,

        /// <summary>
        /// signed int (of some size -- not necessarily 4 bytes).
        /// </summary>
        SvcSymbolIntrinsicInt,

        /// <summary>
        /// unsigned int (of some size -- not necessarily 4 bytes).
        /// </summary>
        SvcSymbolIntrinsicUInt,

        /// <summary>
        /// long (of some size -- not necessarily 4 bytes).
        /// </summary>
        SvcSymbolIntrinsicLong,

        /// <summary>
        /// unsigned long (of some size -- not necessarily 4 bytes).
        /// </summary>
        SvcSymbolIntrinsicULong,

        /// <summary>
        /// floating point (of some size -- not necessarily 4 bytes).
        /// </summary>
        SvcSymbolIntrinsicFloat,

        /// <summary>
        /// HRESULT.
        /// </summary>
        SvcSymbolIntrinsicHRESULT,

        /// <summary>
        /// char16_t.
        /// </summary>
        SvcSymbolIntrinsicChar16,

        /// <summary>
        /// char32_t.
        /// </summary>
        SvcSymbolIntrinsicChar32,

        /// <summary>
        /// unsigned char.
        /// </summary>
        SvcSymbolIntrinsicUChar
    }
}
