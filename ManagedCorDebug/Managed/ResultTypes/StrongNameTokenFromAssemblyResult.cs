using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromAssembly"/> method.
    /// </summary>
    [DebuggerDisplay("ppbStrongNameToken = {ppbStrongNameToken.ToString(),nq}, pcbStrongNameToken = {pcbStrongNameToken}")]
    public struct StrongNameTokenFromAssemblyResult
    {
        /// <summary>
        /// The returned strong name token.
        /// </summary>
        public IntPtr ppbStrongNameToken { get; }

        /// <summary>
        /// The size, in bytes, of the strong name token.
        /// </summary>
        public int pcbStrongNameToken { get; }

        public StrongNameTokenFromAssemblyResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken)
        {
            this.ppbStrongNameToken = ppbStrongNameToken;
            this.pcbStrongNameToken = pcbStrongNameToken;
        }
    }
}