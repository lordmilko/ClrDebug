using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information for the Edit and Continue feature.
    /// </summary>
    public class SymENCUnmanagedMethod : ComObject<ISymENCUnmanagedMethod>
    {
        public SymENCUnmanagedMethod(ISymENCUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymENCUnmanagedMethod
        #region GetDocumentsForMethodCount

        /// <summary>
        /// Gets the number of documents that this method has lines in.
        /// </summary>
        public int DocumentsForMethodCount
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetDocumentsForMethodCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the number of documents that this method has lines in.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the documents.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetDocumentsForMethodCount(out int pRetVal)
        {
            /*HRESULT GetDocumentsForMethodCount(
            [Out] out int pRetVal);*/
            return Raw.GetDocumentsForMethodCount(out pRetVal);
        }

        #endregion
        #region GetFileNameFromOffset

        /// <summary>
        /// Gets the file name for the line associated with an offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <returns>[out] The buffer that contains the file names.</returns>
        public string GetFileNameFromOffset(int dwOffset)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetFileNameFromOffset(dwOffset, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the file name for the line associated with an offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <param name="szNameResult">[out] The buffer that contains the file names.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetFileNameFromOffset(int dwOffset, out string szNameResult)
        {
            /*HRESULT GetFileNameFromOffset(
            [In] int dwOffset,
            [In] int cchName,
            out int pcchName,
            [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetFileNameFromOffset(dwOffset, cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
            hr = Raw.GetFileNameFromOffset(dwOffset, cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetLineFromOffset

        /// <summary>
        /// Gets the line information associated with an offset. If the offset parameter (dwOffset) is not a sequence point, this method gets the line information associated with the previous offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLineFromOffsetResult GetLineFromOffset(int dwOffset)
        {
            HRESULT hr;
            GetLineFromOffsetResult result;

            if ((hr = TryGetLineFromOffset(dwOffset, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the line information associated with an offset. If the offset parameter (dwOffset) is not a sequence point, this method gets the line information associated with the previous offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLineFromOffset(int dwOffset, out GetLineFromOffsetResult result)
        {
            /*HRESULT GetLineFromOffset(
            [In] int dwOffset,
            out int pline,
            out int pcolumn,
            out int pendLine,
            out int pendColumn,
            out int pdwStartOffset);*/
            int pline;
            int pcolumn;
            int pendLine;
            int pendColumn;
            int pdwStartOffset;
            HRESULT hr = Raw.GetLineFromOffset(dwOffset, out pline, out pcolumn, out pendLine, out pendColumn, out pdwStartOffset);

            if (hr == HRESULT.S_OK)
                result = new GetLineFromOffsetResult(pline, pcolumn, pendLine, pendColumn, pdwStartOffset);
            else
                result = default(GetLineFromOffsetResult);

            return hr;
        }

        #endregion
        #region GetDocumentsForMethod

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        /// <param name="cDocs">[in] The length of the buffer pointed to by pcDocs.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentsForMethodResult GetDocumentsForMethod(int cDocs)
        {
            HRESULT hr;
            GetDocumentsForMethodResult result;

            if ((hr = TryGetDocumentsForMethod(cDocs, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        /// <param name="cDocs">[in] The length of the buffer pointed to by pcDocs.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetDocumentsForMethod(int cDocs, out GetDocumentsForMethodResult result)
        {
            /*HRESULT GetDocumentsForMethod(
            [In] int cDocs,
            out int pcDocs,
            [In, Out] ref IntPtr documents);*/
            int pcDocs;
            IntPtr documents = default(IntPtr);
            HRESULT hr = Raw.GetDocumentsForMethod(cDocs, out pcDocs, ref documents);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentsForMethodResult(pcDocs, documents);
            else
                result = default(GetDocumentsForMethodResult);

            return hr;
        }

        #endregion
        #region GetSourceExtentInDocument

        /// <summary>
        /// Gets the smallest start line and largest end line for the method in a specific document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSourceExtentInDocumentResult GetSourceExtentInDocument(ISymUnmanagedDocument document)
        {
            HRESULT hr;
            GetSourceExtentInDocumentResult result;

            if ((hr = TryGetSourceExtentInDocument(document, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the smallest start line and largest end line for the method in a specific document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSourceExtentInDocument(ISymUnmanagedDocument document, out GetSourceExtentInDocumentResult result)
        {
            /*HRESULT GetSourceExtentInDocument(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            out int pstartLine,
            out int pendLine);*/
            int pstartLine;
            int pendLine;
            HRESULT hr = Raw.GetSourceExtentInDocument(document, out pstartLine, out pendLine);

            if (hr == HRESULT.S_OK)
                result = new GetSourceExtentInDocumentResult(pstartLine, pendLine);
            else
                result = default(GetSourceExtentInDocumentResult);

            return hr;
        }

        #endregion
        #endregion
    }
}