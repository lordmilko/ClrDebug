namespace ClrDebug.DIA
{
    /// <summary>
    /// Designates thunk types.
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are returned from a call to the <see cref="IDiaSymbol.get_thunkOrdinal"/> method.
    /// </remarks>
    public enum THUNK_ORDINAL
    {
        /// <summary>
        /// Standard thunk.
        /// </summary>
        THUNK_ORDINAL_NOTYPE,

        /// <summary>
        /// A this adjustor thunk.
        /// </summary>
        THUNK_ORDINAL_ADJUSTOR,

        /// <summary>
        /// Virtual call thunk.
        /// </summary>
        THUNK_ORDINAL_VCALL,

        /// <summary>
        /// P-code thunk.
        /// </summary>
        THUNK_ORDINAL_PCODE,

        /// <summary>
        /// Delay load thunk.
        /// </summary>
        THUNK_ORDINAL_LOAD,

        /// <summary>
        /// Incremental trampoline thunk (a trampoline thunk is used to bounce calls from one memory space to another).
        /// </summary>
        THUNK_ORDINAL_TRAMP_INCREMENTAL,

        /// <summary>
        /// Branch point trampoline thunk.
        /// </summary>
        THUNK_ORDINAL_TRAMP_BRANCHISLAND,

        THUNK_ORDINAL_TRAMP_STRICTICF,
        THUNK_ORDINAL_TRAMP_ARM64XSAMEADDRESS,
        THUNK_ORDINAL_TRAMP_FUNCOVERRIDING,
    }
}
