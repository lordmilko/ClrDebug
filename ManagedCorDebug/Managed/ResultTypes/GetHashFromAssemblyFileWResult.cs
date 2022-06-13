using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromAssemblyFileW"/> method.
    /// </summary>
    [DebuggerDisplay("piHashAlg = {piHashAlg}, pbHash = {pbHash}, pchHash = {pchHash}")]
    public struct GetHashFromAssemblyFileWResult
    {
        /// <summary>
        /// A constant that specifies the hash algorithm. Use zero for the default hash algorithm.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// The returned hash buffer.
        /// </summary>
        public byte pbHash { get; }

        /// <summary>
        /// The returned size, in bytes, of pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromAssemblyFileWResult(int piHashAlg, byte pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}