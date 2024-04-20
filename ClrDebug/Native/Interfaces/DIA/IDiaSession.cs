using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides a query context for debug symbols.
    /// </summary>
    /// <remarks>
    /// It is important to call the <see cref="put_loadAddress"/> method after creating the IDiaSession object — and the
    /// value passed to the put_loadAddress method must be non-zero — for any virtual address (VA) properties of symbols
    /// to be accessible. The load address comes from whatever program loaded the executable being debugged. For example,
    /// you can call the Win32 function GetModuleInformation to retrieve the load address for the executable, given a handle
    /// to the executable.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F609EE1-D1C8-4E24-8288-3326BADCD211")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaSession
    {
        /// <summary>
        /// Retrieves the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a virtual address (VA) where an .exe file or .dll file is loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The returned load address is always zero unless specifically set using the <see cref="put_loadAddress"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_loadAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Sets the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        /// <param name="NewVal">[in] Load address for the executable file.</param>
        /// <remarks>
        /// Symbol virtual address (VA) properties are computed using the value of this method. Virtual addresses are not calculated
        /// unless this property is set to non-zero.
        /// </remarks>
        [PreserveSig]
        HRESULT put_loadAddress(
            [In] long NewVal);

        /// <summary>
        /// Retrieves a reference to the global scope.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an <see cref="IDiaSymbol"/> object that represents the global scope.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_globalScope(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves an enumerator for all tables contained in the symbol store.
        /// </summary>
        /// <param name="ppEnumTables">[out] Returns an <see cref="IDiaEnumTables"/> object. Use this interface to enumerate the tables in the symbol store.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT getEnumTables(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumTables ppEnumTables);

        /// <summary>
        /// Retrieves an enumerator that finds symbols in the order of their addresses.
        /// </summary>
        /// <param name="ppEnumbyAddr">[out] Returns an <see cref="IDiaEnumSymbolsByAddr"/> object. Use this interface to search for symbols in the symbol store by memory location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT getSymbolsByAddr(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppEnumbyAddr);

        /// <summary>
        /// Retrieves all children of a specified parent identifier that match the name and symbol type.
        /// </summary>
        /// <param name="parent">[in] An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult.<para/>
        /// If the parent symbol is a type, then its class children are returned. If this parameter is NULL, then symtag must be set to SymTagExe or SymTagNull, which returns the global scope (.exe file).</param>
        /// <param name="symTag">[in] Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration.<para/>
        /// Set to SymTagNull to retrieve all children.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findChildren(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findChildrenEx(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findChildrenExByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findChildrenExByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findChildrenExByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByAddr(
            [In] int isect,
            [In] int offset,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByRVA(
            [In] int rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address.
        /// </summary>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByVA(
            [In] long va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Retrieves the symbol that contains a specified metadata token.
        /// </summary>
        /// <param name="token">[in] Specifies the token.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByToken(
            [In] int token,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Checks to see if two symbols are equivalent.
        /// </summary>
        /// <param name="symbolA">[in] The first <see cref="IDiaSymbol"/> object used in the comparison.</param>
        /// <param name="symbolB">[in] The second IDiaSymbol object used in the comparison.</param>
        /// <returns>If the symbols are equivalent, returns S_OK; otherwise, returns S_FALSE, the symbols are not equivalent. Otherwise, return an error code.</returns>
        [PreserveSig]
        HRESULT symsAreEquiv(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol symbolA,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol symbolB);

        /// <summary>
        /// Retrieves a symbol by its unique identifier.
        /// </summary>
        /// <param name="id">[in] Unique identifier.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The specified identifier is a unique value used internally by the DIA SDK to make all symbols unique. This method
        /// can be used, for example, to retrieve the symbol representing the type of another symbol (see the example).
        /// </remarks>
        [PreserveSig]
        HRESULT symbolById(
            [In] int id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA) and offset.
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <param name="displacement">[out] Returns a value specifying an offset from the relative virtual address specified in rva.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByRVAEx(
            [In] int rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address (VA) and offset.
        /// </summary>
        /// <param name="va">[in] Specifies the VA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <param name="displacement">[out] Returns a value that specifies an offset from the virtual address given by va.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolByVAEx(
            [In] long va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);

        /// <summary>
        /// Retrieves source files by compiland and name.
        /// </summary>
        /// <param name="pCompiland">[in] An <see cref="IDiaSymbol"/> object representing the compiland to be used as a context for the search. Set this parameter to NULL to find source files in all compilands.</param>
        /// <param name="name">[in] Specifies the name of the source file to be retrieved. Set this parameter to NULL for all source files to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a list of the source files retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findFile(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol pCompiland,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceFiles ppResult);

        /// <summary>
        /// Retrieves a source file by source file identifier.
        /// </summary>
        /// <param name="uniqueId">[in] Specifies the source file identifier.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaSourceFile"/> object that represents the source file retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The source file identifier is a unique value used internally to the DIA SDK to make all source files unique. This
        /// method is typically used internally to the DIA SDK.
        /// </remarks>
        [PreserveSig]
        HRESULT findFileById(
            [In] int uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile ppResult);

        /// <summary>
        /// Retrieves line numbers within specified compiland and source file identifiers.
        /// </summary>
        /// <param name="compiland">[in]An <see cref="IDiaSymbol"/> object representing the compiland. Use this interface as a context in which to search for the line numbers.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object representing the source file in which to search for the line numbers.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findLines(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified address.
        /// </summary>
        /// <param name="seg">[in] Specifies the section component of the specific address.</param>
        /// <param name="offset">[in] Specifies the offset component of the specific address.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findLinesByAddr(
            [In] int seg,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findLinesByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves the line number information for lines contained in a specified virtual address (VA) range.
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        [PreserveSig]
        HRESULT findLinesByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Determines the line numbers of the compiland that the specified line number in a source file lies within or near.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file to search in. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> objta that contains a list of the line numbers retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves a list of sources that has been placed into the symbol store by attribute providers or other components of the compilation process.
        /// </summary>
        /// <param name="srcFile">[in] Name of the source file for which to search.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumInjectedSources"/> object that contains a list of all of the injected sources.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInjectedSource(
            [MarshalAs(UnmanagedType.LPWStr), In] string srcFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInjectedSources ppResult);

        /// <summary>
        /// Retrieves an enumerated sequence of debug data streams.
        /// </summary>
        /// <param name="ppEnumDebugStreams">[out] Returns an <see cref="IDiaEnumDebugStreams"/> object that contains a list of debug streams.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT getEnumDebugStreams(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreams ppEnumDebugStreams);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineeLines(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified address range.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in the specified source file and line number.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file in which to search. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all inlined functions that match a specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name to use for comparison.</param>
        /// <param name="option">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findInlineesByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] int option,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findAcceleratorInlineeLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Returns an enumeration of symbols for the variable that the specified tag value corresponds to in the parent Accelerator stub function.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <param name="ppResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT findSymbolsForAcceleratorPointerTag(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int tagValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in a specified parent Accelerator stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <param name="rva">[in] The relative virtual address.</param>
        /// <param name="ppResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        [PreserveSig]
        HRESULT findSymbolsByRVAForAcceleratorPointerTag(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int tagValue,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Returns an enumeration of symbols for inline frames corresponding to the specified inline function name.
        /// </summary>
        /// <param name="name">[in] The inlinee function name to be searched.</param>
        /// <param name="option">[in] The name search options to be used when searching for inline frames that correspond to name. For more information, see <see cref="NameSearchOptions"/>.</param>
        /// <param name="ppResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This function searches for inlinees only within Accelerator stub functions. It ignores native C++ procedure records.
        /// </remarks>
        [PreserveSig]
        HRESULT findAcceleratorInlineesByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] int option,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT addressForVA(
            [In] long va,
            [Out] out int pISect,
            [Out] out int pOffset);

        [PreserveSig]
        HRESULT addressForRVA(
            [In] int rva,
            [Out] out int pISect,
            [Out] out int pOffset);

        [PreserveSig]
        HRESULT findILOffsetsByAddr(
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        [PreserveSig]
        HRESULT findILOffsetsByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        [PreserveSig]
        HRESULT findILOffsetsByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        [PreserveSig]
        HRESULT findInputAssemblyFiles(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInputAssemblyFiles ppResult);

        [PreserveSig]
        HRESULT findInputAssembly(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);

        [PreserveSig]
        HRESULT findInputAssemblyById(
            [In] int uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);

        [PreserveSig]
        HRESULT getFuncMDTokenMapSize(
            [Out] out int pcb);

        [PreserveSig]
        HRESULT getFuncMDTokenMap(
            [In] int cb,
            [Out] out int pcb,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pb);

        [PreserveSig]
        HRESULT getTypeMDTokenMapSize(
            [Out] out int pcb);

        [PreserveSig]
        HRESULT getTypeMDTokenMap(
            [In] int cb,
            [Out] out int pcb,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pb);

        [PreserveSig]
        HRESULT getNumberOfFunctionFragments_VA(
            [In] long vaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);

        [PreserveSig]
        HRESULT getNumberOfFunctionFragments_RVA(
            [In] int rvaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);

        [PreserveSig]
        HRESULT getFunctionFragments_VA(
            [In] long vaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out long pVaFragment,
            [Out] out int pLenFragment);

        [PreserveSig]
        HRESULT getFunctionFragments_RVA(
            [In] int rvaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out int pRvaFragment,
            [Out] out int pLenFragment);

        [PreserveSig]
        HRESULT getExports(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT getHeapAllocationSites(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        [PreserveSig]
        HRESULT findInputAssemblyFile(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol pSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);
    }
}
