using System;

namespace ManagedCorDebug
{
    public struct StrongNameSignatureGenerationResult
    {
        public IntPtr PpbSignatureBlob { get; }

        public uint PcbSignatureBlob { get; }

        public StrongNameSignatureGenerationResult(IntPtr ppbSignatureBlob, uint pcbSignatureBlob)
        {
            PpbSignatureBlob = ppbSignatureBlob;
            PcbSignatureBlob = pcbSignatureBlob;
        }
    }
}