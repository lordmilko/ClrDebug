using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymENCUnmanagedMethod : ComObject<ISymENCUnmanagedMethod>
    {
        public SymENCUnmanagedMethod(ISymENCUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymENCUnmanagedMethod
        #region GetDocumentsForMethodCount

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

        public HRESULT TryGetDocumentsForMethodCount(out uint pRetVal)
        {
            /*HRESULT GetDocumentsForMethodCount(
            [Out] out uint pRetVal);*/
            return Raw.GetDocumentsForMethodCount(out pRetVal);
        }

        #endregion
        #region GetFileNameFromOffset

        public string GetFileNameFromOffset(uint dwOffset)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetFileNameFromOffset(dwOffset, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

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

        public GetLineFromOffsetResult GetLineFromOffset(uint dwOffset)
        {
            HRESULT hr;
            GetLineFromOffsetResult result;

            if ((hr = TryGetLineFromOffset(dwOffset, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public void GetDocumentsForMethod(uint cDocs, ISymUnmanagedDocument documents)
        {
            HRESULT hr;

            if ((hr = TryGetDocumentsForMethod(cDocs, documents)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetDocumentsForMethod(uint cDocs, ISymUnmanagedDocument documents)
        {
            /*HRESULT GetDocumentsForMethod([In] uint cDocs, out uint pcDocs, [MarshalAs(UnmanagedType.Interface), In]
            ref ISymUnmanagedDocument documents);*/
            uint pcDocs;

            return Raw.GetDocumentsForMethod(cDocs, out pcDocs, ref documents);
        }

        #endregion
        #region GetSourceExtentInDocument

        public GetSourceExtentInDocumentResult GetSourceExtentInDocument(ISymUnmanagedDocument document)
        {
            HRESULT hr;
            GetSourceExtentInDocumentResult result;

            if ((hr = TryGetSourceExtentInDocument(document, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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