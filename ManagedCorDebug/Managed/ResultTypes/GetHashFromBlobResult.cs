namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromBlob"/> method.
    /// </summary>
    public struct GetHashFromBlobResult
    {
        /// <summary>
        /// [in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// [out] The returned hash buffer.
        /// </summary>
        public byte pbHash { get; }

        /// <summary>
        /// [out] The size, in bytes, of the returned pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromBlobResult(int piHashAlg, byte pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}