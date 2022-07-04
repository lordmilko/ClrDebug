using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents a symbol binder for unmanaged code.
    /// </summary>
    public class SymUnmanagedBinder : ComObject<ISymUnmanagedBinder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedBinder"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedBinder(ISymUnmanagedBinder raw) : base(raw)
        {
        }

        #region ISymUnmanagedBinder
        #region GetReaderForFile

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method will open the program database (PDB) file only if it is next to the executable file. This change has been made for security purposes.<para/>
        /// If you need a more extensive search for the PDB file, use the <see cref="GetReaderForFile2"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</returns>
        public SymUnmanagedReader GetReaderForFile(IMetaDataImport importer, string fileName, string searchPath)
        {
            SymUnmanagedReader pRetValResult;
            TryGetReaderForFile(importer, fileName, searchPath, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method will open the program database (PDB) file only if it is next to the executable file. This change has been made for security purposes.<para/>
        /// If you need a more extensive search for the PDB file, use the <see cref="GetReaderForFile2"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetReaderForFile(IMetaDataImport importer, string fileName, string searchPath, out SymUnmanagedReader pRetValResult)
        {
            /*HRESULT GetReaderForFile(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);*/
            ISymUnmanagedReader pRetVal;
            HRESULT hr = Raw.GetReaderForFile(importer, fileName, searchPath, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedReader(pRetVal);
            else
                pRetValResult = default(SymUnmanagedReader);

            return hr;
        }

        #endregion
        #region GetReaderFromStream

        /// <summary>
        /// Given a metadata interface and a stream that contains the symbol store, returns the correct <see cref="ISymUnmanagedReader"/> structure that will read the debugging symbols from the given symbol store.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="pstream">[in] A pointer to the stream that contains the symbol store.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</returns>
        public SymUnmanagedReader GetReaderFromStream(IMetaDataImport importer, IStream pstream)
        {
            SymUnmanagedReader pRetValResult;
            TryGetReaderFromStream(importer, pstream, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Given a metadata interface and a stream that contains the symbol store, returns the correct <see cref="ISymUnmanagedReader"/> structure that will read the debugging symbols from the given symbol store.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="pstream">[in] A pointer to the stream that contains the symbol store.</param>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetReaderFromStream(IMetaDataImport importer, IStream pstream, out SymUnmanagedReader pRetValResult)
        {
            /*HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);*/
            ISymUnmanagedReader pRetVal;
            HRESULT hr = Raw.GetReaderFromStream(importer, pstream, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedReader(pRetVal);
            else
                pRetValResult = default(SymUnmanagedReader);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedBinder2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedBinder2 Raw2 => (ISymUnmanagedBinder2) Raw;

        #region GetReaderForFile2

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method provides a more extensive search for the program database (PDB) file than the <see cref="GetReaderForFile"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</returns>
        /// <remarks>
        /// This version of the method can search for the PDB file in areas other than right next to the module. The search
        /// policy can be controlled by combining <see cref="CorSymSearchPolicyAttributes"/>. For example, AllowReferencePathAccess
        /// | AllowSymbolServerAccess looks for the PDB next to the executable file and on a symbol server, but does not query
        /// the registry or use the path in the executable file. If the searchPath parameter is provided, those directories
        /// will always be searched.
        /// </remarks>
        public SymUnmanagedReader GetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy)
        {
            SymUnmanagedReader pRetValResult;
            TryGetReaderForFile2(importer, fileName, searchPath, searchPolicy, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method provides a more extensive search for the program database (PDB) file than the <see cref="GetReaderForFile"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// This version of the method can search for the PDB file in areas other than right next to the module. The search
        /// policy can be controlled by combining <see cref="CorSymSearchPolicyAttributes"/>. For example, AllowReferencePathAccess
        /// | AllowSymbolServerAccess looks for the PDB next to the executable file and on a symbol server, but does not query
        /// the registry or use the path in the executable file. If the searchPath parameter is provided, those directories
        /// will always be searched.
        /// </remarks>
        public HRESULT TryGetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, out SymUnmanagedReader pRetValResult)
        {
            /*HRESULT GetReaderForFile2(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);*/
            ISymUnmanagedReader pRetVal;
            HRESULT hr = Raw2.GetReaderForFile2(importer, fileName, searchPath, searchPolicy, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedReader(pRetVal);
            else
                pRetValResult = default(SymUnmanagedReader);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedBinder3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedBinder3 Raw3 => (ISymUnmanagedBinder3) Raw;

        #region GetReaderFromCallback

        /// <summary>
        /// Allows the user to implement or supply via callback either an IID_IDiaReadExeAtRVACallback or IID_IDiaReadExeAtOffsetCallback to obtain the debug directory information from memory.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <param name="callback">[in] A pointer to the callback function.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</returns>
        public SymUnmanagedReader GetReaderFromCallback(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback)
        {
            SymUnmanagedReader pRetValResult;
            TryGetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Allows the user to implement or supply via callback either an IID_IDiaReadExeAtRVACallback or IID_IDiaReadExeAtOffsetCallback to obtain the debug directory information from memory.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <param name="callback">[in] A pointer to the callback function.</param>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetReaderFromCallback(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback, out SymUnmanagedReader pRetValResult)
        {
            /*HRESULT GetReaderFromCallback(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [MarshalAs(UnmanagedType.IUnknown), In] object callback,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);*/
            ISymUnmanagedReader pRetVal;
            HRESULT hr = Raw3.GetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedReader(pRetVal);
            else
                pRetValResult = default(SymUnmanagedReader);

            return hr;
        }

        #endregion
        #endregion
    }
}
