namespace ClrDebug
{
    /// <summary>
    /// Indicates the result of a cached function search.
    /// </summary>
    public enum COR_PRF_JIT_CACHE
    {
        /// <summary>
        /// The search found the function.
        /// </summary>
        COR_PRF_CACHED_FUNCTION_FOUND,

        /// <summary>
        /// The search did not find the function.
        /// </summary>
        COR_PRF_CACHED_FUNCTION_NOT_FOUND,
    }
}
