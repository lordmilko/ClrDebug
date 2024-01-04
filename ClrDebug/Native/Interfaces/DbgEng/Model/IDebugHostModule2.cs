using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a particular module. This version 2 of the interface supports all of the previous methods with identical signatures and includes additional new methods that provide added functionality.<para/>
    /// The new methods are listed in the header at the end of the section for that interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B51887E8-BCD0-4E8F-A8C7-434398B78C37")]
    [ComImport]
    public interface IDebugHostModule2 : IDebugHostModule
    {
        /// <summary>
        /// The GetContext method returns the context where the symbol is valid. While this will represent things such as the debug target and process/address space in which the symbol exists, it may not be as specific as a context retrieved from other means (e.g.: from an <see cref="IModelObject"/>).
        /// </summary>
        /// <param name="context">The host context in which the symbol is located will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);

        /// <summary>
        /// The EnumerateChildren method returns an enumerator which will enumerate all children of a given symbol. For a C++ type, for example, the base classes, fields, member functions, and the like are all considered children of the type symbol.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <param name="ppEnum">An enumerator which enumerates child symbols of the specified kind and name will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateChildren(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);

        /// <summary>
        /// Gets the kind of symbol that this is (e.g. a field, a base class, a type, etc...).
        /// </summary>
        /// <param name="kind">The kind of symbol (e.g.: a type, field, base class, etc…) will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);

        /// <summary>
        /// Returns the name of the symbol if the symbol has a name. If the symbol does not have a name, an error is returned.
        /// </summary>
        /// <param name="symbolName">The name of the symbol will be returned here as a string allocated via the SysAllocString method. The caller is responsible for freeing the allocated string via the SysFreeString method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);

        /// <summary>
        /// Returns the type (e.g.: "int *") of the symbol if the symbol has a type. If the symbol does not have a type, an error is returned.
        /// </summary>
        /// <param name="type">The type of the symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);

        /// <summary>
        /// Returns the module which contains this symbol if the symbol has a containing module. If the symbol does not have a containing module, an error is returned.
        /// </summary>
        /// <param name="containingModule">The module which contains the symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContainingModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule containingModule);

        /// <summary>
        /// The GetImageName method returns the image name of the module. Depending on the value of the allowPath argument, the returned image name may or may not include the full path to the image.
        /// </summary>
        /// <param name="allowPath">If true, indicates that the full path to the module may be included in the output. Whether such path is or is not included is up to the specific debug host and the manner in which the module was loaded.<para/>
        /// If false, indicates that only the image name of the module will be included in the output.</param>
        /// <param name="imageName">The image name (or full path) of the module will be returned here as an allocated string. The caller is responsible for calling SysFreeString to free the string after use.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetImageName(
            [In, MarshalAs(UnmanagedType.U1)] bool allowPath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string imageName);

        /// <summary>
        /// The GetBaseLocation method returns the base load address of the module as a location structure. The returned location structure for a module will typically refer to a virtual address.
        /// </summary>
        /// <param name="moduleBaseLocation">The loading address of the base of the module in memory is returned here as a location structure. Typically, this refers to a virtual address.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetBaseLocation(
            [Out] out Location moduleBaseLocation);

        /// <summary>
        /// The GetVersion method returns version information about the module (assuming that such information can successfully be read out of the headers).<para/>
        /// If a given version is requested (via a non-nullptr output pointer) and it cannot be read, an appropriate error code will be returned from the method call.
        /// </summary>
        /// <param name="fileVersion">If a non-nullptr address is supplied, the file version of the module will be returned here. If the file version cannot be read from the module headers, this method will fail if a non-nullptr address is provided here.<para/>
        /// If the file version cannot be read from the module headers and this value is provided as nullptr, it will not cause a failure.</param>
        /// <param name="productVersion">If a non-nullptr address is supplied, the product version of the module as indicated in the module headers is returned here.<para/>
        /// If the product version cannot be read from the module headers, this method will fail if a non-nullptr address is provided here.<para/>
        /// If the product version cannot be read from the module headers and this value is provided as nullptr, it will not cause a failure.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetVersion(
            [Out] out long fileVersion,
            [Out] out long productVersion);

        /// <summary>
        /// The FindTypeByName method finds a type defined within the module by the type name and returns a type symbol for it.<para/>
        /// This method may return a valid <see cref="IDebugHostType"/> which would never be returned via explicit recursion of children of the module.<para/>
        /// The debug host may allow creation of derivative types -- types not ever used within the module itself but derived from types that are.<para/>
        /// As an example, if the structure MyStruct is defined in the symbols of the module but the type MyStruct ** is never used, the FindTypeByName method may legitimately return a type symbol for MyStruct ** despite that type name never explicitly appearing in the symbols for the module.<para/>
        /// Many debug hosts will make an explicit attempt to contextualize the type name which is passed to the FindTypeByName method and find a matching type within the symbolic information according to the rules of the language and not a raw comparison against symbol names.<para/>
        /// In the event that a debug host is unable to do this, it will fall back to raw comparison against symbol names.
        /// </summary>
        /// <param name="typeName">The language type to find in the symbolic information for the module. The type may also be derived from (e.g.: be a pointer to or an array of) a type found in the symbolic information of the module.</param>
        /// <param name="type">A type symbol for the found type will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT FindTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <param name="symbol">The found symbol will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT FindSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);

        /// <summary>
        /// The FindSymbolByName method will find a single global symbol of the given name within the module. If there is not a single symbol matching the given name, an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="symbolName">The name of the symbol to locate within the symbolic information for the module.</param>
        /// <param name="symbol">The found symbol will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);

        /// <summary>
        /// Compares two symbols for equality. A host is under no obligation to ensure that there is interface pointer equality for two identical symbols.<para/>
        /// This can be used to check for equality. Note that presently, "comparisonFlags" is reserved.
        /// </summary>
        /// <param name="pComparisonSymbol">The symbol to compare against.</param>
        /// <param name="comparisonFlags">Reserved. Must be set to 0.</param>
        /// <param name="pMatches">An indication of whether the symbols are equal will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <param name="symbol">The found symbol will be returned here.</param>
        /// <param name="offset">The offset value.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT FindContainingSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out] out long offset);
    }
}
