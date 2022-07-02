using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameKeyGen"/> method.
    /// </summary>
    [DebuggerDisplay("ppbKeyBlob = {ppbKeyBlob.ToString(),nq}, pcbKeyBlob = {pcbKeyBlob}")]
    public struct StrongNameKeyGenResult
    {
        /// <summary>
        /// The returned public/private key pair.
        /// </summary>
        public IntPtr ppbKeyBlob { get; }

        /// <summary>
        /// The size, in bytes, of ppbKeyBlob.
        /// </summary>
        public int pcbKeyBlob { get; }

        public StrongNameKeyGenResult(IntPtr ppbKeyBlob, int pcbKeyBlob)
        {
            this.ppbKeyBlob = ppbKeyBlob;
            this.pcbKeyBlob = pcbKeyBlob;
        }
    }
}