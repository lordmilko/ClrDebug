using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromFileW"/> method.
    /// </summary>
    [DebuggerDisplay("piHashAlg = {piHashAlg}, pchHash = {pchHash}")]
    public struct GetHashFromFileWResult
    {
        /// <summary>
        /// The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI.<para/>
        /// If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// The size, in bytes, of pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromFileWResult(int piHashAlg, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pchHash = pchHash;
        }
    }
}