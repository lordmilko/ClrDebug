using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for writing to a document referenced by a symbol store.
    /// </summary>
    public class SymUnmanagedDocumentWriter : ComObject<ISymUnmanagedDocumentWriter>
    {
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
        public void SetSource(uint sourceSize, IntPtr source)
        {
            HRESULT hr;

            if ((hr = TrySetSource(sourceSize, source)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets embedded source for a document that is being written.
        /// </summary>
        /// <param name="sourceSize">[in] A ULONG32 that contains the size of the source buffer.</param>
        /// <param name="source">[in] The buffer that stores the embedded source.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetSource(uint sourceSize, IntPtr source)
        {
            /*HRESULT SetSource([In] uint sourceSize, [In] IntPtr source);*/
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
        public void SetCheckSum(Guid algorithmId, uint checkSumSize, IntPtr checkSum)
        {
            HRESULT hr;

            if ((hr = TrySetCheckSum(algorithmId, checkSumSize, checkSum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets checksum information.
        /// </summary>
        /// <param name="algorithmId">[in] The GUID that represents the algorithm identifier.</param>
        /// <param name="checkSumSize">[in] A ULONG32 that indicates the size, in bytes, of the checkSum buffer.</param>
        /// <param name="checkSum">[in] The buffer that stores the checksum information.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetCheckSum(Guid algorithmId, uint checkSumSize, IntPtr checkSum)
        {
            /*HRESULT SetCheckSum([In] Guid algorithmId, [In] uint checkSumSize, [In] IntPtr checkSum);*/
            return Raw.SetCheckSum(algorithmId, checkSumSize, checkSum);
        }

        #endregion
        #endregion
    }
}