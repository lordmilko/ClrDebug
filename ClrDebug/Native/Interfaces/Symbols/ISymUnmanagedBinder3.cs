using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the symbol binder interface. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedBinder"/> interface.
    /// </summary>
    [Guid("28AD3D43-B601-4D26-8A1B-25F9165AF9D7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedBinder3 : ISymUnmanagedBinder2
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method will open the program database (PDB) file only if it is next to the executable file. This change has been made for security purposes.<para/>
        /// If you need a more extensive search for the PDB file, use the <see cref="ISymUnmanagedBinder2.GetReaderForFile2"/> method.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="fileName">[in] A pointer to the file name.</param>
        /// <param name="searchPath">[in] A pointer to the search path.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetReaderForFile(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);

        /// <summary>
        /// Given a metadata interface and a stream that contains the symbol store, returns the correct <see cref="ISymUnmanagedReader"/> structure that will read the debugging symbols from the given symbol store.
        /// </summary>
        /// <param name="importer">[in] A pointer to the metadata import interface.</param>
        /// <param name="pstream">[in] A pointer to the stream that contains the symbol store.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedReader"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);

        /// <summary>
        /// Given a metadata interface and a file name, returns the correct <see cref="ISymUnmanagedReader"/> interface that will read the debugging symbols associated with the module.<para/>
        /// This method provides a more extensive search for the program database (PDB) file than the <see cref="ISymUnmanagedBinder.GetReaderForFile"/> method.
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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetReaderForFile2(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);
#endif

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReaderFromCallback(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [MarshalAs(UnmanagedType.Interface), In] object callback,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);
    }
}
