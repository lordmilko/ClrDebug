using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameGetPublicKey"/> method.
    /// </summary>
    [DebuggerDisplay("ppbPublicKeyBlob = {ppbPublicKeyBlob.ToString(),nq}, pcbPublicKeyBlob = {pcbPublicKeyBlob}")]
    public struct StrongNameGetPublicKeyResult
    {
        /// <summary>
        /// The returned public key BLOB. The ppbPublicKeyBlob parameter is allocated by the common language runtime and returned to the caller.<para/>
        /// The caller must free the memory by using the <see cref="CLRStrongName.StrongNameFreeBuffer"/> method.
        /// </summary>
        public IntPtr ppbPublicKeyBlob { get; }

        /// <summary>
        /// The size of the returned public key BLOB.
        /// </summary>
        public int pcbPublicKeyBlob { get; }

        public StrongNameGetPublicKeyResult(IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            this.ppbPublicKeyBlob = ppbPublicKeyBlob;
            this.pcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}