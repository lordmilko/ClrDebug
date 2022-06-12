using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameGetPublicKey"/> method.
    /// </summary>
    public struct StrongNameGetPublicKeyResult
    {
        /// <summary>
        /// [out] The returned public key BLOB. The ppbPublicKeyBlob parameter is allocated by the common language runtime and returned to the caller.<para/>
        /// The caller must free the memory by using the <see cref="CLRStrongName.StrongNameFreeBuffer"/> method.
        /// </summary>
        public IntPtr ppbPublicKeyBlob { get; }

        /// <summary>
        /// [out] The size of the returned public key BLOB.
        /// </summary>
        public int pcbPublicKeyBlob { get; }

        public StrongNameGetPublicKeyResult(IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            this.ppbPublicKeyBlob = ppbPublicKeyBlob;
            this.pcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}