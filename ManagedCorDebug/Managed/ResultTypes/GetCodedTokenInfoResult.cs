using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetCodedTokenInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pcTokens = {pcTokens}, ppTokens = {ppTokens}, ppName = {ppName}")]
    public struct GetCodedTokenInfoResult
    {
        /// <summary>
        /// A pointer to the length of ppTokens.
        /// </summary>
        public int pcTokens { get; }

        /// <summary>
        /// A pointer to a pointer to an array that contains the list of returned tokens.
        /// </summary>
        public int[] ppTokens { get; }

        /// <summary>
        /// A pointer to a pointer to the name of the token at ixCdTkn.
        /// </summary>
        public string ppName { get; }

        public GetCodedTokenInfoResult(int pcTokens, int[] ppTokens, string ppName)
        {
            this.pcTokens = pcTokens;
            this.ppTokens = ppTokens;
            this.ppName = ppName;
        }
    }
}