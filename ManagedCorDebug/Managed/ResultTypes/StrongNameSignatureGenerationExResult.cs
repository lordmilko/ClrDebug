using System;

namespace ManagedCorDebug
{
    public struct StrongNameSignatureGenerationExResult
    {
        public IntPtr PpbSignatureBlob { get; }

        public int PcbSignatureBlob { get; }

        public StrongNameSignatureGenerationExResult(IntPtr ppbSignatureBlob, int pcbSignatureBlob)
        {
            PpbSignatureBlob = ppbSignatureBlob;
            PcbSignatureBlob = pcbSignatureBlob;
        }
    }
}