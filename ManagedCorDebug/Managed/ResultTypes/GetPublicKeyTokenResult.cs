namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugMergedAssemblyRecord.GetPublicKeyToken"/> method.
    /// </summary>
    public struct GetPublicKeyTokenResult
    {
        /// <summary>
        /// [out] A pointer to the actual number of bytes written to the pbPublicKeyToken array.
        /// </summary>
        public int pcbPublicKeyToken { get; }

        /// <summary>
        /// [out] A pointer to a byte array that contains the assembly's public key token.
        /// </summary>
        public byte[] pbPublicKeyToken { get; }

        public GetPublicKeyTokenResult(int pcbPublicKeyToken, byte[] pbPublicKeyToken)
        {
            this.pcbPublicKeyToken = pcbPublicKeyToken;
            this.pbPublicKeyToken = pbPublicKeyToken;
        }
    }
}