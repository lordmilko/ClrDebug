namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugMergedAssemblyRecord.GetPublicKey"/> method.
    /// </summary>
    public struct GetPublicKeyResult
    {
        /// <summary>
        /// [out] A pointer to the actual number of bytes written to the pbPublicKey array.
        /// </summary>
        public int pcbPublicKey { get; }

        /// <summary>
        /// [out] A pointer to a byte array that contains the assembly's public key.
        /// </summary>
        public byte[] pbPublicKey { get; }

        public GetPublicKeyResult(int pcbPublicKey, byte[] pbPublicKey)
        {
            this.pcbPublicKey = pcbPublicKey;
            this.pbPublicKey = pbPublicKey;
        }
    }
}