using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDataEnumMemoryRegionsCallback : ComObject<ICLRDataEnumMemoryRegionsCallback>
    {
        public CLRDataEnumMemoryRegionsCallback(ICLRDataEnumMemoryRegionsCallback raw) : base(raw)
        {
        }

        #region ICLRDataEnumMemoryRegionsCallback
        #region EnumMemoryRegion

        public void EnumMemoryRegion(ulong address, uint size)
        {
            HRESULT hr;

            if ((hr = TryEnumMemoryRegion(address, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnumMemoryRegion(ulong address, uint size)
        {
            /*HRESULT EnumMemoryRegion([In] ulong address, [In] uint size);*/
            return Raw.EnumMemoryRegion(address, size);
        }

        #endregion
        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2

        public ICLRDataEnumMemoryRegionsCallback2 Raw2 => (ICLRDataEnumMemoryRegionsCallback2) Raw;

        #region UpdateMemoryRegion

        public void UpdateMemoryRegion(ulong address, uint bufferSize, IntPtr buffer)
        {
            HRESULT hr;

            if ((hr = TryUpdateMemoryRegion(address, bufferSize, buffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateMemoryRegion(ulong address, uint bufferSize, IntPtr buffer)
        {
            /*HRESULT UpdateMemoryRegion([In] ulong address, [In] uint bufferSize, [In] IntPtr buffer);*/
            return Raw2.UpdateMemoryRegion(address, bufferSize, buffer);
        }

        #endregion
        #endregion
    }
}