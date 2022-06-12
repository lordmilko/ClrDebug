using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromAssemblyEx"/> method.
    /// </summary>
    public struct StrongNameTokenFromAssemblyExResult
    {
        /// <summary>
        /// [out] The returned strong name token.
        /// </summary>
        public IntPtr ppbStrongNameToken { get; }

        /// <summary>
        /// [out] The size, in bytes, of the strong name token.
        /// </summary>
        public int pcbStrongNameToken { get; }

        /// <summary>
        /// [out] The returned public key.
        /// </summary>
        public IntPtr ppbPublicKeyBlob { get; }

        /// <summary>
        /// [out] The size, in bytes, of the public key.
        /// </summary>
        public int pcbPublicKeyBlob { get; }

        public StrongNameTokenFromAssemblyExResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken, IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            this.ppbStrongNameToken = ppbStrongNameToken;
            this.pcbStrongNameToken = pcbStrongNameToken;
            this.ppbPublicKeyBlob = ppbPublicKeyBlob;
            this.pcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}