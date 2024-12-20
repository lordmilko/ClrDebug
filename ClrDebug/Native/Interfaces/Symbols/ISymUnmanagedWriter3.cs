using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables.<para/>
    /// This interface extends the <see cref="ISymUnmanagedWriter"/> interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("12F1E02C-1E05-4B0E-9468-EBC9D1BB040F")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedWriter3 : ISymUnmanagedWriter2
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Defines a source document. GUIDs are provided for known languages, vendors, and document types.
        /// </summary>
        /// <param name="url">[in] A pointer to a WCHAR that defines the uniform resource locator (URL) that identifies the document.</param>
        /// <param name="language">[in] A pointer to a GUID that defines the document language.</param>
        /// <param name="languageVendor">[in] A pointer to a GUID that defines the identity of the vendor for the document language.</param>
        /// <param name="documentType">[in] A pointer to a GUID that defines the type of the document.</param>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedWriter"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineDocument(
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
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocumentWriter pRetVal);

        /// <summary>
        /// Specifies the user-defined method that is the entry point for this module. For example, this entry point could be the user's main method instead of compiler-generated stubs before main.
        /// </summary>
        /// <param name="entryMethod">[in] The metadata token for the method that is the user entry point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT SetUserEntryPoint(
            [In] int entryMethod);

        /// <summary>
        /// Opens a method into which symbol information is emitted. The given method becomes the current method for calls to define sequence points, parameters, and lexical scopes.<para/>
        /// There is an implicit lexical scope around the entire method. Reopening a method that was previously closed erases any previously defined symbols for that method.<para/>
        /// There can be only one open method at a time.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT OpenMethod(
            [In] int method);

        /// <summary>
        /// Closes the current method. Once a method is closed, no more symbols can be defined within it.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT CloseMethod();

        /// <summary>
        /// Opens a new lexical scope in the current method. The scope becomes the new current scope and is pushed onto a stack of scopes.<para/>
        /// Scopes must form a hierarchy. Siblings are not allowed to overlap.
        /// </summary>
        /// <param name="startOffset">[in] The offset of the first instruction in the lexical scope, in bytes, from the beginning of the method.</param>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the scope identifier.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// <see cref="OpenScope"/> returns an opaque scope identifier that can be used with <see cref="SetScopeRange"/>
        /// to define a scope's starting and ending offset at a later time. In this case, the offsets passed to ISymUnmanagedWriter::OpenScope
        /// and <see cref="CloseScope"/> are ignored. Scope identifiers are valid only in the current method.
        /// </remarks>
        [PreserveSig]
        new HRESULT OpenScope(
            [In] int startOffset,
            [Out] out int pRetVal);

        /// <summary>
        /// Closes the current lexical scope.
        /// </summary>
        /// <param name="endOffset">[in] The offset from the beginning of the method of the point at the end of the last instruction in the lexical scope, in bytes.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// Once a scope is closed, no more variables can be defined within it. <see cref="OpenScope"/> returns an opaque scope
        /// identifier that can be used with <see cref="SetScopeRange"/> to later define a scope's starting and ending offset.
        /// In this case, the offsets passed to <see cref="OpenScope"/> and <see cref="CloseScope"/> are ignored.
        /// Scope identifiers are valid only in the current method.
        /// </remarks>
        [PreserveSig]
        new HRESULT CloseScope(
            [In] int endOffset);

        /// <summary>
        /// Defines the offset range for the specified lexical scope. The scope becomes the new current scope and is pushed onto a stack of scopes.<para/>
        /// Scopes must form a hierarchy. Siblings are not allowed to overlap.
        /// </summary>
        /// <param name="scopeID">[in] The scope identifier for the scope.</param>
        /// <param name="startOffset">[in] The offset, in bytes, of the first instruction in the lexical scope from the beginning of the method.</param>
        /// <param name="endOffset">[in] The offset, in bytes, of the last instruction in the lexical scope from the beginning of the method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// <see cref="OpenScope"/> returns an opaque scope identifier that can be used with ISymUnmanagedWriter::SetScopeRange
        /// to define a scope's starting and ending offset at a later time. In this case, the offsets passed to ISymUnmanagedWriter::OpenScope
        /// and <see cref="CloseScope"/> are ignored. Scope identifiers are only valid in the current method.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetScopeRange(
            [In] int scopeID,
            [In] int startOffset,
            [In] int endOffset);

        /// <summary>
        /// Defines a single variable in the current lexical scope. This method can be called multiple times for a variable of the same name that has multiple homes throughout a scope.<para/>
        /// In this case, however, the values of the startOffset and endOffset parameters must not overlap.
        /// </summary>
        /// <param name="name">[in] A pointer to a WCHAR that defines the local variable name.</param>
        /// <param name="attributes">[in] The local variable attributes.</param>
        /// <param name="cSig">[in] A ULONG32 that indicates the size, in bytes, of the signature buffer.</param>
        /// <param name="signature">[in] The local variable signature.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the parameter specification.</param>
        /// <param name="addr2">[in] The second address for the parameter specification.</param>
        /// <param name="addr3">[in] The third address for the parameter specification.</param>
        /// <param name="startOffset">[in] The start offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope.<para/>
        /// If it is a nonzero value, the variable falls within the offsets of the current scope.</param>
        /// <param name="endOffset">[in] The end offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope.<para/>
        /// If it is a nonzero value, the variable falls within the offsets of the current scope.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineLocalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);

        /// <summary>
        /// Defines a single parameter in the current method. The parameter type is taken from the parameter's position (sequence) within the method's signature.<para/>
        /// If parameters are defined in the metadata for a given method, you do not have to define them again by using this method.<para/>
        /// The symbol readers must check the normal metadata for the parameters before checking the symbol store.
        /// </summary>
        /// <param name="name">[in] The parameter name.</param>
        /// <param name="attributes">[in] The parameter attributes.</param>
        /// <param name="sequence">[in] The parameter signature.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the parameter specification.</param>
        /// <param name="addr2">[in] The second address for the parameter specification.</param>
        /// <param name="addr3">[in] The third address for the parameter specification.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineParameter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int sequence,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        /// <summary>
        /// Defines a single variable that is not within a method. This method is used for certain fields in classes, bit fields, and so on.
        /// </summary>
        /// <param name="parent">[in] The metadata type or method token.</param>
        /// <param name="name">[in] The field name.</param>
        /// <param name="attributes">[in] The field attributes.</param>
        /// <param name="cSig">[in] A ULONG32 that is the size, in characters, of the buffer required to contain the field signature.</param>
        /// <param name="signature">[in] The array of field signatures.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the field specification.</param>
        /// <param name="addr2">[in] The second address for the field specification.</param>
        /// <param name="addr3">[in] The third address for the field specification.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineField(
            [In] mdToken parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        /// <summary>
        /// Defines a single global variable.
        /// </summary>
        /// <param name="name">[in] A pointer to a WCHAR that defines the global variable name.</param>
        /// <param name="attributes">[in] The global variable attributes.</param>
        /// <param name="cSig">[in] A ULONG32 that indicates the size, in characters, of the signature buffer.</param>
        /// <param name="signature">[in] The global variable signature.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the parameter specification.</param>
        /// <param name="addr2">[in] The second address for the parameter specification.</param>
        /// <param name="addr3">[in] The third address for the parameter specification.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineGlobalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        /// <summary>
        /// Closes the symbol writer after committing the symbols to the symbol store.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// After this call, the symbol writer becomes invalid for further updates. To close the symbol writer without committing
        /// the symbols, use the <see cref="Abort"/> method instead.
        /// </remarks>
        [PreserveSig]
        new HRESULT Close();

        /// <summary>
        /// Defines a custom attribute based upon its name. These attributes are held in the symbol store, unlike metadata custom attributes.
        /// </summary>
        /// <param name="parent">[in] The metadata token for which the attribute is being defined.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the attribute name.</param>
        /// <param name="cData">[in] A ULONG32 that indicates the size of the data array.</param>
        /// <param name="data">[in] The attribute value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT SetSymAttribute(
            [In] mdToken parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cData,
            [In] IntPtr data);

        /// <summary>
        /// Opens a new namespace. Call this method before defining methods or variables that occupy a namespace. Namespaces can be nested.
        /// </summary>
        /// <param name="name">[in] A pointer to the name of the new namespace.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT OpenNamespace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);

        /// <summary>
        /// Closes the most recently opened namespace.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT CloseNamespace();

        /// <summary>
        /// Specifies that the given fully qualified namespace name is being used within the currently open lexical scope. The namespace will be used within all scopes that inherit from the currently open scope.<para/>
        /// Closing the current scope will also stop the use of the namespace.
        /// </summary>
        /// <param name="fullName">[in] A pointer to the fully qualified name of the namespace.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT UsingNamespace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fullName);

        /// <summary>
        /// Specifies the true start and end of a method within a source file. Use this method to specify the extent of a method independently of the sequence points that exist within the method.
        /// </summary>
        /// <param name="startDoc">[in] A pointer to the document containing the starting position.</param>
        /// <param name="startLine">[in] The starting line number.</param>
        /// <param name="startColumn">[in] The starting column.</param>
        /// <param name="endDoc">[in] A pointer to the document containing the ending position.</param>
        /// <param name="endLine">[in] The ending line number.</param>
        /// <param name="endColumn">[in] The ending column number.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocumentWriter startDoc,
            [In] int startLine,
            [In] int startColumn,
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocumentWriter endDoc,
            [In] int endLine,
            [In] int endColumn);

        /// <summary>
        /// Sets the metadata emitter interface with which this writer will be associated, and sets the output file name to which the debugging symbols will be written.<para/>
        /// This method can be called only once, and it must be called before any other writer methods. Some writers may require a file name.<para/>
        /// However, you can always pass a file name to this method without any negative effect on writers that do not use the file name.
        /// </summary>
        /// <param name="emitter">[in] A pointer to the metadata emitter interface.</param>
        /// <param name="filename">[in] The file name to which the debugging symbols are written. If a file name is specified for a writer that does not use file names, this parameter is ignored.</param>
        /// <param name="pIStream">[in] If specified, the symbol writer will emit the symbols into the given <see cref="IStream"/> rather than to the file specified in the filename parameter.<para/>
        /// The pIStream parameter is optional.</param>
        /// <param name="fFullBuild">[in] true if this is a full rebuild; false if this is an incremental compilation.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT Initialize(
            [MarshalAs(UnmanagedType.Interface), In] object emitter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFullBuild);

        /// <summary>
        /// Returns the information necessary for a compiler to write the debug directory entry in the portable executable (PE) file header.<para/>
        /// The symbol writer fills out all fields except for TimeDateStamp and PointerToRawData. (The compiler is responsible for setting these two fields appropriately.) A compiler should call this method, emit the data blob to the PE file, set the PointerToRawData field in the IMAGE_DEBUG_DIRECTORY to point to the emitted data, and write the IMAGE_DEBUG_DIRECTORY to the PE file.<para/>
        /// The compiler should also set the TimeDateStamp field to equal the TimeDateStamp of the PE file being generated.
        /// </summary>
        /// <param name="pIDD">[in, out] A pointer to an IMAGE_DEBUG_DIRECTORY that the symbol writer will fill out.</param>
        /// <param name="cData">[in] A DWORD that contains the size of the debug data.</param>
        /// <param name="pcData">[out] A pointer to a DWORD that receives the size of the buffer required to contain the debug data.</param>
        /// <param name="data">[out] A pointer to a buffer that is large enough to hold the debug data for the symbol store.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT GetDebugInfo(
            [In, Out] ref IntPtr pIDD,
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] byte[] data);

        /// <summary>
        /// Defines a group of sequence points within the current method. Each starting line and starting column define the start of a statement within a method.<para/>
        /// Each ending line and ending column define the end of a statement within a method. The arrays should be sorted in increasing order of offsets.<para/>
        /// The offset is always measured from the start of the method, in bytes.
        /// </summary>
        /// <param name="document">[in] The document object for which the sequence points are being defined.</param>
        /// <param name="spCount">[in] A ULONG32 that indicates the size of each of the offsets, lines, columns, endLines, and endColumns buffers.</param>
        /// <param name="offsets">[in] The offset of the sequence points measured from the beginning of the method.</param>
        /// <param name="lines">[in] The starting line numbers of the sequence points.</param>
        /// <param name="columns">[in] The starting column numbers of the sequence points.</param>
        /// <param name="endLines">[in] The ending line numbers of the sequence points. This parameter is optional.</param>
        /// <param name="endColumns">[in] The ending column numbers of the sequence points. This parameter is optional.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocumentWriter document,
            [In] int spCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] offsets,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] lines,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] columns,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] endLines,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] endColumns);

        /// <summary>
        /// Notifies the symbol writer that a metadata token has been remapped as the metadata was emitted. If the symbol writer has stored the old token within the symbol store, it must either update the stored token with the new value, or it must save the map for the corresponding symbol reader to remap during the read phase.
        /// </summary>
        /// <param name="oldToken">[in] The metadata token that was remapped.</param>
        /// <param name="newToken">[in] The new metadata token to which oldToken was remapped.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT RemapToken(
            [In] mdToken oldToken,
            [In] mdToken newToken);

        /// <summary>
        /// Sets the metadata emitter interface with which this writer will be associated, and sets the output file name to which the debugging symbols will be written.<para/>
        /// This method also lets you set the final location of the program database (PDB) file.
        /// </summary>
        /// <param name="emitter">[in] A pointer to the metadata emitter interface.</param>
        /// <param name="tempfilename">[in] A pointer to a WCHAR that contains the file name to which the debugging symbols are written. If a file name is specified for a writer that does not use file names, this parameter is ignored.</param>
        /// <param name="pIStream">[in] If specified, the symbol writer emits the symbols into the given <see cref="IStream"/> rather than to the file specified in the filename parameter.<para/>
        /// The pIStream parameter is optional.</param>
        /// <param name="fFullBuild">[in] true if this is a full rebuild; false if this is an incremental compilation.</param>
        /// <param name="finalfilename">[in] A pointer to a WCHAR that is the path string to the final location of the PDB file.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT Initialize2(
            [MarshalAs(UnmanagedType.Interface), In] object emitter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string tempfilename,
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFullBuild,
            [In, MarshalAs(UnmanagedType.LPWStr)] string finalfilename);

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] A pointer to a WCHAR that defines the constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="cSig">[in] The size of the signature array.</param>
        /// <param name="signature">[in] The type signature for the constant.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineConstant(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
#if !GENERATED_MARSHALLING
            [MarshalAs(UnmanagedType.Struct), In]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            object value,
            [In] int cSig,
            [In] IntPtr signature);

        /// <summary>
        /// Closes the symbol writer without committing the symbols to the symbol store. After this call, the symbol writer becomes invalid for further updates.<para/>
        /// To commit the symbols and close the symbol writer, use the <see cref="Close"/> method instead.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT Abort();

        /// <summary>
        /// Defines a single variable in the current lexical scope. This method can be called multiple times for a variable of the same name that has multiple homes throughout a scope.<para/>
        /// In this case, however, the values of the startOffset and endOffset parameters must not overlap.
        /// </summary>
        /// <param name="name">[in] The local variable name.</param>
        /// <param name="attributes">[in] The local variable attributes.</param>
        /// <param name="sigToken">[in] The metadata token of the signature.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the parameter specification.</param>
        /// <param name="addr2">[in] The second address for the parameter specification.</param>
        /// <param name="addr3">[in] The third address for the parameter specification.</param>
        /// <param name="startOffset">[in] The start offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope.<para/>
        /// If it is a nonzero value, the variable falls within the offsets of the current scope.</param>
        /// <param name="endOffset">[in] The end offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope.<para/>
        /// If it is a nonzero value, the variable falls within the offsets of the current scope.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineLocalVariable2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] mdSignature sigToken,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);

        /// <summary>
        /// Defines a single global variable.
        /// </summary>
        /// <param name="name">[in] The global variable name.</param>
        /// <param name="attributes">[in] The global variable attributes.</param>
        /// <param name="sigToken">[in] The metadata token of the signature.</param>
        /// <param name="addrKind">[in] The address type.</param>
        /// <param name="addr1">[in] The first address for the parameter specification.</param>
        /// <param name="addr2">[in] The second address for the parameter specification.</param>
        /// <param name="addr3">[in] The third address for the parameter specification.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineGlobalVariable2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] mdSignature sigToken,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] The constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="sigToken">[in] The metadata token of the constant.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        new HRESULT DefineConstant2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
#if !GENERATED_MARSHALLING
            [MarshalAs(UnmanagedType.Struct), In]
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            object value,
            [In] mdSignature sigToken);
#endif

        /// <summary>
        /// Opens a method and provides its real section offset in the image.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        /// <param name="isect">[in] The section offset in the image.</param>
        /// <param name="offset">[in] The offset in the image.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT OpenMethod2(
            [In] int method,
            [In] int isect,
            [In] int offset);

        /// <summary>
        /// Commits the changes written so far to the stream.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT Commit();
    }
}
