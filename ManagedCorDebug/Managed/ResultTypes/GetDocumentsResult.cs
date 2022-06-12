using System;

namespace ManagedCorDebug
{
    public struct GetDocumentsResult
    {
        public int PcDocs { get; }

        public IntPtr PDocs { get; }

        public GetDocumentsResult(int pcDocs, IntPtr pDocs)
        {
            PcDocs = pcDocs;
            PDocs = pDocs;
        }
    }
}