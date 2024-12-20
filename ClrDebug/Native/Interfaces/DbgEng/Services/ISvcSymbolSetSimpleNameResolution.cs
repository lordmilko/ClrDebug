using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the mapping of symbol names to addresses within the image and vice-versa.<para/>
    /// All symbol sets are required to support this basic level of symbol resolution. Interfaces beyond this are optional depending on the capabilities of the provider.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("733177E7-9C18-46B7-8D00-3D50A9119FC3")]
    [ComImport]
    public interface ISvcSymbolSetSimpleNameResolution
    {
        /// <summary>
        /// Finds symbolic information for a given name. The method fails if the symbol cannot be located.
        /// </summary>
        [PreserveSig]
        HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol);

        /// <summary>
        /// Finds symbolic information for a given offset. If the "exactMatchOnly" parameter is true, this will only return a symbol which is exactly at the offset given.<para/>
        /// If the "exactMatchOnly" parameter is false, this will return the closest symbol before the given offset. If no such symbol can be found, the method fails.<para/>
        /// Note that if a given symbol (e.g.: a function) has multiple disjoint address ranges and one of those address ranges has been moved to *BELOW* the base address of the symbol, the returned "symbolOffset" may be interpreted as a signed value (and S_FALSE should be returned in such a case).<para/>
        /// This can be confirmed by querying the symbol for its address ranges.
        /// </summary>
        [PreserveSig]
        HRESULT FindSymbolByOffset(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.U1)] bool exactMatchOnly,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol,
            [Out] out long symbolOffset);
    }
}
