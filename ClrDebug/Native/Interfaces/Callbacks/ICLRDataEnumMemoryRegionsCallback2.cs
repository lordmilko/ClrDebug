using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3721A26F-8B91-4D98-A388-DB17B356FADB")]
    [ComImport]
    public interface ICLRDataEnumMemoryRegionsCallback2 : ICLRDataEnumMemoryRegionsCallback
    {
        /// <summary>
        /// Called by <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        /// <param name="address">[in] The starting address of the memory region that was to be enumerated.</param>
        /// <param name="size">[in] The size, in bytes, of the memory region.</param>
        /// <remarks>
        /// The <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> method will call this callback method after each attempt to enumerate
        /// a memory region. The enumeration will continue even if this method returns an <see cref="HRESULT"/> indicating failure. Regions
        /// reported by this callback may be duplicates or overlapping regions.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT EnumMemoryRegion([In] CLRDATA_ADDRESS address, [In] int size);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateMemoryRegion([In] CLRDATA_ADDRESS address, [In] int bufferSize, [In] IntPtr buffer);
    }
}