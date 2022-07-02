using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetTypeSpecFromToken"/> method.
    /// </summary>
    [DebuggerDisplay("ppvSig = {ppvSig.ToString(),nq}, pcbSig = {pcbSig}")]
    public struct GetTypeSpecFromTokenResult
    {
        /// <summary>
        /// A pointer to the binary metadata signature.
        /// </summary>
        public IntPtr ppvSig { get; }

        /// <summary>
        /// The size, in bytes, of the metadata signature.
        /// </summary>
        public int pcbSig { get; }

        public GetTypeSpecFromTokenResult(IntPtr ppvSig, int pcbSig)
        {
            this.ppvSig = ppvSig;
            this.pcbSig = pcbSig;
        }
    }
}