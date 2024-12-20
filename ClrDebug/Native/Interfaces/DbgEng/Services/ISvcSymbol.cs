using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7947495F-383B-49C7-B1C5-1F959DD99D09")]
    [ComImport]
    public interface ISvcSymbol
    {
        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        [PreserveSig]
        HRESULT GetSymbolKind(
            [Out] out SvcSymbolKind kind);

        /// <summary>
        /// Gets the name of the symbol (e.g.: MyMethod).
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);

        /// <summary>
        /// Gets the qualified name of the symbol (e.g.: MyNamespace::MyClass::MyMethod).
        /// </summary>
        [PreserveSig]
        HRESULT GetQualifiedName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string qualifiedName);

        /// <summary>
        /// Gets an identifier for the symbol which can be used to retrieve the same symbol again. The identifier is opaque and has semantics only to the underlying symbol set.
        /// </summary>
        [PreserveSig]
        HRESULT GetId(
            [Out] out long value);

        /// <summary>
        /// Gets the offset of the symbol (if said symbol has such). Note that if the symbol has multiple disjoint address ranges associated with it, this method may return S_FALSE to indicate that the symbol does not necessarily have a simple "base address" for an offset.
        /// </summary>
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out long symbolOffset);
    }
}
