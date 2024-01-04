using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostTypeSignature.IsMatch"/> method.
    /// </summary>
    [DebuggerDisplay("isMatch = {isMatch}, wildcardMatches = {wildcardMatches?.ToString(),nq}")]
    public struct IsMatchResult
    {
        /// <summary>
        /// An indication of whether the type instance matches the type signature is returned here.
        /// </summary>
        public bool isMatch { get; }

        /// <summary>
        /// If the type instance matches the type signature, an enumerator will be returned here which will enumerate all the specific portions of the type instance (as symbols) which matched wildcards in the type signature.
        /// </summary>
        public DebugHostSymbolEnumerator wildcardMatches { get; }

        public IsMatchResult(bool isMatch, DebugHostSymbolEnumerator wildcardMatches)
        {
            this.isMatch = isMatch;
            this.wildcardMatches = wildcardMatches;
        }
    }
}
