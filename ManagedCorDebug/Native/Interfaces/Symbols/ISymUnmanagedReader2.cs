using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a symbol reader that provides access to documents, methods, and variables within a symbol store. This interface extends the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    [Guid("A09E53B2-2A57-4CCA-8F63-B84F7C35D4AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedReader2 : ISymUnmanagedReader
    {
        /// <summary>
        /// Finds a document. The document language, vendor, and type are optional.
        /// </summary>
        /// <param name="url">[in] The URL that identifies the document.</param>
        /// <param name="language">[in] The document language. This parameter is optional.</param>
        /// <param name="languageVendor">[in] The identity of the vendor for the document language. This parameter is optional.</param>
        /// <param name="documentType">[in] The type of the document. This parameter is optional.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetDocument(
            [In] string url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType,
            [Out] out ISymUnmanagedDocument pRetVal);

        /// <summary>
        /// Returns an array of all the documents defined in the symbol store.
        /// </summary>
        /// <param name="cDocs">[in] The size of the pDocs array.</param>
        /// <param name="pcDocs">[out] A pointer to a variable that receives the array length.</param>
        /// <param name="pDocs">[out] A pointer to a variable that receives the document array.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetDocuments([In] uint cDocs, out uint pcDocs, [Out] IntPtr pDocs);

        /// <summary>
        /// Returns the method that was specified as the user entry point for the module, if any. For example, this method could be the user's main method rather than compiler-generated stubs before the main method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a variable that receives the entry point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetUserEntryPoint([Out] out uint pToken);

        /// <summary>
        /// Gets a symbol reader method, given a method token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMethod([In] uint token, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-copy version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-copy operation.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMethodByVersion([In] uint token, [In] int version, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetVariables(
            [In] uint parent,
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars); //ISymUnmanagedVariable

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetGlobalVariables(
            [In] uint cVars,
            out uint pcVars,
            [Out] IntPtr pVars); //ISymUnmanagedVariable

        /// <summary>
        /// Returns the method that contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <param name="pRetVal">[out] A pointer to the address of a <see cref="ISymUnmanagedMethod"/> object that represents the method containing the breakpoint.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetSymAttribute(
            [In] uint parent,
            [In] string name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetNamespaces(
            [In] uint cNameSpaces,
            out uint pcNameSpaces,
            [Out] IntPtr namespaces); //ISymUnmanagedNamespace

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] string filename,
            [In] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        /// <summary>
        /// Updates the existing symbol store with a delta symbol store. This method is used in edit-and-continue scenarios to update the symbol store to match deltas to the original portable executable (PE) file.
        /// </summary>
        /// <param name="filename">[in] The name of the file that contains the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT UpdateSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        /// <summary>
        /// Replaces the existing symbol store with a delta symbol store. This method is similar to the <see cref="UpdateSymbolStore"/> method, except that the given delta acts as a complete replacement rather than an update.
        /// </summary>
        /// <param name="filename">[in] The name of the file containing the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT ReplaceSymbolStore([In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetSymbolStoreFileName(
            [In] uint cchName,
            out uint pcchName,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            [Out] out uint pcMethod,
            [Out] IntPtr pRetVal); //ISymUnmanagedMethod

        /// <summary>
        /// Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the <see cref="UpdateSymbolStore"/> method.<para/>
        /// If the pbCurrent parameter is true, this is the latest version of the document.
        /// </summary>
        /// <param name="pDoc">[in] The specified document.</param>
        /// <param name="version">[out] A pointer to a variable that receives the version of the specified document.</param>
        /// <param name="pbCurrent">[out] A pointer to a variable that receives true if this is the latest version of the document, or false if it isn't the latest version.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetDocumentVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc, out int version, out int pbCurrent);

        /// <summary>
        /// Gets the method version. The method version starts at 1 and is incremented each time the method is recompiled. Recompilation can happen without changes to the method.
        /// </summary>
        /// <param name="pMethod">[in] The method for which to get the version.</param>
        /// <param name="version">[out] A pointer to a variable that receives the method version.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-continue version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-continue operation.
        /// </summary>
        /// <param name="token">[in] The method metadata token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodByVersionPreRemap(
            [In] uint token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token of the parent.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the name.</param>
        /// <param name="cBuffer">[in] A ULONG32 that indicates the size of the buffer array.</param>
        /// <param name="pcBuffer">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the attribute bytes.</param>
        /// <param name="buffer">[out] A pointer to the buffer that receives the attribute bytes.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymAttributePreRemap(
            [In] uint parent,
            [In] string name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer);

        /// <summary>
        /// Gets every method that has line information in the provided document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <param name="cMethod">[in] A ULONG32 that indicates the size of the pRetVal array.</param>
        /// <param name="pcMethod">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the methods.</param>
        /// <param name="pRetVal">[out] A pointer to the buffer that receives the methods.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodsInDocument(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pRetVal); //ISymUnmanagedMethod
    }
}