using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4D7D798-A4C1-40AD-9235-B80F0BF8E2AD")]
    [ComImport]
    public interface ISvcAddressRangeEnumeration
    {
        /// <summary>
        /// Enumerates a set of address ranges which define a memory layout. For modules Enumerates the set of address ranges which define the memory layout of the module.<para/>
        /// The first enumerated range *MUST* be the range returned from GetBaseAddress() and GetSize() for the module. It is legal for this method to return E_NOTIMPL for modules which are defined by a contiguous linear range of addresses [baseAddress, baseAddress + size).<para/>
        /// Any module which is defined by more than one range *MUST* return the *LOWEST* address range in GetBaseAddress() and GetSize() and must return S_FALSE from those two methods.<para/>
        /// Likewise, the implementation of the module enumeration service should be able to map any address returned here to the given module.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator ppEnum);
    }
}
