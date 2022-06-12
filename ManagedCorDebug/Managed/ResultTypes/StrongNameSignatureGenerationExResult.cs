using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameSignatureGenerationEx"/> method.
    /// </summary>
    public struct StrongNameSignatureGenerationExResult
    {
        /// <summary>
        /// [out] A pointer to the location to which the common language runtime returns the signature. If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.<para/>
        /// If ppbSignatureBlob is not null, the common language runtime allocates space in which to return the signature. The caller must free this space using the <see cref="CLRStrongName.StrongNameFreeBuffer"/> method.
        /// </summary>
        public IntPtr ppbSignatureBlob { get; }

        /// <summary>
        /// [out] The size, in bytes, of the returned signature.
        /// </summary>
        public int pcbSignatureBlob { get; }

        public StrongNameSignatureGenerationExResult(IntPtr ppbSignatureBlob, int pcbSignatureBlob)
        {
            this.ppbSignatureBlob = ppbSignatureBlob;
            this.pcbSignatureBlob = pcbSignatureBlob;
        }
    }
}