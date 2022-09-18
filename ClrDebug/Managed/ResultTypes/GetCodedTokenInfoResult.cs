using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetCodedTokenInfo"/> method.
    /// </summary>
    [DebuggerDisplay("ppTokens = {ppTokens}, ppName = {ppName}")]
    public struct GetCodedTokenInfoResult
    {
        /// <summary>
        /// A pointer to a pointer to an array that contains the list of returned tokens.
        /// </summary>
        public mdToken[] ppTokens { get; }

        /// <summary>
        /// A pointer to a pointer to the name of the token at ixCdTkn.
        /// </summary>
        public string ppName { get; }

        public GetCodedTokenInfoResult(mdToken[] ppTokens, string ppName)
        {
            this.ppTokens = ppTokens;
            this.ppName = ppName;
        }
    }
}
