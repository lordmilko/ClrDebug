using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mechanism by which an abstract "symbol set" is located for a given module. An abstract "symbol set" is described by an ISvcSymbolSet.<para/>
    /// While a "symbol set" may refer to an arbitrary grouping of symbols, the set returned from the LocateSymbolsForImage method represents the symbolic (debug) information for a given image in some address space.<para/>
    /// That symbol set may be backed by a PDB, the "export symbols" of the image, some side description of the symbolic information, or simply be an abstraction materialized out of thin air.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("23ED1044-166C-4C62-91FC-B5656E4A74EF")]
    [ComImport]
    public interface ISvcSymbolProvider
    {
        /// <summary>
        /// For a given image (identified by an ISvcModule), find the set of symbolic information available for the image and return a symbol set.
        /// </summary>
        [PreserveSig]
        HRESULT LocateSymbolsForImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);
    }
}
