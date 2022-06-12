using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedVariable.GetSignature"/> method.
    /// </summary>
    [DebuggerDisplay("pcSig = {pcSig}, sig = {sig}")]
    public struct GetSignatureResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the signature.
        /// </summary>
        public int pcSig { get; }

        /// <summary>
        /// [out] The buffer that stores the signature.
        /// </summary>
        public byte[] sig { get; }

        public GetSignatureResult(int pcSig, byte[] sig)
        {
            this.pcSig = pcSig;
            this.sig = sig;
        }
    }
}