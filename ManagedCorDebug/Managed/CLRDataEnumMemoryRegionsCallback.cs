using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a callback method for <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
    /// </summary>
    public class CLRDataEnumMemoryRegionsCallback : ComObject<ICLRDataEnumMemoryRegionsCallback>
    {
        public CLRDataEnumMemoryRegionsCallback(ICLRDataEnumMemoryRegionsCallback raw) : base(raw)
        {
        }

        #region ICLRDataEnumMemoryRegionsCallback
        #region EnumMemoryRegion

        /// <summary>
        /// Called by <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        /// <param name="address">[in] The starting address of the memory region that was to be enumerated.</param>
        /// <param name="size">[in] The size, in bytes, of the memory region.</param>
        /// <remarks>
        /// The <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> method will call this callback method after each attempt to enumerate
        /// a memory region. The enumeration will continue even if this method returns an <see cref="HRESULT"/> indicating failure. Regions
        /// reported by this callback may be duplicates or overlapping regions.
        /// </remarks>
        public void EnumMemoryRegion(CLRDATA_ADDRESS address, int size)
        {
            HRESULT hr;

            if ((hr = TryEnumMemoryRegion(address, size)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Called by <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        /// <param name="address">[in] The starting address of the memory region that was to be enumerated.</param>
        /// <param name="size">[in] The size, in bytes, of the memory region.</param>
        /// <remarks>
        /// The <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> method will call this callback method after each attempt to enumerate
        /// a memory region. The enumeration will continue even if this method returns an <see cref="HRESULT"/> indicating failure. Regions
        /// reported by this callback may be duplicates or overlapping regions.
        /// </remarks>
        public HRESULT TryEnumMemoryRegion(CLRDATA_ADDRESS address, int size)
        {
            /*HRESULT EnumMemoryRegion([In] CLRDATA_ADDRESS address, [In] int size);*/
            return Raw.EnumMemoryRegion(address, size);
        }

        #endregion
        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICLRDataEnumMemoryRegionsCallback2 Raw2 => (ICLRDataEnumMemoryRegionsCallback2) Raw;

        #region UpdateMemoryRegion

        public void UpdateMemoryRegion(CLRDATA_ADDRESS address, int bufferSize, IntPtr buffer)
        {
            HRESULT hr;

            if ((hr = TryUpdateMemoryRegion(address, bufferSize, buffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateMemoryRegion(CLRDATA_ADDRESS address, int bufferSize, IntPtr buffer)
        {
            /*HRESULT UpdateMemoryRegion([In] CLRDATA_ADDRESS address, [In] int bufferSize, [In] IntPtr buffer);*/
            return Raw2.UpdateMemoryRegion(address, bufferSize, buffer);
        }

        #endregion
        #endregion
    }
}