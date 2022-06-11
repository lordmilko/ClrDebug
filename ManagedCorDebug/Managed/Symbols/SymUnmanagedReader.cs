using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedReader : ComObject<ISymUnmanagedReader>
    {
        public SymUnmanagedReader(ISymUnmanagedReader raw) : base(raw)
        {
        }

        #region ISymUnmanagedReader
        #region GetUserEntryPoint

        public uint UserEntryPoint
        {
            get
            {
                HRESULT hr;
                uint pToken;

                if ((hr = TryGetUserEntryPoint(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        public HRESULT TryGetUserEntryPoint(out uint pToken)
        {
            /*HRESULT GetUserEntryPoint([Out] out uint pToken);*/
            return Raw.GetUserEntryPoint(out pToken);
        }

        #endregion
        #region GetDocument

        public SymUnmanagedDocument GetDocument(string url, Guid language, Guid languageVendor, Guid documentType)
        {
            HRESULT hr;
            SymUnmanagedDocument pRetValResult;

            if ((hr = TryGetDocument(url, language, languageVendor, documentType, out pRetValResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetValResult;
        }

        public HRESULT TryGetDocument(string url, Guid language, Guid languageVendor, Guid documentType, out SymUnmanagedDocument pRetValResult)
        {
            /*HRESULT GetDocument(
            [In] string url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType,
            [Out] out ISymUnmanagedDocument pRetVal);*/
            ISymUnmanagedDocument pRetVal;
            HRESULT hr = Raw.GetDocument(url, language, languageVendor, documentType, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedDocument(pRetVal);
            else
                pRetValResult = default(SymUnmanagedDocument);

            return hr;
        }

        #endregion
        #region GetDocuments

        public GetDocumentsResult GetDocuments(uint cDocs)
        {
            HRESULT hr;
            GetDocumentsResult result;

            if ((hr = TryGetDocuments(cDocs, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDocuments(uint cDocs, out GetDocumentsResult result)
        {
            /*HRESULT GetDocuments(
            [In] uint cDocs,
            out uint pcDocs,
            [Out] IntPtr pDocs);*/
            uint pcDocs;
            IntPtr pDocs = default(IntPtr);
            HRESULT hr = Raw.GetDocuments(cDocs, out pcDocs, pDocs);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentsResult(pcDocs, pDocs);
            else
                result = default(GetDocumentsResult);

            return hr;
        }

        #endregion
        #region GetMethod

        public ISymUnmanagedMethod GetMethod(uint token)
        {
            HRESULT hr;
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);

            if ((hr = TryGetMethod(token, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetMethod(uint token, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethod([In] uint token, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethod(token, pRetVal);
        }

        #endregion
        #region GetMethodByVersion

        public ISymUnmanagedMethod GetMethodByVersion(uint token, int version)
        {
            HRESULT hr;
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);

            if ((hr = TryGetMethodByVersion(token, version, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetMethodByVersion(uint token, int version, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodByVersion(
            [In] uint token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethodByVersion(token, version, pRetVal);
        }

        #endregion
        #region GetVariables

        public GetVariablesResult GetVariables(uint parent, uint cVars)
        {
            HRESULT hr;
            GetVariablesResult result;

            if ((hr = TryGetVariables(parent, cVars, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetVariables(uint parent, uint cVars, out GetVariablesResult result)
        {
            /*HRESULT GetVariables(
            [In] uint parent,
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars);*/
            uint pcVars;
            IntPtr pVars = default(IntPtr);
            HRESULT hr = Raw.GetVariables(parent, cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
                result = new GetVariablesResult(pcVars, pVars);
            else
                result = default(GetVariablesResult);

            return hr;
        }

        #endregion
        #region GetGlobalVariables

        public GetGlobalVariablesResult GetGlobalVariables(uint cVars)
        {
            HRESULT hr;
            GetGlobalVariablesResult result;

            if ((hr = TryGetGlobalVariables(cVars, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetGlobalVariables(uint cVars, out GetGlobalVariablesResult result)
        {
            /*HRESULT GetGlobalVariables(
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars);*/
            uint pcVars;
            IntPtr pVars = default(IntPtr);
            HRESULT hr = Raw.GetGlobalVariables(cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
                result = new GetGlobalVariablesResult(pcVars, pVars);
            else
                result = default(GetGlobalVariablesResult);

            return hr;
        }

        #endregion
        #region GetMethodFromDocumentPosition

        public ISymUnmanagedMethod GetMethodFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column)
        {
            HRESULT hr;
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);

            if ((hr = TryGetMethodFromDocumentPosition(document, line, column, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetMethodFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethodFromDocumentPosition(document, line, column, pRetVal);
        }

        #endregion
        #region GetSymAttribute

        public GetSymAttributeResult GetSymAttribute(uint parent, string name, uint cBuffer)
        {
            HRESULT hr;
            GetSymAttributeResult result;

            if ((hr = TryGetSymAttribute(parent, name, cBuffer, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetSymAttribute(uint parent, string name, uint cBuffer, out GetSymAttributeResult result)
        {
            /*HRESULT GetSymAttribute(
            [In] uint parent,
            [In] string name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);*/
            uint pcBuffer;
            byte[] buffer = null;
            HRESULT hr = Raw.GetSymAttribute(parent, name, cBuffer, out pcBuffer, buffer);

            if (hr == HRESULT.S_OK)
                result = new GetSymAttributeResult(pcBuffer, buffer);
            else
                result = default(GetSymAttributeResult);

            return hr;
        }

        #endregion
        #region GetNamespaces

        public GetNamespacesResult GetNamespaces(uint cNameSpaces)
        {
            HRESULT hr;
            GetNamespacesResult result;

            if ((hr = TryGetNamespaces(cNameSpaces, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetNamespaces(uint cNameSpaces, out GetNamespacesResult result)
        {
            /*HRESULT GetNamespaces(
            [In] uint cNameSpaces,
            out uint pcNameSpaces,
            [Out] IntPtr namespaces);*/
            uint pcNameSpaces;
            IntPtr namespaces = default(IntPtr);
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
                result = new GetNamespacesResult(pcNameSpaces, namespaces);
            else
                result = default(GetNamespacesResult);

            return hr;
        }

        #endregion
        #region Initialize

        public void Initialize(object importer, string filename, string searchPath, IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TryInitialize(importer, filename, searchPath, pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitialize(object importer, string filename, string searchPath, IStream pIStream)
        {
            /*HRESULT Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object importer, [In] string filename, [In] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.Initialize(importer, filename, searchPath, pIStream);
        }

        #endregion
        #region UpdateSymbolStore

        public void UpdateSymbolStore(string filename, IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TryUpdateSymbolStore(filename, pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateSymbolStore(string filename, IStream pIStream)
        {
            /*HRESULT UpdateSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.UpdateSymbolStore(filename, pIStream);
        }

        #endregion
        #region ReplaceSymbolStore

        public void ReplaceSymbolStore(string filename, IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TryReplaceSymbolStore(filename, pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryReplaceSymbolStore(string filename, IStream pIStream)
        {
            /*HRESULT ReplaceSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.ReplaceSymbolStore(filename, pIStream);
        }

        #endregion
        #region GetSymbolStoreFileName

        public string GetSymbolStoreFileName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetSymbolStoreFileName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetSymbolStoreFileName(out string szNameResult)
        {
            /*HRESULT GetSymbolStoreFileName(
            [In] uint cchName,
            out uint pcchName,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetSymbolStoreFileName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetSymbolStoreFileName(cchName, out pcchName, szName);

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
        #region GetMethodsFromDocumentPosition

        public GetMethodsFromDocumentPositionResult GetMethodsFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column, uint cMethod)
        {
            HRESULT hr;
            GetMethodsFromDocumentPositionResult result;

            if ((hr = TryGetMethodsFromDocumentPosition(document, line, column, cMethod, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodsFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column, uint cMethod, out GetMethodsFromDocumentPositionResult result)
        {
            /*HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            [Out] out uint pcMethod,
            [Out] IntPtr pRetVal);*/
            uint pcMethod;
            IntPtr pRetVal = default(IntPtr);
            HRESULT hr = Raw.GetMethodsFromDocumentPosition(document, line, column, cMethod, out pcMethod, pRetVal);

            if (hr == HRESULT.S_OK)
                result = new GetMethodsFromDocumentPositionResult(pcMethod, pRetVal);
            else
                result = default(GetMethodsFromDocumentPositionResult);

            return hr;
        }

        #endregion
        #region GetDocumentVersion

        public GetDocumentVersionResult GetDocumentVersion(ISymUnmanagedDocument pDoc)
        {
            HRESULT hr;
            GetDocumentVersionResult result;

            if ((hr = TryGetDocumentVersion(pDoc, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDocumentVersion(ISymUnmanagedDocument pDoc, out GetDocumentVersionResult result)
        {
            /*HRESULT GetDocumentVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc, out int version, out int pbCurrent);*/
            int version;
            int pbCurrent;
            HRESULT hr = Raw.GetDocumentVersion(pDoc, out version, out pbCurrent);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentVersionResult(version, pbCurrent);
            else
                result = default(GetDocumentVersionResult);

            return hr;
        }

        #endregion
        #region GetMethodVersion

        public int GetMethodVersion(ISymUnmanagedMethod pMethod)
        {
            HRESULT hr;
            int version;

            if ((hr = TryGetMethodVersion(pMethod, out version)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return version;
        }

        public HRESULT TryGetMethodVersion(ISymUnmanagedMethod pMethod, out int version)
        {
            /*HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);*/
            return Raw.GetMethodVersion(pMethod, out version);
        }

        #endregion
        #endregion
        #region ISymUnmanagedReader2

        public ISymUnmanagedReader2 Raw2 => (ISymUnmanagedReader2) Raw;

        #region GetMethodByVersionPreRemap

        public ISymUnmanagedMethod GetMethodByVersionPreRemap(uint token, int version)
        {
            HRESULT hr;
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);

            if ((hr = TryGetMethodByVersionPreRemap(token, version, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetMethodByVersionPreRemap(uint token, int version, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodByVersionPreRemap(
            [In] uint token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw2.GetMethodByVersionPreRemap(token, version, pRetVal);
        }

        #endregion
        #region GetSymAttributePreRemap

        public GetSymAttributePreRemapResult GetSymAttributePreRemap(uint parent, string name, uint cBuffer)
        {
            HRESULT hr;
            GetSymAttributePreRemapResult result;

            if ((hr = TryGetSymAttributePreRemap(parent, name, cBuffer, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetSymAttributePreRemap(uint parent, string name, uint cBuffer, out GetSymAttributePreRemapResult result)
        {
            /*HRESULT GetSymAttributePreRemap(
            [In] uint parent,
            [In] string name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);*/
            uint pcBuffer;
            byte[] buffer = null;
            HRESULT hr = Raw2.GetSymAttributePreRemap(parent, name, cBuffer, out pcBuffer, buffer);

            if (hr == HRESULT.S_OK)
                result = new GetSymAttributePreRemapResult(pcBuffer, buffer);
            else
                result = default(GetSymAttributePreRemapResult);

            return hr;
        }

        #endregion
        #region GetMethodsInDocument

        public GetMethodsInDocumentResult GetMethodsInDocument(ISymUnmanagedDocument document, uint cMethod)
        {
            HRESULT hr;
            GetMethodsInDocumentResult result;

            if ((hr = TryGetMethodsInDocument(document, cMethod, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodsInDocument(ISymUnmanagedDocument document, uint cMethod, out GetMethodsInDocumentResult result)
        {
            /*HRESULT GetMethodsInDocument(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pRetVal);*/
            uint pcMethod;
            IntPtr pRetVal = default(IntPtr);
            HRESULT hr = Raw2.GetMethodsInDocument(document, cMethod, out pcMethod, pRetVal);

            if (hr == HRESULT.S_OK)
                result = new GetMethodsInDocumentResult(pcMethod, pRetVal);
            else
                result = default(GetMethodsInDocumentResult);

            return hr;
        }

        #endregion
        #endregion
    }
}