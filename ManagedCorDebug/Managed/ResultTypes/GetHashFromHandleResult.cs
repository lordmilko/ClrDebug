namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromHandle"/> method.
    /// </summary>
    public struct GetHashFromHandleResult
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

        public GetHashFromHandleResult(int piHashAlg, byte pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}