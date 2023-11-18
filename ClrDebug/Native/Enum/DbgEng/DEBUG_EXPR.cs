namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Expression syntax options.
    /// </summary>
    public enum DEBUG_EXPR : uint
    {
        /// <summary>
        /// MASM-style expression evaluation.
        /// </summary>
        MASM = 0,

        /// <summary>
        /// C++-style expression evaluation.
        /// </summary>
        CPLUSPLUS = 1,
    }
}
