using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION. Defines a translation from one address space to another (e.g.: the translation of virtual addresses to physical addresses by a target or by interpretation of the page tables of a target).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("56373E0F-D615-487F-95B9-37931E2A9A90")]
    [ComImport]
    public interface ISvcMemoryTranslation
    {
        /// <summary>
        /// Translates an address from one address space to another. A service which provides virtual to physical memory mappings would implement this interface to do so.<para/>
        /// The following special error codes may be returned from this method HR_TRANSLATION_NOT_PRESENT The address specified by the 'Offset' argument is not present in the target address space.<para/>
        /// If there is a PTE for the address, its value is returned in TranslationEntry. Such may be queried against the page table reader service which can attempt to read the page data from a compressed memory store or from the page file.<para/>
        /// If there is a "translation entry" (e.g.: PTE) for the given address, it is returned in the 'TranslationEntry' output argument.<para/>
        /// If not, such is set to zero at the exit of the method.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long offset,
            [In] long contiguousByteCount,
            [Out] out long translatedOffset,
            [Out] out long translatedContiguousByteCount,
            [Out] out long translationEntry);
    }
}
