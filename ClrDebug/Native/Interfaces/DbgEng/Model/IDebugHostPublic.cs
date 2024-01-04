using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a public symbol (address/name only). Represents a symbol within the publics table of a PDB.<para/>
    /// This does not have type information associated with it. It is a name and address.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6C597AC9-FB4D-4F6D-9F39-22488539F8F4")]
    [ComImport]
    public interface IDebugHostPublic : IDebugHostSymbol
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
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
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
        /// The GetLocationKind method returns what kind of location the symbol is at according to the LocationKind enumeration.<para/>
        /// The description of this enumeration can be found in the documentation for <see cref="IDebugHostField"/>.
        /// </summary>
        /// <param name="locationKind">The kind of location for this field will be returned here as a value of the LocationKind enumeration.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetLocationKind(
            [Out] out LocationKind locationKind);

        /// <summary>
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.<para/>
        /// If the given public does not have a static location, the GetLocation method will fail.
        /// </summary>
        /// <param name="location">The abstract location (e.g.: address) of the data will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetLocation(
            [Out] out Location location);
    }
}
