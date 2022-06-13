using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugMergedAssemblyRecord.GetPublicKeyToken"/> method.
    /// </summary>
    [DebuggerDisplay("pcbPublicKeyToken = {pcbPublicKeyToken}, pbPublicKeyToken = {pbPublicKeyToken}")]
    public struct GetPublicKeyTokenResult
    {
        /// <summary>
        /// A pointer to the actual number of bytes written to the pbPublicKeyToken array.
        /// </summary>
        public int pcbPublicKeyToken { get; }

        /// <summary>
        /// A pointer to a byte array that contains the assembly's public key token.
        /// </summary>
        public byte[] pbPublicKeyToken { get; }

        public GetPublicKeyTokenResult(int pcbPublicKeyToken, byte[] pbPublicKeyToken)
        {
            this.pcbPublicKeyToken = pcbPublicKeyToken;
            this.pbPublicKeyToken = pbPublicKeyToken;
        }
    }
}