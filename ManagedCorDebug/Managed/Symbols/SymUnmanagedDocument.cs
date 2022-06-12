using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a document referenced by a symbol store. A document is defined by a uniform resource locator (URL) and a document type GUID.<para/>
    /// You can locate the document regardless of how it is stored by using the URL and document type GUID. You can store the document source in the symbol store and retrieve it through this interface.
    /// </summary>
    public class SymUnmanagedDocument : ComObject<ISymUnmanagedDocument>
    {
        public SymUnmanagedDocument(ISymUnmanagedDocument raw) : base(raw)
        {
        }

        #region ISymUnmanagedDocument
        #region GetDocumentType

        /// <summary>
        /// Gets the document type of this document.
        /// </summary>
        public Guid DocumentType
        {
            get
            {
                HRESULT hr;
                Guid pRetVal;

                if ((hr = TryGetDocumentType(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region GetLanguage

        /// <summary>
        /// Gets the language identifier of this document
        /// </summary>
        public Guid Language
        {
            get
            {
                HRESULT hr;
                Guid pRetVal;

                if ((hr = TryGetLanguage(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region GetLanguageVendor

        /// <summary>
        /// Gets the language vendor of this document.
        /// </summary>
        public Guid LanguageVendor
        {
            get
            {
                HRESULT hr;
                Guid pRetVal;

                if ((hr = TryGetLanguageVendor(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region GetCheckSumAlgorithmId

        /// <summary>
        /// Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.
        /// </summary>
        public Guid CheckSumAlgorithmId
        {
            get
            {
                HRESULT hr;
                Guid pRetVal;

                if ((hr = TryGetCheckSumAlgorithmId(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region GetSourceLength

        /// <summary>
        /// Gets the length, in bytes, of the embedded source.
        /// </summary>
        public int SourceLength
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetSourceLength(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetSourceLength([Out] out int pRetVal);*/
            return Raw.GetSourceLength(out pRetVal);
        }

        #endregion
        #region GetURL

        /// <summary>
        /// Returns the uniform resource locator (URL) for this document.
        /// </summary>
        /// <returns>[out] The buffer containing the URL.</returns>
        public string GetURL()
        {
            HRESULT hr;
            string szUrlResult;

            if ((hr = TryGetURL(out szUrlResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szUrlResult;
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
            out int pcchUrl,
            [Out] StringBuilder szUrl);*/
            int cchUrl = 0;
            int pcchUrl;
            StringBuilder szUrl = null;
            HRESULT hr = Raw.GetURL(cchUrl, out pcchUrl, szUrl);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchUrl = pcchUrl;
            szUrl = new StringBuilder(pcchUrl);
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
        #region GetCheckSum

        /// <summary>
        /// Gets the checksum.
        /// </summary>
        /// <param name="cData">[in] The length of the buffer provided by the data parameter</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetCheckSumResult GetCheckSum(int cData)
        {
            HRESULT hr;
            GetCheckSumResult result;

            if ((hr = TryGetCheckSum(cData, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the checksum.
        /// </summary>
        /// <param name="cData">[in] The length of the buffer provided by the data parameter</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        public HRESULT TryGetCheckSum(int cData, out GetCheckSumResult result)
        {
            /*HRESULT GetCheckSum([In] int cData, out int pcData, [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            int pcData;
            byte[] data = null;
            HRESULT hr = Raw.GetCheckSum(cData, out pcData, data);

            if (hr == HRESULT.S_OK)
                result = new GetCheckSumResult(pcData, data);
            else
                result = default(GetCheckSumResult);

            return hr;
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
            HRESULT hr;
            int pRetVal;

            if ((hr = TryFindClosestLine(line, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT FindClosestLine([In] int line, [Out] out int pRetVal);*/
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
            HRESULT hr;
            int pRetVal;

            if ((hr = TryHasEmbeddedSource(out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Returns true if the document has source embedded in the debugging symbols; otherwise, returns false.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryHasEmbeddedSource(out int pRetVal)
        {
            /*HRESULT HasEmbeddedSource([Out] out int pRetVal);*/
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
        /// <param name="cSourceBytes">[in] The size of the source, in bytes.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSourceRangeResult GetSourceRange(int startLine, int startColumn, int endLine, int endColumn, int cSourceBytes)
        {
            HRESULT hr;
            GetSourceRangeResult result;

            if ((hr = TryGetSourceRange(startLine, startColumn, endLine, endColumn, cSourceBytes, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns the specified range of the embedded source into the given buffer. The buffer must be large enough to hold the source.
        /// </summary>
        /// <param name="startLine">[in] The starting line in the current document.</param>
        /// <param name="startColumn">[in] The starting column in the current document.</param>
        /// <param name="endLine">[in] The final line in the current document.</param>
        /// <param name="endColumn">[in] The final column in the current document.</param>
        /// <param name="cSourceBytes">[in] The size of the source, in bytes.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        public HRESULT TryGetSourceRange(int startLine, int startColumn, int endLine, int endColumn, int cSourceBytes, out GetSourceRangeResult result)
        {
            /*HRESULT GetSourceRange(
            [In] int startLine,
            [In] int startColumn,
            [In] int endLine,
            [In] int endColumn,
            [In] int cSourceBytes,
            out int pcSourceBytes,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] source);*/
            int pcSourceBytes;
            byte[] source = null;
            HRESULT hr = Raw.GetSourceRange(startLine, startColumn, endLine, endColumn, cSourceBytes, out pcSourceBytes, source);

            if (hr == HRESULT.S_OK)
                result = new GetSourceRangeResult(pcSourceBytes, source);
            else
                result = default(GetSourceRangeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}