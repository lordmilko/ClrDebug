using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodProps"/> method.
    /// </summary>
    [DebuggerDisplay("pMethodToken = {pMethodToken}, pcGenericParams = {pcGenericParams}, pcbSignature = {pcbSignature}, signature = {signature}")]
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
        /// A pointer to the size of the returned signature array.
        /// </summary>
        public int pcbSignature { get; }

        /// <summary>
        /// A buffer that holds the typespec signatures of all generic parameters.
        /// </summary>
        public byte[] signature { get; }

        public GetMethodPropsResult(mdToken pMethodToken, int pcGenericParams, int pcbSignature, byte[] signature)
        {
            this.pMethodToken = pMethodToken;
            this.pcGenericParams = pcGenericParams;
            this.pcbSignature = pcbSignature;
            this.signature = signature;
        }
    }
}