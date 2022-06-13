using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetSigFromToken"/> method.
    /// </summary>
    [DebuggerDisplay("ppvSig = {ppvSig}, pcbSig = {pcbSig}")]
    public struct GetSigFromTokenResult
    {
        /// <summary>
        /// A pointer to the returned metadata signature.
        /// </summary>
        public IntPtr ppvSig { get; }

        /// <summary>
        /// The size in bytes of the binary metadata signature.
        /// </summary>
        public int pcbSig { get; }

        public GetSigFromTokenResult(IntPtr ppvSig, int pcbSig)
        {
            this.ppvSig = ppvSig;
            this.pcbSig = pcbSig;
        }
    }
}