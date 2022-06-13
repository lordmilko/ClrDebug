using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugMergedAssemblyRecord.GetPublicKey"/> method.
    /// </summary>
    [DebuggerDisplay("pcbPublicKey = {pcbPublicKey}, pbPublicKey = {pbPublicKey}")]
    public struct GetPublicKeyResult
    {
        /// <summary>
        /// A pointer to the actual number of bytes written to the pbPublicKey array.
        /// </summary>
        public int pcbPublicKey { get; }

        /// <summary>
        /// A pointer to a byte array that contains the assembly's public key.
        /// </summary>
        public byte[] pbPublicKey { get; }

        public GetPublicKeyResult(int pcbPublicKey, byte[] pbPublicKey)
        {
            this.pcbPublicKey = pcbPublicKey;
            this.pbPublicKey = pbPublicKey;
        }
    }
}