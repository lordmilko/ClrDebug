using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables.
    /// </summary>
    public class SymUnmanagedWriter : ComObject<ISymUnmanagedWriter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedWriter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedWriter(ISymUnmanagedWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedWriter
        #region DefineDocument

        /// <summary>
        /// Defines a source document. GUIDs are provided for known languages, vendors, and document types.
        /// </summary>
        /// <param name="url">[in] A pointer to a WCHAR that defines the uniform resource locator (URL) that identifies the document.</param>
        /// <param name="language">[in] A pointer to a GUID that defines the document language.</param>
        /// <param name="languageVendor">[in] A pointer to a GUID that defines the identity of the vendor for the document language.</param>
        /// <param name="documentType">[in] A pointer to a GUID that defines the type of the document.</param>
        /// <returns>[out] A pointer to the returned <see cref="ISymUnmanagedWriter"/> interface.</returns>
        public SymUnmanagedDocumentWriter DefineDocument(string url, Guid language, Guid languageVendor, Guid documentType)
        {
            SymUnmanagedDocumentWriter pRetValResult;
            TryDefineDocument(url, language, languageVendor, documentType, out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        /// <summary>
        /// Defines a source document. GUIDs are provided for known languages, vendors, and document types.
        /// </summary>
        /// <param name="url">[in] A pointer to a WCHAR that defines the uniform resource locator (URL) that identifies the document.</param>
        /// <param name="language">[in] A pointer to a GUID that defines the document language.</param>
        /// <param name="languageVendor">[in] A pointer to a GUID that defines the identity of the vendor for the document language.</param>
        /// <param name="documentType">[in] A pointer to a GUID that defines the type of the document.</param>
        /// <param name="pRetValResult">[out] A pointer to the returned <see cref="ISymUnmanagedWriter"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryDefineDocument(string url, Guid language, Guid languageVendor, Guid documentType, out SymUnmanagedDocumentWriter pRetValResult)
        {
            /*HRESULT DefineDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType,
            [Out] out ISymUnmanagedDocumentWriter pRetVal);*/
            ISymUnmanagedDocumentWriter pRetVal;
            HRESULT hr = Raw.DefineDocument(url, ref language, ref languageVendor, ref documentType, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedDocumentWriter(pRetVal);
            else
                pRetValResult = default(SymUnmanagedDocumentWriter);

            return hr;
        }

        #endregion
        #region SetUserEntryPoint

        /// <summary>
        /// Specifies the user-defined method that is the entry point for this module. For example, this entry point could be the user's main method instead of compiler-generated stubs before main.
        /// </summary>
        /// <param name="entryMethod">[in] The metadata token for the method that is the user entry point.</param>
        public void SetUserEntryPoint(int entryMethod)
        {
            TrySetUserEntryPoint(entryMethod).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the user-defined method that is the entry point for this module. For example, this entry point could be the user's main method instead of compiler-generated stubs before main.
        /// </summary>
        /// <param name="entryMethod">[in] The metadata token for the method that is the user entry point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetUserEntryPoint(int entryMethod)
        {
            /*HRESULT SetUserEntryPoint([In] int entryMethod);*/
            return Raw.SetUserEntryPoint(entryMethod);
        }

        #endregion
        #region OpenMethod

        /// <summary>
        /// Opens a method into which symbol information is emitted. The given method becomes the current method for calls to define sequence points, parameters, and lexical scopes.<para/>
        /// There is an implicit lexical scope around the entire method. Reopening a method that was previously closed erases any previously defined symbols for that method.<para/>
        /// There can be only one open method at a time.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        public void OpenMethod(int method)
        {
            TryOpenMethod(method).ThrowOnNotOK();
        }

        /// <summary>
        /// Opens a method into which symbol information is emitted. The given method becomes the current method for calls to define sequence points, parameters, and lexical scopes.<para/>
        /// There is an implicit lexical scope around the entire method. Reopening a method that was previously closed erases any previously defined symbols for that method.<para/>
        /// There can be only one open method at a time.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryOpenMethod(int method)
        {
            /*HRESULT OpenMethod([In] int method);*/
            return Raw.OpenMethod(method);
        }

        #endregion
        #region CloseMethod

        /// <summary>
        /// Closes the current method. Once a method is closed, no more symbols can be defined within it.
        /// </summary>
        public void CloseMethod()
        {
            TryCloseMethod().ThrowOnNotOK();
        }

        /// <summary>
        /// Closes the current method. Once a method is closed, no more symbols can be defined within it.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryCloseMethod()
        {
            /*HRESULT CloseMethod();*/
            return Raw.CloseMethod();
        }

        #endregion
        #region OpenScope

        /// <summary>
        /// Opens a new lexical scope in the current method. The scope becomes the new current scope and is pushed onto a stack of scopes.<para/>
        /// Scopes must form a hierarchy. Siblings are not allowed to overlap.
        /// </summary>
        /// <param name="startOffset">[in] The offset of the first instruction in the lexical scope, in bytes, from the beginning of the method.</param>
        /// <returns>[out] A pointer to a ULONG32 that receives the scope identifier.</returns>
        /// <remarks>
        /// <see cref="OpenScope"/> returns an opaque scope identifier that can be used with <see cref="SetScopeRange"/>
        /// to define a scope's starting and ending offset at a later time. In this case, the offsets passed to ISymUnmanagedWriter::OpenScope
        /// and <see cref="CloseScope"/> are ignored. Scope identifiers are valid only in the current method.
        /// </remarks>
        public int OpenScope(int startOffset)
        {
            int pRetVal;
            TryOpenScope(startOffset, out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

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
        public HRESULT TryOpenScope(int startOffset, out int pRetVal)
        {
            /*HRESULT OpenScope([In] int startOffset, [Out] out int pRetVal);*/
            return Raw.OpenScope(startOffset, out pRetVal);
        }

        #endregion
        #region CloseScope

        /// <summary>
        /// Closes the current lexical scope.
        /// </summary>
        /// <param name="endOffset">[in] The offset from the beginning of the method of the point at the end of the last instruction in the lexical scope, in bytes.</param>
        /// <remarks>
        /// Once a scope is closed, no more variables can be defined within it. <see cref="OpenScope"/> returns an opaque scope
        /// identifier that can be used with <see cref="SetScopeRange"/> to later define a scope's starting and ending offset.
        /// In this case, the offsets passed to <see cref="OpenScope"/> and <see cref="CloseScope"/> are ignored.
        /// Scope identifiers are valid only in the current method.
        /// </remarks>
        public void CloseScope(int endOffset)
        {
            TryCloseScope(endOffset).ThrowOnNotOK();
        }

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
        public HRESULT TryCloseScope(int endOffset)
        {
            /*HRESULT CloseScope([In] int endOffset);*/
            return Raw.CloseScope(endOffset);
        }

        #endregion
        #region SetScopeRange

        /// <summary>
        /// Defines the offset range for the specified lexical scope. The scope becomes the new current scope and is pushed onto a stack of scopes.<para/>
        /// Scopes must form a hierarchy. Siblings are not allowed to overlap.
        /// </summary>
        /// <param name="scopeID">[in] The scope identifier for the scope.</param>
        /// <param name="startOffset">[in] The offset, in bytes, of the first instruction in the lexical scope from the beginning of the method.</param>
        /// <param name="endOffset">[in] The offset, in bytes, of the last instruction in the lexical scope from the beginning of the method.</param>
        /// <remarks>
        /// <see cref="OpenScope"/> returns an opaque scope identifier that can be used with ISymUnmanagedWriter::SetScopeRange
        /// to define a scope's starting and ending offset at a later time. In this case, the offsets passed to ISymUnmanagedWriter::OpenScope
        /// and <see cref="CloseScope"/> are ignored. Scope identifiers are only valid in the current method.
        /// </remarks>
        public void SetScopeRange(int scopeID, int startOffset, int endOffset)
        {
            TrySetScopeRange(scopeID, startOffset, endOffset).ThrowOnNotOK();
        }

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
        public HRESULT TrySetScopeRange(int scopeID, int startOffset, int endOffset)
        {
            /*HRESULT SetScopeRange([In] int scopeID, [In] int startOffset, [In] int endOffset);*/
            return Raw.SetScopeRange(scopeID, startOffset, endOffset);
        }

        #endregion
        #region DefineLocalVariable

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
        public void DefineLocalVariable(string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3, int startOffset, int endOffset)
        {
            TryDefineLocalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3, startOffset, endOffset).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineLocalVariable(string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3, int startOffset, int endOffset)
        {
            /*HRESULT DefineLocalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);*/
            return Raw.DefineLocalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3, startOffset, endOffset);
        }

        #endregion
        #region DefineParameter

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
        public void DefineParameter(string name, int attributes, int sequence, int addrKind, int addr1, int addr2, int addr3)
        {
            TryDefineParameter(name, attributes, sequence, addrKind, addr1, addr2, addr3).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineParameter(string name, int attributes, int sequence, int addrKind, int addr1, int addr2, int addr3)
        {
            /*HRESULT DefineParameter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int sequence,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);*/
            return Raw.DefineParameter(name, attributes, sequence, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineField

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
        public void DefineField(int parent, string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3)
        {
            TryDefineField(parent, name, attributes, cSig, signature, addrKind, addr1, addr2, addr3).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineField(int parent, string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3)
        {
            /*HRESULT DefineField(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);*/
            return Raw.DefineField(parent, name, attributes, cSig, signature, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineGlobalVariable

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
        public void DefineGlobalVariable(string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3)
        {
            TryDefineGlobalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineGlobalVariable(string name, int attributes, int cSig, IntPtr signature, int addrKind, int addr1, int addr2, int addr3)
        {
            /*HRESULT DefineGlobalVariable(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] int cSig,
            [In] IntPtr signature,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);*/
            return Raw.DefineGlobalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region Close

        /// <summary>
        /// Closes the symbol writer after committing the symbols to the symbol store.
        /// </summary>
        /// <remarks>
        /// After this call, the symbol writer becomes invalid for further updates. To close the symbol writer without committing
        /// the symbols, use the <see cref="Abort"/> method instead.
        /// </remarks>
        public void Close()
        {
            TryClose().ThrowOnNotOK();
        }

        /// <summary>
        /// Closes the symbol writer after committing the symbols to the symbol store.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        /// <remarks>
        /// After this call, the symbol writer becomes invalid for further updates. To close the symbol writer without committing
        /// the symbols, use the <see cref="Abort"/> method instead.
        /// </remarks>
        public HRESULT TryClose()
        {
            /*HRESULT Close();*/
            return Raw.Close();
        }

        #endregion
        #region SetSymAttribute

        /// <summary>
        /// Defines a custom attribute based upon its name. These attributes are held in the symbol store, unlike metadata custom attributes.
        /// </summary>
        /// <param name="parent">[in] The metadata token for which the attribute is being defined.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the attribute name.</param>
        /// <param name="cData">[in] A ULONG32 that indicates the size of the data array.</param>
        /// <param name="data">[in] The attribute value.</param>
        public void SetSymAttribute(int parent, string name, int cData, IntPtr data)
        {
            TrySetSymAttribute(parent, name, cData, data).ThrowOnNotOK();
        }

        /// <summary>
        /// Defines a custom attribute based upon its name. These attributes are held in the symbol store, unlike metadata custom attributes.
        /// </summary>
        /// <param name="parent">[in] The metadata token for which the attribute is being defined.</param>
        /// <param name="name">[in] A pointer to a WCHAR that contains the attribute name.</param>
        /// <param name="cData">[in] A ULONG32 that indicates the size of the data array.</param>
        /// <param name="data">[in] The attribute value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TrySetSymAttribute(int parent, string name, int cData, IntPtr data)
        {
            /*HRESULT SetSymAttribute([In] int parent, [In, MarshalAs(UnmanagedType.LPWStr)] string name, [In] int cData, [In] IntPtr data);*/
            return Raw.SetSymAttribute(parent, name, cData, data);
        }

        #endregion
        #region OpenNamespace

        /// <summary>
        /// Opens a new namespace. Call this method before defining methods or variables that occupy a namespace. Namespaces can be nested.
        /// </summary>
        /// <param name="name">[in] A pointer to the name of the new namespace.</param>
        public void OpenNamespace(string name)
        {
            TryOpenNamespace(name).ThrowOnNotOK();
        }

        /// <summary>
        /// Opens a new namespace. Call this method before defining methods or variables that occupy a namespace. Namespaces can be nested.
        /// </summary>
        /// <param name="name">[in] A pointer to the name of the new namespace.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryOpenNamespace(string name)
        {
            /*HRESULT OpenNamespace([In, MarshalAs(UnmanagedType.LPWStr)] string name);*/
            return Raw.OpenNamespace(name);
        }

        #endregion
        #region CloseNamespace

        /// <summary>
        /// Closes the most recently opened namespace.
        /// </summary>
        public void CloseNamespace()
        {
            TryCloseNamespace().ThrowOnNotOK();
        }

        /// <summary>
        /// Closes the most recently opened namespace.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryCloseNamespace()
        {
            /*HRESULT CloseNamespace();*/
            return Raw.CloseNamespace();
        }

        #endregion
        #region UsingNamespace

        /// <summary>
        /// Specifies that the given fully qualified namespace name is being used within the currently open lexical scope. The namespace will be used within all scopes that inherit from the currently open scope.<para/>
        /// Closing the current scope will also stop the use of the namespace.
        /// </summary>
        /// <param name="fullName">[in] A pointer to the fully qualified name of the namespace.</param>
        public void UsingNamespace(string fullName)
        {
            TryUsingNamespace(fullName).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies that the given fully qualified namespace name is being used within the currently open lexical scope. The namespace will be used within all scopes that inherit from the currently open scope.<para/>
        /// Closing the current scope will also stop the use of the namespace.
        /// </summary>
        /// <param name="fullName">[in] A pointer to the fully qualified name of the namespace.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryUsingNamespace(string fullName)
        {
            /*HRESULT UsingNamespace([In, MarshalAs(UnmanagedType.LPWStr)] string fullName);*/
            return Raw.UsingNamespace(fullName);
        }

        #endregion
        #region SetMethodSourceRange

        /// <summary>
        /// Specifies the true start and end of a method within a source file. Use this method to specify the extent of a method independently of the sequence points that exist within the method.
        /// </summary>
        /// <param name="startDoc">[in] A pointer to the document containing the starting position.</param>
        /// <param name="startLine">[in] The starting line number.</param>
        /// <param name="startColumn">[in] The starting column.</param>
        /// <param name="endDoc">[in] A pointer to the document containing the ending position.</param>
        /// <param name="endLine">[in] The ending line number.</param>
        /// <param name="endColumn">[in] The ending column number.</param>
        public void SetMethodSourceRange(ISymUnmanagedDocumentWriter startDoc, int startLine, int startColumn, ISymUnmanagedDocumentWriter endDoc, int endLine, int endColumn)
        {
            TrySetMethodSourceRange(startDoc, startLine, startColumn, endDoc, endLine, endColumn).ThrowOnNotOK();
        }

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
        public HRESULT TrySetMethodSourceRange(ISymUnmanagedDocumentWriter startDoc, int startLine, int startColumn, ISymUnmanagedDocumentWriter endDoc, int endLine, int endColumn)
        {
            /*HRESULT SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] int startLine,
            [In] int startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] int endLine,
            [In] int endColumn);*/
            return Raw.SetMethodSourceRange(startDoc, startLine, startColumn, endDoc, endLine, endColumn);
        }

        #endregion
        #region Initialize

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
        public void Initialize(object emitter, string filename, IStream pIStream, int fFullBuild)
        {
            TryInitialize(emitter, filename, pIStream, fFullBuild).ThrowOnNotOK();
        }

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
        public HRESULT TryInitialize(object emitter, string filename, IStream pIStream, int fFullBuild)
        {
            /*HRESULT Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object emitter, [In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] int fFullBuild);*/
            return Raw.Initialize(emitter, filename, pIStream, fFullBuild);
        }

        #endregion
        #region GetDebugInfo

        /// <summary>
        /// Returns the information necessary for a compiler to write the debug directory entry in the portable executable (PE) file header.<para/>
        /// The symbol writer fills out all fields except for TimeDateStamp and PointerToRawData. (The compiler is responsible for setting these two fields appropriately.) A compiler should call this method, emit the data blob to the PE file, set the PointerToRawData field in the IMAGE_DEBUG_DIRECTORY to point to the emitted data, and write the IMAGE_DEBUG_DIRECTORY to the PE file.<para/>
        /// The compiler should also set the TimeDateStamp field to equal the TimeDateStamp of the PE file being generated.
        /// </summary>
        /// <param name="pIDD">[in, out] A pointer to an IMAGE_DEBUG_DIRECTORY that the symbol writer will fill out.</param>
        /// <returns>[out] A pointer to a buffer that is large enough to hold the debug data for the symbol store.</returns>
        public byte[] GetDebugInfo(ref IntPtr pIDD)
        {
            byte[] dataResult;
            TryGetDebugInfo(ref pIDD, out dataResult).ThrowOnNotOK();

            return dataResult;
        }

        /// <summary>
        /// Returns the information necessary for a compiler to write the debug directory entry in the portable executable (PE) file header.<para/>
        /// The symbol writer fills out all fields except for TimeDateStamp and PointerToRawData. (The compiler is responsible for setting these two fields appropriately.) A compiler should call this method, emit the data blob to the PE file, set the PointerToRawData field in the IMAGE_DEBUG_DIRECTORY to point to the emitted data, and write the IMAGE_DEBUG_DIRECTORY to the PE file.<para/>
        /// The compiler should also set the TimeDateStamp field to equal the TimeDateStamp of the PE file being generated.
        /// </summary>
        /// <param name="pIDD">[in, out] A pointer to an IMAGE_DEBUG_DIRECTORY that the symbol writer will fill out.</param>
        /// <param name="dataResult">[out] A pointer to a buffer that is large enough to hold the debug data for the symbol store.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetDebugInfo(ref IntPtr pIDD, out byte[] dataResult)
        {
            /*HRESULT GetDebugInfo(
            [In, Out] ref IntPtr pIDD,
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            int cData = 0;
            int pcData;
            byte[] data = null;
            HRESULT hr = Raw.GetDebugInfo(ref pIDD, cData, out pcData, data);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cData = pcData;
            data = new byte[pcData];
            hr = Raw.GetDebugInfo(ref pIDD, cData, out pcData, data);

            if (hr == HRESULT.S_OK)
            {
                dataResult = data;

                return hr;
            }

            fail:
            dataResult = default(byte[]);

            return hr;
        }

        #endregion
        #region DefineSequencePoints

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
        public void DefineSequencePoints(ISymUnmanagedDocumentWriter document, int spCount, int offsets, int lines, int columns, int endLines, int endColumns)
        {
            TryDefineSequencePoints(document, spCount, offsets, lines, columns, endLines, endColumns).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineSequencePoints(ISymUnmanagedDocumentWriter document, int spCount, int offsets, int lines, int columns, int endLines, int endColumns)
        {
            /*HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] int spCount,
            [In] ref int offsets,
            [In] ref int lines,
            [In] ref int columns,
            [In] ref int endLines,
            [In] ref int endColumns);*/
            return Raw.DefineSequencePoints(document, spCount, ref offsets, ref lines, ref columns, ref endLines, ref endColumns);
        }

        #endregion
        #region RemapToken

        /// <summary>
        /// Notifies the symbol writer that a metadata token has been remapped as the metadata was emitted. If the symbol writer has stored the old token within the symbol store, it must either update the stored token with the new value, or it must save the map for the corresponding symbol reader to remap during the read phase.
        /// </summary>
        /// <param name="oldToken">[in] The metadata token that was remapped.</param>
        /// <param name="newToken">[in] The new metadata token to which oldToken was remapped.</param>
        public void RemapToken(mdToken oldToken, mdToken newToken)
        {
            TryRemapToken(oldToken, newToken).ThrowOnNotOK();
        }

        /// <summary>
        /// Notifies the symbol writer that a metadata token has been remapped as the metadata was emitted. If the symbol writer has stored the old token within the symbol store, it must either update the stored token with the new value, or it must save the map for the corresponding symbol reader to remap during the read phase.
        /// </summary>
        /// <param name="oldToken">[in] The metadata token that was remapped.</param>
        /// <param name="newToken">[in] The new metadata token to which oldToken was remapped.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryRemapToken(mdToken oldToken, mdToken newToken)
        {
            /*HRESULT RemapToken([In] mdToken oldToken, [In] mdToken newToken);*/
            return Raw.RemapToken(oldToken, newToken);
        }

        #endregion
        #region Initialize2

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
        public void Initialize2(object emitter, string tempfilename, IStream pIStream, int fFullBuild, string finalfilename)
        {
            TryInitialize2(emitter, tempfilename, pIStream, fFullBuild, finalfilename).ThrowOnNotOK();
        }

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
        public HRESULT TryInitialize2(object emitter, string tempfilename, IStream pIStream, int fFullBuild, string finalfilename)
        {
            /*HRESULT Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In, MarshalAs(UnmanagedType.LPWStr)] string finalfilename);*/
            return Raw.Initialize2(emitter, tempfilename, pIStream, fFullBuild, finalfilename);
        }

        #endregion
        #region DefineConstant

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] A pointer to a WCHAR that defines the constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="cSig">[in] The size of the signature array.</param>
        /// <param name="signature">[in] The type signature for the constant.</param>
        public void DefineConstant(string name, object value, int cSig, IntPtr signature)
        {
            TryDefineConstant(name, value, cSig, signature).ThrowOnNotOK();
        }

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] A pointer to a WCHAR that defines the constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="cSig">[in] The size of the signature array.</param>
        /// <param name="signature">[in] The type signature for the constant.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryDefineConstant(string name, object value, int cSig, IntPtr signature)
        {
            /*HRESULT DefineConstant([In, MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Struct), In] object value, [In] int cSig,
            [In] IntPtr signature);*/
            return Raw.DefineConstant(name, value, cSig, signature);
        }

        #endregion
        #region Abort

        /// <summary>
        /// Closes the symbol writer without committing the symbols to the symbol store. After this call, the symbol writer becomes invalid for further updates.<para/>
        /// To commit the symbols and close the symbol writer, use the <see cref="Close"/> method instead.
        /// </summary>
        public void Abort()
        {
            TryAbort().ThrowOnNotOK();
        }

        /// <summary>
        /// Closes the symbol writer without committing the symbols to the symbol store. After this call, the symbol writer becomes invalid for further updates.<para/>
        /// To commit the symbols and close the symbol writer, use the <see cref="Close"/> method instead.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedWriter2 Raw2 => (ISymUnmanagedWriter2) Raw;

        #region DefineLocalVariable2

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
        public void DefineLocalVariable2(string name, int attributes, mdSignature sigToken, int addrKind, int addr1, int addr2, int addr3, int startOffset, int endOffset)
        {
            TryDefineLocalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3, startOffset, endOffset).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineLocalVariable2(string name, int attributes, mdSignature sigToken, int addrKind, int addr1, int addr2, int addr3, int startOffset, int endOffset)
        {
            /*HRESULT DefineLocalVariable2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] mdSignature sigToken,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3,
            [In] int startOffset,
            [In] int endOffset);*/
            return Raw2.DefineLocalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3, startOffset, endOffset);
        }

        #endregion
        #region DefineGlobalVariable2

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
        public void DefineGlobalVariable2(string name, int attributes, mdSignature sigToken, int addrKind, int addr1, int addr2, int addr3)
        {
            TryDefineGlobalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineGlobalVariable2(string name, int attributes, mdSignature sigToken, int addrKind, int addr1, int addr2, int addr3)
        {
            /*HRESULT DefineGlobalVariable2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int attributes,
            [In] mdSignature sigToken,
            [In] int addrKind,
            [In] int addr1,
            [In] int addr2,
            [In] int addr3);*/
            return Raw2.DefineGlobalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineConstant2

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] The constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="sigToken">[in] The metadata token of the constant.</param>
        public void DefineConstant2(string name, object value, mdSignature sigToken)
        {
            TryDefineConstant2(name, value, sigToken).ThrowOnNotOK();
        }

        /// <summary>
        /// Defines a name for a constant value.
        /// </summary>
        /// <param name="name">[in] The constant name.</param>
        /// <param name="value">[in] The value of the constant.</param>
        /// <param name="sigToken">[in] The metadata token of the constant.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryDefineConstant2(string name, object value, mdSignature sigToken)
        {
            /*HRESULT DefineConstant2([In, MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] mdSignature sigToken);*/
            return Raw2.DefineConstant2(name, value, sigToken);
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedWriter3 Raw3 => (ISymUnmanagedWriter3) Raw;

        #region OpenMethod2

        /// <summary>
        /// Opens a method and provides its real section offset in the image.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        /// <param name="isect">[in] The section offset in the image.</param>
        /// <param name="offset">[in] The offset in the image.</param>
        public void OpenMethod2(int method, int isect, int offset)
        {
            TryOpenMethod2(method, isect, offset).ThrowOnNotOK();
        }

        /// <summary>
        /// Opens a method and provides its real section offset in the image.
        /// </summary>
        /// <param name="method">[in] The metadata token for the method to be opened.</param>
        /// <param name="isect">[in] The section offset in the image.</param>
        /// <param name="offset">[in] The offset in the image.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryOpenMethod2(int method, int isect, int offset)
        {
            /*HRESULT OpenMethod2([In] int method, [In] int isect, [In] int offset);*/
            return Raw3.OpenMethod2(method, isect, offset);
        }

        #endregion
        #region Commit

        /// <summary>
        /// Commits the changes written so far to the stream.
        /// </summary>
        public void Commit()
        {
            TryCommit().ThrowOnNotOK();
        }

        /// <summary>
        /// Commits the changes written so far to the stream.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryCommit()
        {
            /*HRESULT Commit();*/
            return Raw3.Commit();
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedWriter4 Raw4 => (ISymUnmanagedWriter4) Raw;

        #region GetDebugInfoWithPadding

        /// <summary>
        /// Functions the same as <see cref="GetDebugInfo"/> except that the path string is padded with zeros following the terminating null character to make the string data a fixed size of MAX_PATH.<para/>
        /// Padding is only given if the path string length itself is less than MAX_PATH. This makes it easier to write tools that difference PE files.
        /// </summary>
        public byte[] GetDebugInfoWithPadding(ref IntPtr pIDD)
        {
            byte[] dataResult;
            TryGetDebugInfoWithPadding(ref pIDD, out dataResult).ThrowOnNotOK();

            return dataResult;
        }

        /// <summary>
        /// Functions the same as <see cref="GetDebugInfo"/> except that the path string is padded with zeros following the terminating null character to make the string data a fixed size of MAX_PATH.<para/>
        /// Padding is only given if the path string length itself is less than MAX_PATH. This makes it easier to write tools that difference PE files.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetDebugInfoWithPadding(ref IntPtr pIDD, out byte[] dataResult)
        {
            /*HRESULT GetDebugInfoWithPadding(
            [In, Out] ref IntPtr pIDD,
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            int cData = 0;
            int pcData;
            byte[] data = null;
            HRESULT hr = Raw4.GetDebugInfoWithPadding(ref pIDD, cData, out pcData, data);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cData = pcData;
            data = new byte[pcData];
            hr = Raw4.GetDebugInfoWithPadding(ref pIDD, cData, out pcData, data);

            if (hr == HRESULT.S_OK)
            {
                dataResult = data;

                return hr;
            }

            fail:
            dataResult = default(byte[]);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedWriter5 Raw5 => (ISymUnmanagedWriter5) Raw;

        #region OpenMapTokensToSourceSpans

        /// <summary>
        /// Open a special custom data section to emit token-to-source span mapping information into. Opening this section when a method is already open, or vice versa, is an error.
        /// </summary>
        public void OpenMapTokensToSourceSpans()
        {
            TryOpenMapTokensToSourceSpans().ThrowOnNotOK();
        }

        /// <summary>
        /// Open a special custom data section to emit token-to-source span mapping information into. Opening this section when a method is already open, or vice versa, is an error.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryOpenMapTokensToSourceSpans()
        {
            /*HRESULT OpenMapTokensToSourceSpans();*/
            return Raw5.OpenMapTokensToSourceSpans();
        }

        #endregion
        #region CloseMapTokensToSourceSpans

        /// <summary>
        /// Close the special custom data section for token-to-source span mapping information. After it is closed, no more mapping information can be added.
        /// </summary>
        public void CloseMapTokensToSourceSpans()
        {
            TryCloseMapTokensToSourceSpans().ThrowOnNotOK();
        }

        /// <summary>
        /// Close the special custom data section for token-to-source span mapping information. After it is closed, no more mapping information can be added.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryCloseMapTokensToSourceSpans()
        {
            /*HRESULT CloseMapTokensToSourceSpans();*/
            return Raw5.CloseMapTokensToSourceSpans();
        }

        #endregion
        #region MapTokenToSourceSpan

        /// <summary>
        /// Maps the given metadata token to the given source line span in the specified source file. Must be called between calls to <see cref="OpenMapTokensToSourceSpans"/> and <see cref="CloseMapTokensToSourceSpans"/>.
        /// </summary>
        public void MapTokenToSourceSpan(mdToken token, ISymUnmanagedDocumentWriter document, int line, int column, int endLine, int endColumn)
        {
            TryMapTokenToSourceSpan(token, document, line, column, endLine, endColumn).ThrowOnNotOK();
        }

        /// <summary>
        /// Maps the given metadata token to the given source line span in the specified source file. Must be called between calls to <see cref="OpenMapTokensToSourceSpans"/> and <see cref="CloseMapTokensToSourceSpans"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryMapTokenToSourceSpan(mdToken token, ISymUnmanagedDocumentWriter document, int line, int column, int endLine, int endColumn)
        {
            /*HRESULT MapTokenToSourceSpan(
            [In] mdToken token,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] int line,
            [In] int column,
            [In] int endLine,
            [In] int endColumn);*/
            return Raw5.MapTokenToSourceSpan(token, document, line, column, endLine, endColumn);
        }

        #endregion
        #endregion
    }
}