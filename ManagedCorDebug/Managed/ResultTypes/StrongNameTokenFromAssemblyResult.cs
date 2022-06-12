using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromAssembly"/> method.
    /// </summary>
    public struct StrongNameTokenFromAssemblyResult
    {
        /// <summary>
        /// [out] The returned strong name token.
        /// </summary>
        public IntPtr ppbStrongNameToken { get; }

        /// <summary>
        /// [out] The size, in bytes, of the strong name token.
        /// </summary>
        public int pcbStrongNameToken { get; }

        public StrongNameTokenFromAssemblyResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken)
        {
            this.ppbStrongNameToken = ppbStrongNameToken;
            this.pcbStrongNameToken = pcbStrongNameToken;
        }
    }
}