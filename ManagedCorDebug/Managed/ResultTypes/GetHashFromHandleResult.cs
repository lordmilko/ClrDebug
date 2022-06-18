using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromHandle"/> method.
    /// </summary>
    [DebuggerDisplay("piHashAlg = {piHashAlg}, pchHash = {pchHash}")]
    public struct GetHashFromHandleResult
    {
        /// <summary>
        /// A constant that specifies the hash algorithm. Use zero for the default algorithm.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// The size, in bytes, of the returned pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromHandleResult(int piHashAlg, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pchHash = pchHash;
        }
    }
}