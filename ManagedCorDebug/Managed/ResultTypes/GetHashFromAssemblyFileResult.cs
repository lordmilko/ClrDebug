namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromAssemblyFile"/> method.
    /// </summary>
    public struct GetHashFromAssemblyFileResult
    {
        /// <summary>
        /// [in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// [out] The returned hash buffer.
        /// </summary>
        public byte pbHash { get; }

        /// <summary>
        /// [out] The returned size, in bytes, of pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromAssemblyFileResult(int piHashAlg, byte pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}