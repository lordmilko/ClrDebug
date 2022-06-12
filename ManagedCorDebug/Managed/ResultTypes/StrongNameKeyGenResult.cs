using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameKeyGen"/> method.
    /// </summary>
    public struct StrongNameKeyGenResult
    {
        /// <summary>
        /// [out] The returned public/private key pair.
        /// </summary>
        public IntPtr ppbKeyBlob { get; }

        /// <summary>
        /// [out] The size, in bytes, of ppbKeyBlob.
        /// </summary>
        public int pcbKeyBlob { get; }

        public StrongNameKeyGenResult(IntPtr ppbKeyBlob, int pcbKeyBlob)
        {
            this.ppbKeyBlob = ppbKeyBlob;
            this.pcbKeyBlob = pcbKeyBlob;
        }
    }
}