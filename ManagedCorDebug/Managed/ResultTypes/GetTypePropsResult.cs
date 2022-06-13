using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetTypeProps"/> method.
    /// </summary>
    [DebuggerDisplay("pcbSignature = {pcbSignature}, signature = {signature}")]
    public struct GetTypePropsResult
    {
        /// <summary>
        /// [out] A pointer to the size of the returned signature array.
        /// </summary>
        public int pcbSignature { get; }

        /// <summary>
        /// A buffer that holds the typespec signatures of all generic parameters.
        /// </summary>
        public byte[] signature { get; }

        public GetTypePropsResult(int pcbSignature, byte[] signature)
        {
            this.pcbSignature = pcbSignature;
            this.signature = signature;
        }
    }
}