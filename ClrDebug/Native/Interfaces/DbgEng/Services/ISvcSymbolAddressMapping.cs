using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which has an address mapping (e.g.: code symbols, functions, lexical blocks, etc...) which can be described by one or more ranges implements this interface.<para/>
    /// This interface does *NOT* represent locations for things like variables which describe enregistered or register relative locations.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D2513438-18DA-4360-8242-49E0638FB2A4")]
    [ComImport]
    public interface ISvcSymbolAddressMapping
    {
        /// <summary>
        /// Gets the base address range of this symbol. If the symbol is defined by a **SINGLE** linear address range, this method *MUST* return such address range and S_OK.<para/>
        /// If the symbol is defined by **MULTIPLE** linear address ranges (e.g.: a BBT'd or otherwise such optimized function), this method *MUST* return the base address range and S_FALSE.<para/>
        /// In either case, EnumerateAddressRanges() includes **ALL** address ranges of the symbol.
        /// </summary>
        [PreserveSig]
        HRESULT GetAddressRange(
            [Out] out SvcAddressRange addressRange);

        /// <summary>
        /// Enumerates the set of address ranges which define this symbol.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator rangeEnum);
    }
}
