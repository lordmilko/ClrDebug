using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents an abstract set of symbols. This may represent all symbols in a PDB. It may represent the "export symbols" of an image.<para/>
    /// It may represent a subset of the symbols in a PDB. There is no requirement that a symbol set represent a single "file".<para/>
    /// It may represent, in aggregate, multiple sources of symbolic information for a given set of functionality (often represented by an image).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FA683AF-06AA-484D-87CF-137C1EA016BD")]
    [ComImport]
    public interface ISvcSymbolSet
    {
        /// <summary>
        /// Returns the symbol for a given symbol ID (returned by ISvcSymbol::GetId).
        /// </summary>
        [PreserveSig]
        HRESULT GetSymbolById(
            [In] long symbolId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppSymbol);

        /// <summary>
        /// Enumerates all symbols in the set.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateAllSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator ppEnumerator);
    }
}
