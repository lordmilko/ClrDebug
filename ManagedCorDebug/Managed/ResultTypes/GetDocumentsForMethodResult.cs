using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymENCUnmanagedMethod.GetDocumentsForMethod"/> method.
    /// </summary>
    [DebuggerDisplay("pcDocs = {pcDocs}, documents = {documents}")]
    public struct GetDocumentsForMethodResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the documents.
        /// </summary>
        public int pcDocs { get; }

        /// <summary>
        /// The buffer that contains the documents.
        /// </summary>
        public ISymUnmanagedDocument[] documents { get; }

        public GetDocumentsForMethodResult(int pcDocs, ISymUnmanagedDocument[] documents)
        {
            this.pcDocs = pcDocs;
            this.documents = documents;
        }
    }
}