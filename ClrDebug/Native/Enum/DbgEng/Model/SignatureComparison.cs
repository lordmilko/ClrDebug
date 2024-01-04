namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes how a type or two signatures compare.
    /// </summary>
    public enum SignatureComparison : uint
    {
        /// <summary>
        /// The two signatures/types being compared are unrelated.
        /// </summary>
        Unrelated,

        /// <summary>
        /// One signature/type compares ambiguously against the other. For instance, std::pair&lt;*, int&gt; versus std::pair&lt;int, *&gt; are ambiguous.<para/>
        /// There are types that wouldmatch both of these equally well (e.g.: std::pair&lt;int, int&gt;)
        /// </summary>
        Ambiguous,

        /// <summary>
        /// One signature/type is less specific than the other. For instance, a comparison of std::vector&lt;*&gt; against std::vector&lt;int&gt; would yield LessSpecific.
        /// </summary>
        LessSpecific,

        /// <summary>
        /// One signature/type is more specific than the other. For instance, a comparison of std::vector&lt;int&gt; against std::vector&lt;*&gt; would yield MoreSpecific.
        /// </summary>
        MoreSpecific,

        /// <summary>
        /// The signatures/types are identical.
        /// </summary>
        Identical
    }
}
