﻿using System.Linq;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides information for the Edit and Continue feature.
    /// </summary>
    public class SymENCUnmanagedMethod : ComObject<ISymENCUnmanagedMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymENCUnmanagedMethod"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymENCUnmanagedMethod(ISymENCUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymENCUnmanagedMethod
        #region DocumentsForMethodCount

        /// <summary>
        /// Gets the number of documents that this method has lines in.
        /// </summary>
        public int DocumentsForMethodCount
        {
            get
            {
                int pRetVal;
                TryGetDocumentsForMethodCount(out pRetVal).ThrowOnNotOK();

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
        #region DocumentsForMethod

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        public SymUnmanagedDocument[] DocumentsForMethod
        {
            get
            {
                SymUnmanagedDocument[] documentsResult;
                TryGetDocumentsForMethod(out documentsResult).ThrowOnNotOK();

                return documentsResult;
            }
        }

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        /// <param name="documentsResult">[in] The buffer that contains the documents.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetDocumentsForMethod(out SymUnmanagedDocument[] documentsResult)
        {
            /*HRESULT GetDocumentsForMethod(
            [In] int cDocs,
            [Out] out int pcDocs,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents);*/
            int cDocs = 0;
            int pcDocs;
            ISymUnmanagedDocument[] documents;
            HRESULT hr = Raw.GetDocumentsForMethod(cDocs, out pcDocs, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cDocs = pcDocs;
            documents = new ISymUnmanagedDocument[cDocs];
            hr = Raw.GetDocumentsForMethod(cDocs, out pcDocs, documents);

            if (hr == HRESULT.S_OK)
            {
                documentsResult = documents.Select(v => v == null ? null : new SymUnmanagedDocument(v)).ToArray();

                return hr;
            }

            fail:
            documentsResult = default(SymUnmanagedDocument[]);

            return hr;
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
            string szNameResult;
            TryGetFileNameFromOffset(dwOffset, out szNameResult).ThrowOnNotOK();

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
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            HRESULT hr = Raw.GetFileNameFromOffset(dwOffset, cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetFileNameFromOffset(dwOffset, cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = CreateString(szName, pcchName);

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
            GetLineFromOffsetResult result;
            TryGetLineFromOffset(dwOffset, out result).ThrowOnNotOK();

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
            [Out] out int pline,
            [Out] out int pcolumn,
            [Out] out int pendLine,
            [Out] out int pendColumn,
            [Out] out int pdwStartOffset);*/
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
        #region GetSourceExtentInDocument

        /// <summary>
        /// Gets the smallest start line and largest end line for the method in a specific document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSourceExtentInDocumentResult GetSourceExtentInDocument(ISymUnmanagedDocument document)
        {
            GetSourceExtentInDocumentResult result;
            TryGetSourceExtentInDocument(document, out result).ThrowOnNotOK();

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
            [Out] out int pstartLine,
            [Out] out int pendLine);*/
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
