using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameKeyGenEx"/> method.
    /// </summary>
    [DebuggerDisplay("ppbKeyBlob = {ppbKeyBlob}, pcbKeyBlob = {pcbKeyBlob}")]
    public struct StrongNameKeyGenExResult
    {
        /// <summary>
        /// The returned public/private key pair.
        /// </summary>
        public IntPtr ppbKeyBlob { get; }

        /// <summary>
        /// The size, in bytes, of ppbKeyBlob.
        /// </summary>
        public int pcbKeyBlob { get; }

        public StrongNameKeyGenExResult(IntPtr ppbKeyBlob, int pcbKeyBlob)
        {
            this.ppbKeyBlob = ppbKeyBlob;
            this.pcbKeyBlob = pcbKeyBlob;
        }
    }
}