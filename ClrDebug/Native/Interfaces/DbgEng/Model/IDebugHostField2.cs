﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("99468A0B-EA92-4BD4-9EFE-A266160578CA")]
    [ComImport]
    public interface IDebugHostField2 : IDebugHostField
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
        /// <param name="kind">The kind of symbol (e.g.: a type, field, base class, etc…) will be returned here. For more information, see <see cref="SymbolKind"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);

        /// <summary>
        /// Returns the name of the symbol if the symbol has a name. If the symbol does not have a name, an error is returned.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);

        /// <summary>
        /// Returns the type (e.g.: "int *") of the symbol if the symbol has a type. If the symbol does not have a type, an error is returned.
        /// </summary>
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
        /// The GetLocationKind method returns what kind of location the symbol is at according to the LocationKind enumeration.<para/>
        /// The description of this enumeration can be found in the documentation for <see cref="IDebugHostField"/>.
        /// </summary>
        /// <param name="locationKind">The kind of location for this field will be returned here as a value of the LocationKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetLocationKind(
            [Out] out LocationKind locationKind);

        /// <summary>
        /// The GetOffset method returns the offset of the base class from the base address of the derived class. Such offset may be zero or may be a positive unsigned 64-bit value.
        /// </summary>
        /// <param name="offset">The offset of the base class from the base address of the derived class is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetOffset(
            [Out] out long offset);

        /// <summary>
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.If the given data does not have a static location, the GetLocation method will fail.
        /// </summary>
        /// <param name="location">The abstract location (e.g.: address) of the data will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetLocation(
            [Out] out Location location);

        /// <summary>
        /// The GetValue method returns the value of the constant packed into a VARIANT. It is important to note that the GetType method on <see cref="IDebugHostSymbol"/> may return a specific type symbol for the constant.<para/>
        /// In such cases, there is no guarantee that the packing of the constant value as defined by the type symbol is the same as the packing as returned by the GetValue method here.
        /// </summary>
        /// <param name="value">The value of the data packed into a VARIANT will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object value);

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
        
        [PreserveSig]
        HRESULT GetContainingType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType3 containingParentType);
    }
}
