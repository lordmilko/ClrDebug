using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an in-memory buffer.
    /// </summary>
    public class CorDebugMemoryBuffer : ComObject<ICorDebugMemoryBuffer>
    {
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
                HRESULT hr;
                IntPtr address;

                if ((hr = TryGetStartAddress(out address)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return address;
            }
        }

        /// <summary>
        /// Gets the starting address of the memory buffer.
        /// </summary>
        /// <param name="address">[out] A pointer to the starting address of the memory buffer.</param>
        public HRESULT TryGetStartAddress(out IntPtr address)
        {
            /*HRESULT GetStartAddress(out IntPtr address);*/
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
                HRESULT hr;
                int pcbBufferLength;

                if ((hr = TryGetSize(out pcbBufferLength)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbBufferLength;
            }
        }

        /// <summary>
        /// Gets the size of the memory buffer in bytes.
        /// </summary>
        /// <param name="pcbBufferLength">[out] A pointer to the size of the memory buffer.</param>
        public HRESULT TryGetSize(out int pcbBufferLength)
        {
            /*HRESULT GetSize(out int pcbBufferLength);*/
            return Raw.GetSize(out pcbBufferLength);
        }

        #endregion
        #endregion
    }
}