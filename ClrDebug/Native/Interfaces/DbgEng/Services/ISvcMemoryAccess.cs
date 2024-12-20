using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By:
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY
    ///     DEBUG_SERVICE_PHYSICAL_MEMORY
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY_UNCACHED
    ///     DEBUG_SERVICE_PHYSICAL_MEMORY_UNCACHED
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY_TRANSLATED
    ///
    /// Defines a means of access to an address space -- physical, virtual, cached, or uncached.<para/>
    /// The exact semantics of the interface depend on what service was queried for ISvcMemoryAccess.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7D42C7D1-B9D3-4DDF-B9F9-05694F013B86")]
    [ComImport]
    public interface ISvcMemoryAccess
    {
        /// <summary>
        /// Reads a series of bytes from the memory type this interface represents in the address space given by the first argument.<para/>
        /// Nearly every target will have some concept of address context (processor, process address space, etc...) that must be passed to this method.<para/>
        /// Some (e.g.: image targets) may choose not to represent any "address context". It is the responsibility of the service to ensure it has an appropriate context if needed.<para/>
        /// This method will return S_FALSE if a partial read is successful and S_OK if a full read occurs. In the case of a partial read, the 'BytesRead' argument will be set to the number of bytes actually read.
        /// </summary>
        [PreserveSig]
        HRESULT ReadMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesRead);

        /// <summary>
        /// Writes a series of bytes to the memory type this interface represents in the address space given by the first argument.<para/>
        /// This method will return S_FALSE if a partial write is successful and S_OK if a full write occurs. In the case of a partial write, the 'BytesWritten' argument will be set to the number of bytes actually written.
        /// </summary>
        [PreserveSig]
        HRESULT WriteMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesWritten);
    }
}
