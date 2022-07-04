using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodProps"/> method.
    /// </summary>
    [DebuggerDisplay("pMethodToken = {pMethodToken.ToString(),nq}, pcGenericParams = {pcGenericParams}, signature = {signature}")]
    public struct GetMethodPropsResult
    {
        /// <summary>
        /// A pointer to the method's metadata token.
        /// </summary>
        public mdToken pMethodToken { get; }

        /// <summary>
        /// A pointer to the number of generic parameters associated with this method.
        /// </summary>
        public int pcGenericParams { get; }

        /// <summary>
        /// A buffer that holds the typespec signatures of all generic parameters.
        /// </summary>
        public byte[] signature { get; }

        public GetMethodPropsResult(mdToken pMethodToken, int pcGenericParams, byte[] signature)
        {
            this.pMethodToken = pMethodToken;
            this.pcGenericParams = pcGenericParams;
            this.signature = signature;
        }
    }
}
