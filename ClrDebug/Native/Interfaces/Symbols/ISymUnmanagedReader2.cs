﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a symbol reader that provides access to documents, methods, and variables within a symbol store. This interface extends the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    [Guid("A09E53B2-2A57-4CCA-8F63-B84F7C35D4AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedReader2 : ISymUnmanagedReader
    {
#if !GENERATED_MARSHALLING
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
        new HRESULT GetDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid language,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid languageVendor,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid documentType,
#else
            [MarshalUsing(typeof(GuidMarshaller))] in Guid language,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid languageVendor,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid documentType,
#endif
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocument pRetVal);

        /// <summary>
        /// Returns an array of all the documents defined in the symbol store.
        /// </summary>
        /// <param name="cDocs">[in] The size of the pDocs array.</param>
        /// <param name="pcDocs">[out] A pointer to a variable that receives the array length.</param>
        /// <param name="pDocs">[out] A pointer to a variable that receives the document array.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetDocuments(
            [In] int cDocs,
            [Out] out int pcDocs,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] pDocs);

        /// <summary>
        /// Returns the method that was specified as the user entry point for the module, if any. For example, this method could be the user's main method rather than compiler-generated stubs before the main method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a variable that receives the entry point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetUserEntryPoint(
            [Out] out mdMethodDef pToken);

        /// <summary>
        /// Gets a symbol reader method, given a method token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethod(
            [In] mdMethodDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-copy version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-copy operation.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethodByVersion(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Returns a non-local variable, given its parent and name.
        /// </summary>
        /// <param name="parent">[in] The parent of the variable.</param>
        /// <param name="cVars">[in] The size of the pVars array.</param>
        /// <param name="pcVars">[out] A pointer to the variable that receives the number of variables returned in pVars.</param>
        /// <param name="pVars">[out] A pointer to the variable that receives the variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetVariables(
            [In] int parent,
            [In] int cVars,
            [Out] out int pcVars,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedVariable[] pVars);

        /// <summary>
        /// Returns all global variables.
        /// </summary>
        /// <param name="cVars">[in] The length of the buffer pointed to by pcVars.</param>
        /// <param name="pcVars">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the variables.</param>
        /// <param name="pVars">[out] A buffer that contains the variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetGlobalVariables(
            [In] int cVars,
            [Out] out int pcVars,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] pVars);

        /// <summary>
        /// Returns the method that contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <param name="pRetVal">[out] A pointer to the address of a <see cref="ISymUnmanagedMethod"/> object that represents the method containing the breakpoint.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        /// <summary>
        /// Gets a custom attribute based upon its name. Unlike metadata custom attributes, these custom attributes are held in the symbol store.
        /// </summary>
        /// <param name="parent">[in] The metadata token for the object for which the attribute is requested.</param>
        /// <param name="name">[in] A pointer to the variable that indicates the attribute to retrieve.</param>
        /// <param name="cBuffer">[in] The size of the buffer array.</param>
        /// <param name="pcBuffer">[out] A pointer to the variable that receives the length of the attribute data.</param>
        /// <param name="buffer">[out] A pointer to the variable that receives the attribute data.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetSymAttribute(
            [In] mdToken parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);

        /// <summary>
        /// Gets the namespaces defined at global scope within this symbol store.
        /// </summary>
        /// <param name="cNameSpaces">[in] The size of the namespaces array.</param>
        /// <param name="pcNameSpaces">[out] A pointer to a variable that receives the length of the namespace list.</param>
        /// <param name="namespaces">[out] A pointer to a variable that receives the namespace list.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces);

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
        new HRESULT Initialize(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        /// <summary>
        /// Updates the existing symbol store with a delta symbol store. This method is used in edit-and-continue scenarios to update the symbol store to match deltas to the original portable executable (PE) file.
        /// </summary>
        /// <param name="filename">[in] The name of the file that contains the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT UpdateSymbolStore(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        /// <summary>
        /// Replaces the existing symbol store with a delta symbol store. This method is similar to the <see cref="UpdateSymbolStore"/> method, except that the given delta acts as a complete replacement rather than an update.
        /// </summary>
        /// <param name="filename">[in] The name of the file containing the symbol store.</param>
        /// <param name="pIStream">[in] The file stream, used as an alternative to the filename parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT ReplaceSymbolStore(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        /// <summary>
        /// Provides the on-disk file name of the symbol store.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the variable that receives the length of the name returned in szName, including the null termination.</param>
        /// <param name="szName">[out] A pointer to the variable that receives the file name of the symbol store.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetSymbolStoreFileName(
            [In] int cchName,
            [Out] out int pcchName,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0), SRI.Out] char[] szName);

        /// <summary>
        /// Returns an array of methods, each of which contains the breakpoint at the given position in a document.
        /// </summary>
        /// <param name="document">[in] The specified document.</param>
        /// <param name="line">[in] The line of the specified document.</param>
        /// <param name="column">[in] The column of the specified document.</param>
        /// <param name="cMethod">[in] The size of the pRetVal array.</param>
        /// <param name="pcMethod">[out] A pointer to a variable that receives the number of elements returned in the pRetVal array.</param>
        /// <param name="pRetVal">[out] An array of pointers, each of which points to an <see cref="ISymUnmanagedMethod"/> object that represents a method containing the breakpoint.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cMethod,
            [Out] out int pcMethod,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ISymUnmanagedMethod[] pRetVal);

        /// <summary>
        /// Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the <see cref="UpdateSymbolStore"/> method.<para/>
        /// If the pbCurrent parameter is true, this is the latest version of the document.
        /// </summary>
        /// <param name="pDoc">[in] The specified document.</param>
        /// <param name="version">[out] A pointer to a variable that receives the version of the specified document.</param>
        /// <param name="pbCurrent">[out] A pointer to a variable that receives true if this is the latest version of the document, or false if it isn't the latest version.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetDocumentVersion(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument pDoc,
            [Out] out int version,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbCurrent);

        /// <summary>
        /// Gets the method version. The method version starts at 1 and is incremented each time the method is recompiled. Recompilation can happen without changes to the method.
        /// </summary>
        /// <param name="pMethod">[in] The method for which to get the version.</param>
        /// <param name="version">[out] A pointer to a variable that receives the method version.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetMethodVersion(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedMethod pMethod,
            [Out] out int version);
#endif

        /// <summary>
        /// Gets a symbol reader method, given a method token and an edit-and-continue version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-continue operation.
        /// </summary>
        /// <param name="token">[in] The method metadata token.</param>
        /// <param name="version">[in] The method version.</param>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetMethodByVersionPreRemap(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

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
        HRESULT GetSymAttributePreRemap(
            [In] mdToken parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);

        /// <summary>
        /// Gets every method that has line information in the provided document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <param name="cMethod">[in] A ULONG32 that indicates the size of the pRetVal array.</param>
        /// <param name="pcMethod">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the methods.</param>
        /// <param name="pRetVal">[out] A pointer to the buffer that receives the methods.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetMethodsInDocument(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int cMethod,
            [Out] out int pcMethod,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] ISymUnmanagedMethod[] pRetVal);
    }
}
