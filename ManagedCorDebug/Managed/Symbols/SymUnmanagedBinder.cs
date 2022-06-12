using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a symbol binder for unmanaged code.
    /// </summary>
    public class SymUnmanagedBinder : ComObject<ISymUnmanagedBinder>
    {
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
            HRESULT hr;
            SymUnmanagedReader pRetValResult;

            if ((hr = TryGetReaderForFile(importer, fileName, searchPath, out pRetValResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [In] string fileName,
            [In] string searchPath,
            [Out] out ISymUnmanagedReader pRetVal);*/
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
        public ISymUnmanagedReader GetReaderFromStream(IMetaDataImport importer, IStream pstream)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderFromStream(importer, pstream, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Given a metadata interface and a stream that contains the symbol store, returns the correct <see cref="ISymUnmanagedReader"/> structure that will read the debugging symbols from the given symbol store.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="pstream">[in] A pointer to the stream that contains the symbol store.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetReaderFromStream(IMetaDataImport importer, IStream pstream, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out] ISymUnmanagedReader pRetVal);*/
            return Raw.GetReaderFromStream(importer, pstream, pRetVal);
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
        public ISymUnmanagedReader GetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderForFile2(importer, fileName, searchPath, searchPolicy, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method provides a more extensive search for the program database (PDB) file than the <see cref="GetReaderForFile"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// This version of the method can search for the PDB file in areas other than right next to the module. The search
        /// policy can be controlled by combining <see cref="CorSymSearchPolicyAttributes"/>. For example, AllowReferencePathAccess
        /// | AllowSymbolServerAccess looks for the PDB next to the executable file and on a symbol server, but does not query
        /// the registry or use the path in the executable file. If the searchPath parameter is provided, those directories
        /// will always be searched.
        /// </remarks>
        public HRESULT TryGetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderForFile2(
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [In] string fileName,
            [In] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [Out] ISymUnmanagedReader pRetVal);*/
            return Raw2.GetReaderForFile2(importer, fileName, searchPath, searchPolicy, pRetVal);
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
        public ISymUnmanagedReader GetReaderFromCallback(object importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Allows the user to implement or supply via callback either an IID_IDiaReadExeAtRVACallback or IID_IDiaReadExeAtOffsetCallback to obtain the debug directory information from memory.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="searchPolicy">[in] A value of the <see cref="CorSymSearchPolicyAttributes"/> enumeration that specifies the policy to be used when doing a search for a symbol reader.</param>
        /// <param name="callback">[in] A pointer to the callback function.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetReaderFromCallback(object importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderFromCallback(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] string fileName,
            [In] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [MarshalAs(UnmanagedType.IUnknown), In] object callback,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedReader pRetVal);*/
            return Raw3.GetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, pRetVal);
        }

        #endregion
        #endregion
    }
}