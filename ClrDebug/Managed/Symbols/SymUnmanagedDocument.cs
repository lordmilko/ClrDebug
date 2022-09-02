using System;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents a document referenced by a symbol store. A document is defined by a uniform resource locator (URL) and a document type GUID.<para/>
    /// You can locate the document regardless of how it is stored by using the URL and document type GUID. You can store the document source in the symbol store and retrieve it through this interface.
    /// </summary>
    public class SymUnmanagedDocument : ComObject<ISymUnmanagedDocument>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedDocument"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedDocument(ISymUnmanagedDocument raw) : base(raw)
        {
        }

        #region ISymUnmanagedDocument
        #region URL

        /// <summary>
        /// Returns the uniform resource locator (URL) for this document.
        /// </summary>
        public string URL
        {
            get
            {
                string szUrlResult;
                TryGetURL(out szUrlResult).ThrowOnNotOK();

                return szUrlResult;
            }
        }

        /// <summary>
        /// Returns the uniform resource locator (URL) for this document.
        /// </summary>
        /// <param name="szUrlResult">[out] The buffer containing the URL.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetURL(out string szUrlResult)
        {
            /*HRESULT GetURL(
            [In] int cchUrl,
            [Out] out int pcchUrl,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szUrl);*/
            int cchUrl = 0;
            int pcchUrl;
            StringBuilder szUrl;
            HRESULT hr = Raw.GetURL(cchUrl, out pcchUrl, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchUrl = pcchUrl;
            szUrl = new StringBuilder(cchUrl);
            hr = Raw.GetURL(cchUrl, out pcchUrl, szUrl);

            if (hr == HRESULT.S_OK)
            {
                szUrlResult = szUrl.ToString();

                return hr;
            }

            fail:
            szUrlResult = default(string);

            return hr;
        }

        #endregion
        #region DocumentType

        /// <summary>
        /// Gets the document type of this document.
        /// </summary>
        public Guid DocumentType
        {
            get
            {
                Guid pRetVal;
                TryGetDocumentType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the document type of this document.
        /// </summary>
        /// <param name="pRetVal">[out] Pointer to a variable that receives the document type.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetDocumentType(out Guid pRetVal)
        {
            /*HRESULT GetDocumentType(
            [Out] out Guid pRetVal);*/
            return Raw.GetDocumentType(out pRetVal);
        }

        #endregion
        #region Language

        /// <summary>
        /// Gets the language identifier of this document
        /// </summary>
        public Guid Language
        {
            get
            {
                Guid pRetVal;
                TryGetLanguage(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the language identifier of this document
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the language identifier.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetLanguage(out Guid pRetVal)
        {
            /*HRESULT GetLanguage(
            [Out] out Guid pRetVal);*/
            return Raw.GetLanguage(out pRetVal);
        }

        #endregion
        #region LanguageVendor

        /// <summary>
        /// Gets the language vendor of this document.
        /// </summary>
        public Guid LanguageVendor
        {
            get
            {
                Guid pRetVal;
                TryGetLanguageVendor(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the language vendor of this document.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the language vendor.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetLanguageVendor(out Guid pRetVal)
        {
            /*HRESULT GetLanguageVendor(
            [Out] out Guid pRetVal);*/
            return Raw.GetLanguageVendor(out pRetVal);
        }

        #endregion
        #region CheckSumAlgorithmId

        /// <summary>
        /// Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.
        /// </summary>
        public Guid CheckSumAlgorithmId
        {
            get
            {
                Guid pRetVal;
                TryGetCheckSumAlgorithmId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the checksum algorithm identifier.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetCheckSumAlgorithmId(out Guid pRetVal)
        {
            /*HRESULT GetCheckSumAlgorithmId(
            [Out] out Guid pRetVal);*/
            return Raw.GetCheckSumAlgorithmId(out pRetVal);
        }

        #endregion
        #region CheckSum

        /// <summary>
        /// Gets the checksum.
        /// </summary>
        public byte[] CheckSum
        {
            get
            {
                byte[] data;
                TryGetCheckSum(out data).ThrowOnNotOK();

                return data;
            }
        }

        /// <summary>
        /// Gets the checksum.
        /// </summary>
        /// <param name="data">[out] The buffer that receives the checksum.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetCheckSum(out byte[] data)
        {
            /*HRESULT GetCheckSum(
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] byte[] data);*/
            int cData = 0;
            int pcData;
            data = null;
            HRESULT hr = Raw.GetCheckSum(cData, out pcData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cData = pcData;
            data = new byte[cData];
            hr = Raw.GetCheckSum(cData, out pcData, data);
            fail:
            return hr;
        }

        #endregion
        #region SourceLength

        /// <summary>
        /// Gets the length, in bytes, of the embedded source.
        /// </summary>
        public int SourceLength
        {
            get
            {
                int pRetVal;
                TryGetSourceLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the length, in bytes, of the embedded source.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that indicates the length, in bytes, of the embedded source.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetSourceLength(out int pRetVal)
        {
            /*HRESULT GetSourceLength(
            [Out] out int pRetVal);*/
            return Raw.GetSourceLength(out pRetVal);
        }

        #endregion
        #region FindClosestLine

        /// <summary>
        /// Returns the closest line that is a sequence point, given a line in this document that may or may not be a sequence point.
        /// </summary>
        /// <param name="line">[in] A line in this document.</param>
        /// <returns>[out] A pointer to a variable that receives the line.</returns>
        public int FindClosestLine(int line)
        {
            int pRetVal;
            TryFindClosestLine(line, out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Returns the closest line that is a sequence point, given a line in this document that may or may not be a sequence point.
        /// </summary>
        /// <param name="line">[in] A line in this document.</param>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the line.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryFindClosestLine(int line, out int pRetVal)
        {
            /*HRESULT FindClosestLine(
            [In] int line,
            [Out] out int pRetVal);*/
            return Raw.FindClosestLine(line, out pRetVal);
        }

        #endregion
        #region HasEmbeddedSource

        /// <summary>
        /// Returns true if the document has source embedded in the debugging symbols; otherwise, returns false.
        /// </summary>
        /// <returns>[out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.</returns>
        public int HasEmbeddedSource()
        {
            int pRetVal;
            TryHasEmbeddedSource(out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Returns true if the document has source embedded in the debugging symbols; otherwise, returns false.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryHasEmbeddedSource(out int pRetVal)
        {
            /*HRESULT HasEmbeddedSource(
            [Out] out int pRetVal);*/
            return Raw.HasEmbeddedSource(out pRetVal);
        }

        #endregion
        #region GetSourceRange

        /// <summary>
        /// Returns the specified range of the embedded source into the given buffer. The buffer must be large enough to hold the source.
        /// </summary>
        /// <param name="startLine">[in] The starting line in the current document.</param>
        /// <param name="startColumn">[in] The starting column in the current document.</param>
        /// <param name="endLine">[in] The final line in the current document.</param>
        /// <param name="endColumn">[in] The final column in the current document.</param>
        /// <returns>[out] The size and length of the specified range of the source document, in bytes.</returns>
        public byte[] GetSourceRange(int startLine, int startColumn, int endLine, int endColumn)
        {
            byte[] source;
            TryGetSourceRange(startLine, startColumn, endLine, endColumn, out source).ThrowOnNotOK();

            return source;
        }

        /// <summary>
        /// Returns the specified range of the embedded source into the given buffer. The buffer must be large enough to hold the source.
        /// </summary>
        /// <param name="startLine">[in] The starting line in the current document.</param>
        /// <param name="startColumn">[in] The starting column in the current document.</param>
        /// <param name="endLine">[in] The final line in the current document.</param>
        /// <param name="endColumn">[in] The final column in the current document.</param>
        /// <param name="source">[out] The size and length of the specified range of the source document, in bytes.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetSourceRange(int startLine, int startColumn, int endLine, int endColumn, out byte[] source)
        {
            /*HRESULT GetSourceRange(
            [In] int startLine,
            [In] int startColumn,
            [In] int endLine,
            [In] int endColumn,
            [In] int cSourceBytes,
            [Out] out int pcSourceBytes,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] byte[] source);*/
            int cSourceBytes = 0;
            int pcSourceBytes;
            source = null;
            HRESULT hr = Raw.GetSourceRange(startLine, startColumn, endLine, endColumn, cSourceBytes, out pcSourceBytes, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cSourceBytes = pcSourceBytes;
            source = new byte[cSourceBytes];
            hr = Raw.GetSourceRange(startLine, startColumn, endLine, endColumn, cSourceBytes, out pcSourceBytes, source);
            fail:
            return hr;
        }

        #endregion
        #endregion
    }
}
