using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromPublicKey"/> method.
    /// </summary>
    public struct StrongNameTokenFromPublicKeyResult
    {
        /// <summary>
        /// [out] The strong name token corresponding to the key passed in pbPublicKeyBlob. The common language runtime allocates the memory in which to return the token.<para/>
        /// The caller must free this memory by using the <see cref="CLRStrongName.StrongNameFreeBuffer"/> method.
        /// </summary>
        public IntPtr ppbStrongNameToken { get; }

        /// <summary>
        /// [out] The size, in bytes, of the returned strong name token.
        /// </summary>
        public int pcbStrongNameToken { get; }

        public StrongNameTokenFromPublicKeyResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken)
        {
            this.ppbStrongNameToken = ppbStrongNameToken;
            this.pcbStrongNameToken = pcbStrongNameToken;
        }
    }
}