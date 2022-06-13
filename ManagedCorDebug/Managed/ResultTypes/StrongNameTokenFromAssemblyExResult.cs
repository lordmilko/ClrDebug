using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameTokenFromAssemblyEx"/> method.
    /// </summary>
    [DebuggerDisplay("ppbStrongNameToken = {ppbStrongNameToken}, pcbStrongNameToken = {pcbStrongNameToken}, ppbPublicKeyBlob = {ppbPublicKeyBlob}, pcbPublicKeyBlob = {pcbPublicKeyBlob}")]
    public struct StrongNameTokenFromAssemblyExResult
    {
        /// <summary>
        /// The returned strong name token.
        /// </summary>
        public IntPtr ppbStrongNameToken { get; }

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

        public StrongNameTokenFromAssemblyExResult(IntPtr ppbStrongNameToken, int pcbStrongNameToken, IntPtr ppbPublicKeyBlob, int pcbPublicKeyBlob)
        {
            this.ppbStrongNameToken = ppbStrongNameToken;
            this.pcbStrongNameToken = pcbStrongNameToken;
            this.ppbPublicKeyBlob = ppbPublicKeyBlob;
            this.pcbPublicKeyBlob = pcbPublicKeyBlob;
        }
    }
}