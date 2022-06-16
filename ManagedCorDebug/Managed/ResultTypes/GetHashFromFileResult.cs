using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromFile"/> method.
    /// </summary>
    [DebuggerDisplay("piHashAlg = {piHashAlg}, pbHash = {pbHash}, pchHash = {pchHash}")]
    public struct GetHashFromFileResult
    {
        /// <summary>
        /// The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI.<para/>
        /// If piHashAlg is set to 0, the default algorithm CALG_SHA-1 is used.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// A byte array containing the generated hash.
        /// </summary>
        public IntPtr pbHash { get; }

        /// <summary>
        /// The size, in bytes, of the returned pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromFileResult(int piHashAlg, IntPtr pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}