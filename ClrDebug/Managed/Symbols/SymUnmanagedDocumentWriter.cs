using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for writing to a document referenced by a symbol store.
    /// </summary>
    public class SymUnmanagedDocumentWriter : ComObject<ISymUnmanagedDocumentWriter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedDocumentWriter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedDocumentWriter(ISymUnmanagedDocumentWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedDocumentWriter
        #region SetSource

        /// <summary>
        /// Sets embedded source for a document that is being written.
        /// </summary>
        /// <param name="sourceSize">[in] A ULONG32 that contains the size of the source buffer.</param>
        /// <param name="source">[in] The buffer that stores the embedded source.</param>
        public void SetSource(int sourceSize, IntPtr source)
        {
            TrySetSource(sourceSize, source).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets embedded source for a document that is being written.
        /// </summary>
        /// <param name="sourceSize">[in] A ULONG32 that contains the size of the source buffer.</param>
        /// <param name="source">[in] The buffer that stores the embedded source.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetSource(int sourceSize, IntPtr source)
        {
            /*HRESULT SetSource(
            [In] int sourceSize,
            [In] IntPtr source);*/
            return Raw.SetSource(sourceSize, source);
        }

        #endregion
        #region SetCheckSum

        /// <summary>
        /// Sets checksum information.
        /// </summary>
        /// <param name="algorithmId">[in] The GUID that represents the algorithm identifier.</param>
        /// <param name="checkSumSize">[in] A ULONG32 that indicates the size, in bytes, of the checkSum buffer.</param>
        /// <param name="checkSum">[in] The buffer that stores the checksum information.</param>
        public void SetCheckSum(Guid algorithmId, int checkSumSize, IntPtr checkSum)
        {
            TrySetCheckSum(algorithmId, checkSumSize, checkSum).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets checksum information.
        /// </summary>
        /// <param name="algorithmId">[in] The GUID that represents the algorithm identifier.</param>
        /// <param name="checkSumSize">[in] A ULONG32 that indicates the size, in bytes, of the checkSum buffer.</param>
        /// <param name="checkSum">[in] The buffer that stores the checksum information.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetCheckSum(Guid algorithmId, int checkSumSize, IntPtr checkSum)
        {
            /*HRESULT SetCheckSum(
            [In] ref Guid algorithmId,
            [In] int checkSumSize,
            [In] IntPtr checkSum);*/
            return Raw.SetCheckSum(ref algorithmId, checkSumSize, checkSum);
        }

        #endregion
        #endregion
    }
}
