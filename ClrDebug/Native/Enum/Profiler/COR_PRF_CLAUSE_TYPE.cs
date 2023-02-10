namespace ClrDebug
{
    /// <summary>
    /// Indicates the type of exception clause that the code has just entered or left.
    /// </summary>
    public enum COR_PRF_CLAUSE_TYPE
    {
        /// <summary>
        /// The exception clause is not valid.
        /// </summary>
        COR_PRF_CLAUSE_NONE,

        /// <summary>
        /// The exception clause is a filter expression.
        /// </summary>
        COR_PRF_CLAUSE_FILTER,

        /// <summary>
        /// The exception clause is a catch statement.
        /// </summary>
        COR_PRF_CLAUSE_CATCH,

        /// <summary>
        /// The exception clause is a finally statement.
        /// </summary>
        COR_PRF_CLAUSE_FINALLY,
    }
}
