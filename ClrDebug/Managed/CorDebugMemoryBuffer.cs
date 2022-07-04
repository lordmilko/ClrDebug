using System;

namespace ClrDebug
{
    /// <summary>
    /// Represents an in-memory buffer.
    /// </summary>
    public class CorDebugMemoryBuffer : ComObject<ICorDebugMemoryBuffer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugMemoryBuffer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugMemoryBuffer(ICorDebugMemoryBuffer raw) : base(raw)
        {
        }

        #region ICorDebugMemoryBuffer
        #region StartAddress

        /// <summary>
        /// Gets the starting address of the memory buffer.
        /// </summary>
        public IntPtr StartAddress
        {
            get
            {
                IntPtr address;
                TryGetStartAddress(out address).ThrowOnNotOK();

                return address;
            }
        }

        /// <summary>
        /// Gets the starting address of the memory buffer.
        /// </summary>
        /// <param name="address">[out] A pointer to the starting address of the memory buffer.</param>
        public HRESULT TryGetStartAddress(out IntPtr address)
        {
            /*HRESULT GetStartAddress([Out] out IntPtr address);*/
            return Raw.GetStartAddress(out address);
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of the memory buffer in bytes.
        /// </summary>
        public int Size
        {
            get
            {
                int pcbBufferLength;
                TryGetSize(out pcbBufferLength).ThrowOnNotOK();

                return pcbBufferLength;
            }
        }

        /// <summary>
        /// Gets the size of the memory buffer in bytes.
        /// </summary>
        /// <param name="pcbBufferLength">[out] A pointer to the size of the memory buffer.</param>
        public HRESULT TryGetSize(out int pcbBufferLength)
        {
            /*HRESULT GetSize([Out] out int pcbBufferLength);*/
            return Raw.GetSize(out pcbBufferLength);
        }

        #endregion
        #endregion
    }
}
