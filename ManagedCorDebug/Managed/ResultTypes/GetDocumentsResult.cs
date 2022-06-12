using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetDocuments"/> method.
    /// </summary>
    public struct GetDocumentsResult
    {
        /// <summary>
        /// [out] A pointer to a variable that receives the array length.
        /// </summary>
        public int pcDocs { get; }

        /// <summary>
        /// [out] A pointer to a variable that receives the document array.
        /// </summary>
        public IntPtr pDocs { get; }

        public GetDocumentsResult(int pcDocs, IntPtr pDocs)
        {
            this.pcDocs = pcDocs;
            this.pDocs = pDocs;
        }
    }
}