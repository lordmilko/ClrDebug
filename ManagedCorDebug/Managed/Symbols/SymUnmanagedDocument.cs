using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedDocument : ComObject<ISymUnmanagedDocument>
    {
        public SymUnmanagedDocument(ISymUnmanagedDocument raw) : base(raw)
        {
        }

        #region ISymUnmanagedDocument
        #region GetDocumentType

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

        public HRESULT TryGetDocumentType(out Guid pRetVal)
        {
            /*HRESULT GetDocumentType(
            [Out] out Guid pRetVal);*/
            return Raw.GetDocumentType(out pRetVal);
        }

        #endregion
        #region GetLanguage

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

        public HRESULT TryGetLanguage(out Guid pRetVal)
        {
            /*HRESULT GetLanguage(
            [Out] out Guid pRetVal);*/
            return Raw.GetLanguage(out pRetVal);
        }

        #endregion
        #region GetLanguageVendor

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

        public HRESULT TryGetLanguageVendor(out Guid pRetVal)
        {
            /*HRESULT GetLanguageVendor(
            [Out] out Guid pRetVal);*/
            return Raw.GetLanguageVendor(out pRetVal);
        }

        #endregion
        #region GetCheckSumAlgorithmId

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

        public HRESULT TryGetCheckSumAlgorithmId(out Guid pRetVal)
        {
            /*HRESULT GetCheckSumAlgorithmId(
            [Out] out Guid pRetVal);*/
            return Raw.GetCheckSumAlgorithmId(out pRetVal);
        }

        #endregion
        #region GetSourceLength

        public uint SourceLength
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetSourceLength(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetSourceLength(out uint pRetVal)
        {
            /*HRESULT GetSourceLength([Out] out uint pRetVal);*/
            return Raw.GetSourceLength(out pRetVal);
        }

        #endregion
        #region GetURL

        public string GetURL()
        {
            HRESULT hr;
            string szUrlResult;

            if ((hr = TryGetURL(out szUrlResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szUrlResult;
        }

        public HRESULT TryGetURL(out string szUrlResult)
        {
            /*HRESULT GetURL(
            [In] uint cchUrl,
            out uint pcchUrl,
            [Out] StringBuilder szUrl);*/
            uint cchUrl = 0;
            uint pcchUrl;
            StringBuilder szUrl = null;
            HRESULT hr = Raw.GetURL(cchUrl, out pcchUrl, szUrl);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchUrl = pcchUrl;
            szUrl = new StringBuilder((int) pcchUrl);
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

        public GetCheckSumResult GetCheckSum(uint cData)
        {
            HRESULT hr;
            GetCheckSumResult result;

            if ((hr = TryGetCheckSum(cData, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCheckSum(uint cData, out GetCheckSumResult result)
        {
            /*HRESULT GetCheckSum([In] uint cData, out uint pcData, [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            uint pcData;
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

        public uint FindClosestLine(uint line)
        {
            HRESULT hr;
            uint pRetVal;

            if ((hr = TryFindClosestLine(line, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryFindClosestLine(uint line, out uint pRetVal)
        {
            /*HRESULT FindClosestLine([In] uint line, [Out] out uint pRetVal);*/
            return Raw.FindClosestLine(line, out pRetVal);
        }

        #endregion
        #region HasEmbeddedSource

        public int HasEmbeddedSource()
        {
            HRESULT hr;
            int pRetVal;

            if ((hr = TryHasEmbeddedSource(out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryHasEmbeddedSource(out int pRetVal)
        {
            /*HRESULT HasEmbeddedSource([Out] out int pRetVal);*/
            return Raw.HasEmbeddedSource(out pRetVal);
        }

        #endregion
        #region GetSourceRange

        public GetSourceRangeResult GetSourceRange(uint startLine, uint startColumn, uint endLine, uint endColumn, uint cSourceBytes)
        {
            HRESULT hr;
            GetSourceRangeResult result;

            if ((hr = TryGetSourceRange(startLine, startColumn, endLine, endColumn, cSourceBytes, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetSourceRange(uint startLine, uint startColumn, uint endLine, uint endColumn, uint cSourceBytes, out GetSourceRangeResult result)
        {
            /*HRESULT GetSourceRange(
            [In] uint startLine,
            [In] uint startColumn,
            [In] uint endLine,
            [In] uint endColumn,
            [In] uint cSourceBytes,
            out uint pcSourceBytes,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] source);*/
            uint pcSourceBytes;
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