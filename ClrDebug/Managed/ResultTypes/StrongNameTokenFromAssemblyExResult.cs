using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromAssemblyEx"/> method.
    /// </summary>
    [DebuggerDisplay("pcbStrongNameToken = {pcbStrongNameToken}, ppbPublicKeyBlob = {ppbPublicKeyBlob.ToString(),nq}, pcbPublicKeyBlob = {pcbPublicKeyBlob}")]
    public struct StrongNameTokenFromAssemblyExResult
    {
        /// <summary>
        /// The size, in bytes, of the strong name token.
        /// </summary>
        public int pcbStrongNameToken { get; }

        /// <summary>
        /// The returned public key.
        /// </summary>
        public IntPtr ppbPublicKeyBlob { get; }

        /// <summary>
        /// The size, in bytes, of the public key.
        /// </summary>
        public int pcbPublicKeyBlob { get; }

        public StrongNameTokenFromAssemblyExResult(int pcbStrongNameToken, IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            this.pcbStrongNameToken = pcbStrongNameToken;
            this.ppbPublicKeyBlob = ppbPublicKeyBlob;
            this.pcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}
