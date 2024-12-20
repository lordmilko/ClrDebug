using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_VIRTUAL_MEMORY. DEBUG_SERVICE_PHYSICAL_MEMORY DEBUG_SERVICE_VIRTUAL_MEMORY_UNCACHED DEBUG_SERVICE_PHYSICAL_MEMORY_UNCACHED DEBUG_SERVICE_VIRTUAL_MEMORY_TRANSLATED Defines a means of access to an address space -- physical, virtual, cached, or uncached.<para/>
    /// The exact semantics of the interface depend on what service was queried for ISvcMemoryAccess.
    /// </summary>
    public class SvcMemoryAccess : ComObject<ISvcMemoryAccess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMemoryAccess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMemoryAccess(ISvcMemoryAccess raw) : base(raw)
        {
        }

        #region ISvcMemoryAccess
        #region ReadMemory

        /// <summary>
        /// Reads a series of bytes from the memory type this interface represents in the address space given by the first argument.<para/>
        /// Nearly every target will have some concept of address context (processor, process address space, etc...) that must be passed to this method.<para/>
        /// Some (e.g.: image targets) may choose not to represent any "address context". It is the responsibility of the service to ensure it has an appropriate context if needed.<para/>
        /// This method will return S_FALSE if a partial read is successful and S_OK if a full read occurs. In the case of a partial read, the 'BytesRead' argument will be set to the number of bytes actually read.
        /// </summary>
        public long ReadMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize)
        {
            long bytesRead;
            TryReadMemory(addressContext, offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOK();

            return bytesRead;
        }

        /// <summary>
        /// Reads a series of bytes from the memory type this interface represents in the address space given by the first argument.<para/>
        /// Nearly every target will have some concept of address context (processor, process address space, etc...) that must be passed to this method.<para/>
        /// Some (e.g.: image targets) may choose not to represent any "address context". It is the responsibility of the service to ensure it has an appropriate context if needed.<para/>
        /// This method will return S_FALSE if a partial read is successful and S_OK if a full read occurs. In the case of a partial read, the 'BytesRead' argument will be set to the number of bytes actually read.
        /// </summary>
        public HRESULT TryReadMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize, out long bytesRead)
        {
            /*HRESULT ReadMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesRead);*/
            return Raw.ReadMemory(addressContext, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteMemory

        /// <summary>
        /// Writes a series of bytes to the memory type this interface represents in the address space given by the first argument.<para/>
        /// This method will return S_FALSE if a partial write is successful and S_OK if a full write occurs. In the case of a partial write, the 'BytesWritten' argument will be set to the number of bytes actually written.
        /// </summary>
        public long WriteMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize)
        {
            long bytesWritten;
            TryWriteMemory(addressContext, offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// Writes a series of bytes to the memory type this interface represents in the address space given by the first argument.<para/>
        /// This method will return S_FALSE if a partial write is successful and S_OK if a full write occurs. In the case of a partial write, the 'BytesWritten' argument will be set to the number of bytes actually written.
        /// </summary>
        public HRESULT TryWriteMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize, out long bytesWritten)
        {
            /*HRESULT WriteMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesWritten);*/
            return Raw.WriteMemory(addressContext, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #endregion
    }
}
