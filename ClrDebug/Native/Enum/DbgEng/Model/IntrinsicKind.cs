namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of an intrinsic (basic) type. This is distinct from the variant type which carries the type.
    /// </summary>
    public enum IntrinsicKind : uint
    {
        /// <summary>
        /// void
        /// </summary>
        IntrinsicVoid,

        /// <summary>
        /// bool
        /// </summary>
        IntrinsicBool,

        /// <summary>
        /// char
        /// </summary>
        IntrinsicChar,

        /// <summary>
        /// wchar_t
        /// </summary>
        IntrinsicWChar,

        /// <summary>
        /// signed int (of some size -- not necessarily 4 bytes)
        /// </summary>
        IntrinsicInt,

        /// <summary>
        /// unsigned int (of some size -- not necessarily 4 bytes)
        /// </summary>
        IntrinsicUInt,

        /// <summary>
        /// long (of some size)
        /// </summary>
        IntrinsicLong,

        /// <summary>
        /// unsigned long (of some size)
        /// </summary>
        IntrinsicULong,

        /// <summary>
        /// floating point (of some size -- not necessarily 4 bytes)
        /// </summary>
        IntrinsicFloat,

        /// <summary>
        /// HRESULT
        /// </summary>
        IntrinsicHRESULT,

        /// <summary>
        /// char16_t
        /// </summary>
        IntrinsicChar16,

        /// <summary>
        /// char32_t
        /// </summary>
        IntrinsicChar32
    }
}
