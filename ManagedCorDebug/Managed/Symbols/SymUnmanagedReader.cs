using System;
using System.Diagnostics;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a symbol reader that provides access to documents, methods, and variables within a symbol store.
    /// </summary>
    public class SymUnmanagedReader : ComObject<ISymUnmanagedReader>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedReader"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedReader(ISymUnmanagedReader raw) : base(raw)
        {
        }

        #region ISymUnmanagedReader
        #region Documents

        /// <summary>
        /// Returns an array of all the documents defined in the symbol store.
        /// </summary>
        public ISymUnmanagedDocument[] Documents
        {
            get
            {
                ISymUnmanagedDocument[] pDocsResult;
                TryGetDocuments(out pDocsResult).ThrowOnNotOK();

                return pDocsResult;
            }
        }

        /// <summary>
        /// Returns an array of all the documents defined in the symbol store.
        /// </summary>
        /// <param name="pDocsResult">[out] A pointer to a variable that receives the document array.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetDocuments(out ISymUnmanagedDocument[] pDocsResult)
        {
            /*HRESULT GetDocuments(
            [In] int cDocs,
            [Out] out int pcDocs,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedDocument[] pDocs);*/
            int cDocs = 0;
            int pcDocs;
            ISymUnmanagedDocument[] pDocs = null;
            HRESULT hr = Raw.GetDocuments(cDocs, out pcDocs, pDocs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cDocs = pcDocs;
            pDocs = new ISymUnmanagedDocument[pcDocs];
            hr = Raw.GetDocuments(cDocs, out pcDocs, pDocs);

            if (hr == HRESULT.S_OK)
            {
                pDocsResult = pDocs;

                return hr;
            }

            fail:
            pDocsResult = default(ISymUnmanagedDocument[]);

            return hr;
        }

        #endregion
        #region UserEntryPoint

        /// <summary>
        /// Returns the method that was specified as the user entry point for the module, if any. For example, this method could be the user's main method rather than compiler-generated stubs before the main method.
        /// </summary>
        public mdMethodDef UserEntryPoint
        {
            get
            {
                mdMethodDef pToken;
                TryGetUserEntryPoint(out pToken).ThrowOnNotOK();

                return pToken;
            }
        }

        /// <summary>
        /// Returns the method that was specified as the user entry point for the module, if any. For example, this method could be the user's main method rather than compiler-generated stubs before the main method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a variable that receives the entry point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetUserEntryPoint(out mdMethodDef pToken)
        {
            /*HRESULT GetUserEntryPoint([Out] out mdMethodDef pToken);*/
            return Raw.GetUserEntryPoint(out pToken);
        }

        #endregion
        #region GlobalVariables

        /// <summary>
        /// Returns all global variables.
        /// </summary>
        public ISymUnmanagedVariable[] GlobalVariables
        {
            get
            {
                ISymUnmanagedVariable[] pVarsResult;
                TryGetGlobalVariables(out pVarsResult).ThrowOnNotOK();

                return pVarsResult;
            }
        }

        /// <summary>
        /// Returns all global variables.
        /// </summary>
        /// <param name="pVarsResult">[out] A buffer that contains the variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetGlobalVariables(out ISymUnmanagedVariable[] pVarsResult)
        {
            /*HRESULT GetGlobalVariables(
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);*/
            int cVars = 0;
            int pcVars;
            ISymUnmanagedVariable[] pVars = null;
            HRESULT hr = Raw.GetGlobalVariables(cVars, out pcVars, pVars);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cVars = pcVars;
            pVars = new ISymUnmanagedVariable[pcVars];
            hr = Raw.GetGlobalVariables(cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
            {
                pVarsResult = pVars;

                return hr;
            }

            fail:
            pVarsResult = default(ISymUnmanagedVariable[]);

            return hr;
        }

        #endregion
        #region Namespaces

        /// <summary>
        /// Gets the namespaces defined at global scope within this symbol store.
        /// </summary>
        public ISymUnmanagedNamespace[] Namespaces
        {
            get
            {
                ISymUnmanagedNamespace[] namespacesResult;
                TryGetNamespaces(out namespacesResult).ThrowOnNotOK();

                return namespacesResult;
            }
        }

        /// <summary>
        /// Gets the namespaces defined at global scope within this symbol store.
        /// </summary>
        /// <param name="namespacesResult">[out] A pointer to a variable that receives the namespace list.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespaces(out ISymUnmanagedNamespace[] namespacesResult)
        {
            /*HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedNamespace[] namespaces);*/
            int cNameSpaces = 0;
            int pcNameSpaces;
            ISymUnmanagedNamespace[] namespaces = null;
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNameSpaces = pcNameSpaces;
            namespaces = new ISymUnmanagedNamespace[pcNameSpaces];
            hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
            {
                namespacesResult = namespaces;

                return hr;
            }

            fail:
            namespacesResult = default(ISymUnmanagedNamespace[]);

            return hr;
        }

        #endregion
        #region SymbolStoreFileName

        /// <summary>
        /// Provides the on-disk file name of the symbol store.
        /// </summary>
        public string SymbolStoreFileName
        {
            get
            {
                string szNameResult;
                TryGetSymbolStoreFileName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Provides the on-disk file name of the symbol store.
        /// </summary>
        /// <param name="szNameResult">[out] A pointer to the variable that receives the file name of the symbol store.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSymbolStoreFileName(out string szNameResult)
        {
            /*HRESULT GetSymbolStoreFileName(
            [In] int cchName,
            [Out] out int pcchName,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetSymbolStoreFileName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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
        #region GetDocument

        /// <summary>
        /// Finds a document. The document language, vendor, and type are optional.
        /// </summary>
        /// <param name="url">[in] The URL that identifies the document.</param>
        /// <param name="language">[in] The document language. This parameter is optional.</param>
        /// <param name="languageVendor">[in] The identity of the vendor for the document language. This parameter is optional.</param>
        /// <param name="documentType">[in] The type of the document. This parameter is optional.</param>
        /// <returns>[out] A pointer to the returned interface.</returns>
        public SymUnmanagedDocument GetDocument(string url, Guid language, Guid languageVendor, Guid documentType)
        {
            SymUnmanagedDocument pRetValResult;
            TryGetDocument(url, language, languageVendor, documentType, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Finds a document. The document language, vendor, and type are optional.
        /// </summary>
        /// <param name="url">[in] The URL that identifies the document.</param>
        /// <param name="language">[in] The document language. This parameter is optional.</param>
        /// <param name="languageVendor">[in] The identity of the vendor for the document language. This parameter is optional.</param>
        /// <param name="documentType">[in] The type of the document. This parameter is optional.</param>
        /// <param name="pRetValResult">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetDocument(string url, Guid language, Guid languageVendor, Guid documentType, out SymUnmanagedDocument pRetValResult)
        {
            /*HRESULT GetDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType,
            [Out] out ISymUnmanagedDocument pRetVal);*/
            ISymUnmanagedDocument pRetVal;
            HRESULT hr = Raw.GetDocument(url, ref language, ref languageVendor, ref documentType, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedDocument(pRetVal);
            else
                pRetValResult = default(SymUnmanagedDocument);

            return hr;
        }

        #endregion
        #region GetMethod

        /// <summary>
        /// Gets a symbol reader method, given a method token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <returns>[out] A pointer to the returned interface.</returns>
        public ISymUnmanagedMethod GetMethod(mdMethodDef token)
        {
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);
            TryGetMethod(token, ref pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Gets a symbol reader method, given a method token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethod(mdMethodDef token, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethod([In] mdMethodDef token, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethod(token, pRetVal);
        }

        #endregion
        #region GetMethodByVersion

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-copy version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-copy operation.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <returns>[out] A pointer to the returned interface.</returns>
        public ISymUnmanagedMethod GetMethodByVersion(mdMethodDef token, int version)
        {
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);
            TryGetMethodByVersion(token, version, ref pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-copy version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-copy operation.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodByVersion(mdMethodDef token, int version, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodByVersion(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethodByVersion(token, version, pRetVal);
        }

        #endregion
        #region GetVariables

        /// <summary>
        /// Returns a non-local variable, given its parent and name.
        /// </summary>
        /// <param name="parent">[in] The parent of the variable.</param>
        /// <returns>[out] A pointer to the variable that receives the variables.</returns>
        public ISymUnmanagedVariable[] GetVariables(int parent)
        {
            ISymUnmanagedVariable[] pVarsResult;
            TryGetVariables(parent, out pVarsResult).ThrowOnNotOK();

            return pVarsResult;
        }

        /// <summary>
        /// Returns a non-local variable, given its parent and name.
        /// </summary>
        /// <param name="parent">[in] The parent of the variable.</param>
        /// <param name="pVarsResult">[out] A pointer to the variable that receives the variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetVariables(int parent, out ISymUnmanagedVariable[] pVarsResult)
        {
            /*HRESULT GetVariables(
            [In] int parent,
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);*/
            int cVars = 0;
            int pcVars;
            ISymUnmanagedVariable[] pVars = null;
            HRESULT hr = Raw.GetVariables(parent, cVars, out pcVars, pVars);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cVars = pcVars;
            pVars = new ISymUnmanagedVariable[pcVars];
            hr = Raw.GetVariables(parent, cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
            {
                pVarsResult = pVars;

                return hr;
            }

            fail:
            pVarsResult = default(ISymUnmanagedVariable[]);

            return hr;
        }

        #endregion
        #region GetMethodFromDocumentPosition

        /// <summary>
        /// Returns the method that contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <returns>[out] A pointer to the address of a <see cref="ISymUnmanagedMethod"/> object that represents the method containing the breakpoint.</returns>
        public ISymUnmanagedMethod GetMethodFromDocumentPosition(ISymUnmanagedDocument document, int line, int column)
        {
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);
            TryGetMethodFromDocumentPosition(document, line, column, ref pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Returns the method that contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <param name="pRetVal">[out] A pointer to the address of a <see cref="ISymUnmanagedMethod"/> object that represents the method containing the breakpoint.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethodFromDocumentPosition(document, line, column, pRetVal);
        }

        #endregion
        #region GetSymAttribute

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these custom attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token for the object for which the attribute is requested.</param>
        /// <param name="name">[in] A pointer to the variable that indicates the attribute to retrieve.</param>
        /// <param name="cBuffer">[in] The size of the buffer array.</param>
        /// <param name="buffer">[out] A pointer to the variable that receives the attribute data.</param>
        /// <returns>[out] A pointer to the variable that receives the length of the attribute data.</returns>
        public int GetSymAttribute(int parent, string name, int cBuffer, IntPtr buffer)
        {
            int pcBuffer;
            TryGetSymAttribute(parent, name, cBuffer, out pcBuffer, buffer).ThrowOnNotOK();

            return pcBuffer;
        }

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these custom attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token for the object for which the attribute is requested.</param>
        /// <param name="name">[in] A pointer to the variable that indicates the attribute to retrieve.</param>
        /// <param name="cBuffer">[in] The size of the buffer array.</param>
        /// <param name="pcBuffer">[out] A pointer to the variable that receives the length of the attribute data.</param>
        /// <param name="buffer">[out] A pointer to the variable that receives the attribute data.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSymAttribute(int parent, string name, int cBuffer, out int pcBuffer, IntPtr buffer)
        {
            /*HRESULT GetSymAttribute(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);*/
            return Raw.GetSymAttribute(parent, name, cBuffer, out pcBuffer, buffer);
        }

        #endregion
        #region Initialize

        /// <summary>
        /// Initializes the symbol reader with the metadata importer interface that this reader will be associated with, along with the file name of the module.
        /// </summary>
        /// <param name="importer">[in] The metadata importer interface with which this reader will be associated.</param>
        /// <param name="filename">[in] The file name of the module. You can use the pIStream parameter instead.</param>
        /// <param name="searchPath">[in] The path to search. This parameter is optional.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <remarks>
        /// You need to specify only one of the filename or the pIStream parameters, not both. The searchPath parameter is
        /// optional.
        /// </remarks>
        public void Initialize(object importer, string filename, string searchPath, IStream pIStream)
        {
            TryInitialize(importer, filename, searchPath, pIStream).ThrowOnNotOK();
        }

        /// <summary>
        /// Initializes the symbol reader with the metadata importer interface that this reader will be associated with, along with the file name of the module.
        /// </summary>
        /// <param name="importer">[in] The metadata importer interface with which this reader will be associated.</param>
        /// <param name="filename">[in] The file name of the module. You can use the pIStream parameter instead.</param>
        /// <param name="searchPath">[in] The path to search. This parameter is optional.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// You need to specify only one of the filename or the pIStream parameters, not both. The searchPath parameter is
        /// optional.
        /// </remarks>
        public HRESULT TryInitialize(object importer, string filename, string searchPath, IStream pIStream)
        {
            /*HRESULT Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In] object importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);*/
            return Raw.Initialize(importer, filename, searchPath, pIStream);
        }

        #endregion
        #region UpdateSymbolStore

        /// <summary>
        /// Updates the existing symbol store with a delta symbol store. This method is used in edit-and-continue scenarios to update the symbol store to match deltas to the original portable executable (PE) file.
        /// </summary>
        /// <param name="filename">[in] The name of the file that contains the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        public void UpdateSymbolStore(string filename, IStream pIStream)
        {
            TryUpdateSymbolStore(filename, pIStream).ThrowOnNotOK();
        }

        /// <summary>
        /// Updates the existing symbol store with a delta symbol store. This method is used in edit-and-continue scenarios to update the symbol store to match deltas to the original portable executable (PE) file.
        /// </summary>
        /// <param name="filename">[in] The name of the file that contains the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryUpdateSymbolStore(string filename, IStream pIStream)
        {
            /*HRESULT UpdateSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.UpdateSymbolStore(filename, pIStream);
        }

        #endregion
        #region ReplaceSymbolStore

        /// <summary>
        /// Replaces the existing symbol store with a delta symbol store. This method is similar to the <see cref="UpdateSymbolStore"/> method, except that the given delta acts as a complete replacement rather than an update.
        /// </summary>
        /// <param name="filename">[in] The name of the file containing the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        public void ReplaceSymbolStore(string filename, IStream pIStream)
        {
            TryReplaceSymbolStore(filename, pIStream).ThrowOnNotOK();
        }

        /// <summary>
        /// Replaces the existing symbol store with a delta symbol store. This method is similar to the <see cref="UpdateSymbolStore"/> method, except that the given delta acts as a complete replacement rather than an update.
        /// </summary>
        /// <param name="filename">[in] The name of the file containing the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryReplaceSymbolStore(string filename, IStream pIStream)
        {
            /*HRESULT ReplaceSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.ReplaceSymbolStore(filename, pIStream);
        }

        #endregion
        #region GetMethodsFromDocumentPosition

        /// <summary>
        /// Returns an array of methods, each of which contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <returns>[out] An array of pointers, each of which points to an <see cref="ISymUnmanagedMethod"/> object that represents a method containing the breakpoint.</returns>
        public ISymUnmanagedMethod[] GetMethodsFromDocumentPosition(ISymUnmanagedDocument document, int line, int column)
        {
            ISymUnmanagedMethod[] pRetValResult;
            TryGetMethodsFromDocumentPosition(document, line, column, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Returns an array of methods, each of which contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <param name="pRetValResult">[out] An array of pointers, each of which points to an <see cref="ISymUnmanagedMethod"/> object that represents a method containing the breakpoint.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodsFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, out ISymUnmanagedMethod[] pRetValResult)
        {
            /*HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cMethod,
            [Out] out int pcMethod,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedMethod[] pRetVal);*/
            int cMethod = 0;
            int pcMethod;
            ISymUnmanagedMethod[] pRetVal = null;
            HRESULT hr = Raw.GetMethodsFromDocumentPosition(document, line, column, cMethod, out pcMethod, pRetVal);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMethod = pcMethod;
            pRetVal = new ISymUnmanagedMethod[pcMethod];
            hr = Raw.GetMethodsFromDocumentPosition(document, line, column, cMethod, out pcMethod, pRetVal);

            if (hr == HRESULT.S_OK)
            {
                pRetValResult = pRetVal;

                return hr;
            }

            fail:
            pRetValResult = default(ISymUnmanagedMethod[]);

            return hr;
        }

        #endregion
        #region GetDocumentVersion

        /// <summary>
        /// Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the <see cref="UpdateSymbolStore"/> method.<para/>
        /// If the pbCurrent parameter is true, this is the latest version of the document.
        /// </summary>
        /// <param name="pDoc">[in] The specified document.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentVersionResult GetDocumentVersion(ISymUnmanagedDocument pDoc)
        {
            GetDocumentVersionResult result;
            TryGetDocumentVersion(pDoc, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the <see cref="UpdateSymbolStore"/> method.<para/>
        /// If the pbCurrent parameter is true, this is the latest version of the document.
        /// </summary>
        /// <param name="pDoc">[in] The specified document.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetDocumentVersion(ISymUnmanagedDocument pDoc, out GetDocumentVersionResult result)
        {
            /*HRESULT GetDocumentVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc, [Out] out int version, [Out] out bool pbCurrent);*/
            int version;
            bool pbCurrent;
            HRESULT hr = Raw.GetDocumentVersion(pDoc, out version, out pbCurrent);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentVersionResult(version, pbCurrent);
            else
                result = default(GetDocumentVersionResult);

            return hr;
        }

        #endregion
        #region GetMethodVersion

        /// <summary>
        /// Gets the method version. The method version starts at 1 and is incremented each time the method is recompiled. Recompilation can happen without changes to the method.
        /// </summary>
        /// <param name="pMethod">[in] The method for which to get the version.</param>
        /// <returns>[out] A pointer to a variable that receives the method version.</returns>
        public int GetMethodVersion(ISymUnmanagedMethod pMethod)
        {
            int version;
            TryGetMethodVersion(pMethod, out version).ThrowOnNotOK();

            return version;
        }

        /// <summary>
        /// Gets the method version. The method version starts at 1 and is incremented each time the method is recompiled. Recompilation can happen without changes to the method.
        /// </summary>
        /// <param name="pMethod">[in] The method for which to get the version.</param>
        /// <param name="version">[out] A pointer to a variable that receives the method version.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodVersion(ISymUnmanagedMethod pMethod, out int version)
        {
            /*HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, [Out] out int version);*/
            return Raw.GetMethodVersion(pMethod, out version);
        }

        #endregion
        #endregion
        #region ISymUnmanagedReader2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedReader2 Raw2 => (ISymUnmanagedReader2) Raw;

        #region GetMethodByVersionPreRemap

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-continue version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-continue operation.
        /// </summary>
        /// <param name="token">[in] The method metadata token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <returns>[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</returns>
        public ISymUnmanagedMethod GetMethodByVersionPreRemap(mdMethodDef token, int version)
        {
            ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);
            TryGetMethodByVersionPreRemap(token, version, ref pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-continue version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-continue operation.
        /// </summary>
        /// <param name="token">[in] The method metadata token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodByVersionPreRemap(mdMethodDef token, int version, ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethodByVersionPreRemap(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw2.GetMethodByVersionPreRemap(token, version, pRetVal);
        }

        #endregion
        #region GetSymAttributePreRemap

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token of the parent.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the name.</param>
        /// <param name="cBuffer">[in] A ULONG32 that indicates the size of the buffer array.</param>
        /// <param name="buffer">[out] A pointer to the buffer that receives the attribute bytes.</param>
        /// <returns>[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the attribute bytes.</returns>
        public int GetSymAttributePreRemap(int parent, string name, int cBuffer, IntPtr buffer)
        {
            int pcBuffer;
            TryGetSymAttributePreRemap(parent, name, cBuffer, out pcBuffer, buffer).ThrowOnNotOK();

            return pcBuffer;
        }

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token of the parent.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the name.</param>
        /// <param name="cBuffer">[in] A ULONG32 that indicates the size of the buffer array.</param>
        /// <param name="pcBuffer">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the attribute bytes.</param>
        /// <param name="buffer">[out] A pointer to the buffer that receives the attribute bytes.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSymAttributePreRemap(int parent, string name, int cBuffer, out int pcBuffer, IntPtr buffer)
        {
            /*HRESULT GetSymAttributePreRemap(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);*/
            return Raw2.GetSymAttributePreRemap(parent, name, cBuffer, out pcBuffer, buffer);
        }

        #endregion
        #region GetMethodsInDocument

        /// <summary>
        /// Gets every method that has line information in the provided document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <returns>[out] A pointer to the buffer that receives the methods.</returns>
        public ISymUnmanagedMethod[] GetMethodsInDocument(ISymUnmanagedDocument document)
        {
            ISymUnmanagedMethod[] pRetValResult;
            TryGetMethodsInDocument(document, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Gets every method that has line information in the provided document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <param name="pRetValResult">[out] A pointer to the buffer that receives the methods.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethodsInDocument(ISymUnmanagedDocument document, out ISymUnmanagedMethod[] pRetValResult)
        {
            /*HRESULT GetMethodsInDocument(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int cMethod,
            [Out] out int pcMethod,
            [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedMethod[] pRetVal);*/
            int cMethod = 0;
            int pcMethod;
            ISymUnmanagedMethod[] pRetVal = null;
            HRESULT hr = Raw2.GetMethodsInDocument(document, cMethod, out pcMethod, pRetVal);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMethod = pcMethod;
            pRetVal = new ISymUnmanagedMethod[pcMethod];
            hr = Raw2.GetMethodsInDocument(document, cMethod, out pcMethod, pRetVal);

            if (hr == HRESULT.S_OK)
            {
                pRetValResult = pRetVal;

                return hr;
            }

            fail:
            pRetValResult = default(ISymUnmanagedMethod[]);

            return hr;
        }

        #endregion
        #endregion
    }
}