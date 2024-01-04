using System;

namespace ClrDebug.DbgEng
{
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

        public long ReadMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize)
        {
            long bytesRead;
            TryReadMemory(addressContext, offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOK();

            return bytesRead;
        }

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

        public long WriteMemory(ISvcAddressContext addressContext, long offset, IntPtr buffer, long bufferSize)
        {
            long bytesWritten;
            TryWriteMemory(addressContext, offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

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
