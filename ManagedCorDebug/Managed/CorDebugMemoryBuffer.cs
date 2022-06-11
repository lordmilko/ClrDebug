using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugMemoryBuffer : ComObject<ICorDebugMemoryBuffer>
    {
        public CorDebugMemoryBuffer(ICorDebugMemoryBuffer raw) : base(raw)
        {
        }

        #region ICorDebugMemoryBuffer
        #region GetStartAddress

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

        public HRESULT TryGetStartAddress(out IntPtr address)
        {
            /*HRESULT GetStartAddress(out IntPtr address);*/
            return Raw.GetStartAddress(out address);
        }

        #endregion
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcbBufferLength;

                if ((hr = TryGetSize(out pcbBufferLength)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbBufferLength;
            }
        }

        public HRESULT TryGetSize(out uint pcbBufferLength)
        {
            /*HRESULT GetSize(out uint pcbBufferLength);*/
            return Raw.GetSize(out pcbBufferLength);
        }

        #endregion
        #endregion
    }
}