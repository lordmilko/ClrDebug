using System;

namespace ManagedCorDebug
{
    public struct StrongNameSignatureGenerationResult
    {
        public IntPtr PpbSignatureBlob { get; }

        public int PcbSignatureBlob { get; }

        public StrongNameSignatureGenerationResult(IntPtr ppbSignatureBlob, int pcbSignatureBlob)
        {
            PpbSignatureBlob = ppbSignatureBlob;
            PcbSignatureBlob = pcbSignatureBlob;
        }
    }
}