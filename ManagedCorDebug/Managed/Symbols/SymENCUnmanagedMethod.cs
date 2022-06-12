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
        public uint DocumentsForMethodCount
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

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
        public HRESULT TryGetDocumentsForMethodCount(out uint pRetVal)
        {
            /*HRESULT GetDocumentsForMethodCount(
            [Out] out uint pRetVal);*/
            return Raw.GetDocumentsForMethodCount(out pRetVal);
        }

        #endregion
        #region GetFileNameFromOffset

        /// <summary>
        /// Gets the file name for the line associated with an offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <returns>[out] The buffer that contains the file names.</returns>
        public string GetFileNameFromOffset(uint dwOffset)
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
        public HRESULT TryGetFileNameFromOffset(uint dwOffset, out string szNameResult)
        {
            /*HRESULT GetFileNameFromOffset(
            [In] uint dwOffset,
            [In] uint cchName,
            out uint pcchName,
            [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetFileNameFromOffset(dwOffset, cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
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
        public GetLineFromOffsetResult GetLineFromOffset(uint dwOffset)
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
        public HRESULT TryGetLineFromOffset(uint dwOffset, out GetLineFromOffsetResult result)
        {
            /*HRESULT GetLineFromOffset(
            [In] uint dwOffset,
            out uint pline,
            out uint pcolumn,
            out uint pendLine,
            out uint pendColumn,
            out uint pdwStartOffset);*/
            uint pline;
            uint pcolumn;
            uint pendLine;
            uint pendColumn;
            uint pdwStartOffset;
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
        /// <param name="documents">[in] The buffer that contains the documents.</param>
        public void GetDocumentsForMethod(uint cDocs, ISymUnmanagedDocument documents)
        {
            HRESULT hr;

            if ((hr = TryGetDocumentsForMethod(cDocs, documents)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        /// <param name="cDocs">[in] The length of the buffer pointed to by pcDocs.</param>
        /// <param name="documents">[in] The buffer that contains the documents.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetDocumentsForMethod(uint cDocs, ISymUnmanagedDocument documents)
        {
            /*HRESULT GetDocumentsForMethod([In] uint cDocs, out uint pcDocs, [MarshalAs(UnmanagedType.Interface), In]
            ref ISymUnmanagedDocument documents);*/
            uint pcDocs;

            return Raw.GetDocumentsForMethod(cDocs, out pcDocs, ref documents);
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
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            out uint pstartLine,
            out uint pendLine);*/
            uint pstartLine;
            uint pendLine;
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