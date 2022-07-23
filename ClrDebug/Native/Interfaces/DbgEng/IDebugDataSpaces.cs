using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa")]
    [ComImport]
    public interface IDebugDataSpaces
    {
        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="Buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// may reference a cache of memory data when retrieving data. If the data is volatile, such as memory-mapped hardware
        /// state, use <see cref="ReadVirtualUncached"/> instead. When reading memory that contains pointers, these pointers
        /// are for the target's virtual address space and not the engine's. For example, if a data structure contained a string,
        /// a second call to this method may be needed to read the contents of the string.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadVirtual(
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="Buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method may only write to
        /// a cache of memory data when storing data. To avoid caching, use <see cref="WriteVirtualUncached"/> instead.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteVirtual(
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="Length">[in] Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="Pattern">[in] Specifies the pattern to search for.</param>
        /// <param name="PatternSize">[in] Specifies the size in bytes of the pattern. This must be a multiple of the granularity of the pattern.</param>
        /// <param name="PatternGranularity">[in] Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <param name="MatchOffset">[out] Receives the location in the target's virtual address space of the pattern, if it was found.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method searches the target's virtual memory for the first occurrence, subject to granularity, of the pattern
        /// entirely contained in the Length bytes of the target's memory starting at the location Offset. PatternGranularity
        /// can be used to ensure the alignment of the match relative to Offset. For example, a value of 0x4 can be used to
        /// require alignment to a DWORD. A value of 0x1 can be used to allow the pattern to start anywhere. For additional
        /// options, including the ability to restrict the search to writable memory, see <see cref="IDebugDataSpaces4.SearchVirtual2"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT SearchVirtual(
            [In] long Offset,
            [In] long Length,
            [In] IntPtr Pattern,
            [In] int PatternSize,
            [In] int PatternGranularity,
            [Out] out long MatchOffset);

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="Buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// behaves identically to <see cref="ReadVirtual"/>, except that it avoids using the virtual memory cache. It is therefore
        /// useful for reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating
        /// or invalidating the cache.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadVirtualUncached(
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="Buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method behaves identically
        /// to <see cref="WriteVirtual"/>, except that it avoids using the virtual memory cache. It is therefore useful for
        /// reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating or invalidating
        /// the cache.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteVirtualUncached(
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The ReadPointersVirtual method is a convenience method for reading pointers from the target's virtual address space.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of pointers to read.</param>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space to start reading the pointers.</param>
        /// <param name="Ptrs">[out] Specifies the array to store the pointers. The number of elements this array holds is Count.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method reads from the memory from the target's virtual address space. The memory is then treated as a list
        /// of pointers. Any 32-bit pointers are then sign-extended to 64-bit values.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadPointersVirtual(
            [In] int Count,
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] Ptrs);

        /// <summary>
        /// The WritePointersVirtual method is a convenience method for writing pointers to the target's virtual address space.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of pointers to write.</param>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space at which to start writing the pointers.</param>
        /// <param name="Ptrs">[in] Specifies the array of pointers to write. The number of elements in this array is Count.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the target uses 32-bit pointers, this method casts the specified 64-bit values into 32-bit pointers. Then it
        /// writes these pointers to the target's memory.
        /// </remarks>
        [PreserveSig]
        HRESULT WritePointersVirtual(
            [In] int Count,
            [In] long Offset,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] Ptrs);

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="Offset">[in] Specifies the physical address of the memory to read.</param>
        /// <param name="Buffer">[out] Receives the memory that is read.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes read from the target's memory. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadPhysical(
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the physical address of the memory to write the data to.</param>
        /// <param name="Buffer">[in] Specifies the data to write.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT WritePhysical(
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <param name="Processor">[in] Specifies the processor whose information is to be read.</param>
        /// <param name="Offset">[in] Specifies the offset in the control space of the memory to read.</param>
        /// <param name="Buffer">[out] Receives the data read from the control-space memory.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadControl(
            [In] int Processor,
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <param name="Processor">[in] Specifies the processor whose information is to be written.</param>
        /// <param name="Offset">[in] Specifies the offset of the control space of the memory to write.</param>
        /// <param name="Buffer">[in] Specifies the data to write to the control-space memory.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteControl(
            [In] int Processor,
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <param name="InterfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="BusNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="AddressSpace">[in] This parameter must be equal to one.</param>
        /// <param name="Offset">[in] Specifies the I/O address within the address space.</param>
        /// <param name="Buffer">[out] Receives the data read from the I/O bus.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read. At present, this must be 1, 2, or 4.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes returned read from the I/O bus. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] int BusNumber,
            [In] int AddressSpace,
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <param name="InterfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="BusNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="AddressSpace">[in] Set to one.</param>
        /// <param name="Offset">[in] Specifies the location of the requested data.</param>
        /// <param name="Buffer">[in] Specifies the data to write to the I/O bus.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] int BusNumber,
            [In] int AddressSpace,
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The ReadMsr method reads a specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="Msr">[in] Specifies the MSR address.</param>
        /// <param name="MsrValue">[out] Receives the value of the MSR.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadMsr(
            [In] int Msr,
            [Out] out long MsrValue);

        /// <summary>
        /// The WriteMsr method writes a value to the specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="Msr">Specifies the MSR address.</param>
        /// <param name="MsrValue">Specifies the value to write to the MSR.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteMsr(
            [In] int Msr,
            [In] long MsrValue);

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <param name="BusDataType">[in] Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="BusNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="SlotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="Offset">[in] Specifies the offset in the bus data to start reading from.</param>
        /// <param name="Buffer">[out] Receives the data from the bus.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes read from the bus. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] int BusNumber,
            [In] int SlotNumber,
            [In] int Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <param name="BusDataType">[in] Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="BusNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="SlotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="Offset">[in] Specifies the offset in the bus data to start writing to.</param>
        /// <param name="Buffer">[in] Specifies the data to write to the bus.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] int BusNumber,
            [In] int SlotNumber,
            [In] int Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The CheckLowMemory method checks for memory corruption in the low 4 GB of memory.
        /// </summary>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging, and is only useful when the kernel was booted using the
        /// /nolowmem option. When the kernel is booted with the /nolowmem option, the kernel, drivers, operating system and
        /// applications are loaded in memory above 4 GB, while the low 4 GB of memory is filled with a unique pattern. The
        /// CheckLowMemory method checks this pattern for corruption. This may be used to verify that a driver behaves well
        /// when using physical addresses greater than 32 bits in length. See Physical Address Extension (PAE), /pae, and /nolowmem
        /// in the Windows Driver Kit.
        /// </remarks>
        [PreserveSig]
        HRESULT CheckLowMemory();

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="Buffer">[out] Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer.</param>
        /// <param name="DataSize">[out, optional] Receives the number of bytes used in the buffer Buffer. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some or all of the values may be unavailable in certain debugging sessions. For example, some of the values are
        /// only available for particular versions of the operating system. For details on the different values returned by
        /// ReadDebuggerData, see Microsoft Windows Internals by David Solomon and Mark Russinovich, the Microsoft Windows
        /// SDK, and the Windows Driver Kit (WDK).
        /// </remarks>
        [PreserveSig]
        HRESULT ReadDebuggerData(
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int DataSize);

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <param name="Processor">[in] Specifies the processor whose data is to be read.</param>
        /// <param name="Index">[in] Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="Buffer">[out] Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="DataSize">[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For information about the PCR, PRCB, and KTHREAD structures,
        /// as well as information about paging tables, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadProcessorSystemData(
            [In] int Processor,
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int DataSize);
    }
}
