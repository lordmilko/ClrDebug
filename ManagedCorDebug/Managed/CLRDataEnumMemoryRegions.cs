using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDataEnumMemoryRegions : ComObject<ICLRDataEnumMemoryRegions>
    {
        public CLRDataEnumMemoryRegions(ICLRDataEnumMemoryRegions raw) : base(raw)
        {
        }

        #region ICLRDataEnumMemoryRegions
        #region EnumMemoryRegions

        public void EnumMemoryRegions(ICLRDataEnumMemoryRegionsCallback callback, uint miniDumpFlags, CLRDataEnumMemoryFlags clrFlags)
        {
            HRESULT hr;

            if ((hr = TryEnumMemoryRegions(callback, miniDumpFlags, clrFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnumMemoryRegions(ICLRDataEnumMemoryRegionsCallback callback, uint miniDumpFlags, CLRDataEnumMemoryFlags clrFlags)
        {
            /*HRESULT EnumMemoryRegions(
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDataEnumMemoryRegionsCallback callback,
            [In] uint miniDumpFlags,
            [In] CLRDataEnumMemoryFlags clrFlags);*/
            return Raw.EnumMemoryRegions(callback, miniDumpFlags, clrFlags);
        }

        #endregion
        #endregion
    }
}