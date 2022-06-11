using System;

namespace ManagedCorDebug
{
    public struct StrongNameSignatureGenerationExResult
    {
        public IntPtr PpbSignatureBlob { get; }

        public uint PcbSignatureBlob { get; }

        public StrongNameSignatureGenerationExResult(IntPtr ppbSignatureBlob, uint pcbSignatureBlob)
        {
            PpbSignatureBlob = ppbSignatureBlob;
            PcbSignatureBlob = pcbSignatureBlob;
        }
    }
}