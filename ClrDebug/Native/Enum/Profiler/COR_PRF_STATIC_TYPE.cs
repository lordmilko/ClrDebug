namespace ClrDebug
{
    /// <summary>
    /// Indicates whether a field is static and, if so, the static quality that applies to the field. These values can be combined using the bitwise OR operation to indicate that the field has multiple, different static qualities.
    /// </summary>
    public enum COR_PRF_STATIC_TYPE
    {
        /// <summary>
        /// The field is not static.
        /// </summary>
        COR_PRF_FIELD_NOT_A_STATIC = 0,

        /// <summary>
        /// The field is application domain-static.
        /// </summary>
        COR_PRF_FIELD_APP_DOMAIN_STATIC = 1,

        /// <summary>
        /// The field is thread-static.
        /// </summary>
        COR_PRF_FIELD_THREAD_STATIC = 2,

        /// <summary>
        /// The field is context-static.
        /// </summary>
        COR_PRF_FIELD_CONTEXT_STATIC = 4,

        /// <summary>
        /// The field is relative virtual address (RVA)-static.
        /// </summary>
        COR_PRF_FIELD_RVA_STATIC = 8,
    }
}
