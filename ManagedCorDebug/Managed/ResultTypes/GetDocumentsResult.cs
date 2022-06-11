using System;

namespace ManagedCorDebug
{
    public struct GetDocumentsResult
    {
        public uint PcDocs { get; }

        public IntPtr PDocs { get; }

        public GetDocumentsResult(uint pcDocs, IntPtr pDocs)
        {
            PcDocs = pcDocs;
            PDocs = pDocs;
        }
    }
}