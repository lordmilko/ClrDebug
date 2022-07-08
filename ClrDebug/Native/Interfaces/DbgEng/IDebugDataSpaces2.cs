using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7a5e852f-96e9-468f-ac1b-0b3addc4a049")]
    [ComImport]
    public interface IDebugDataSpaces2 : IDebugDataSpaces
    {
        #region IDebugDataSpaces

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
        new HRESULT ReadVirtual(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WriteVirtual(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] IntPtr Pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

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
        new HRESULT ReadVirtualUncached(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WriteVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);

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
        new HRESULT WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Ptrs);

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
        new HRESULT ReadPhysical(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WritePhysical(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

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
        new HRESULT WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);

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
        new HRESULT ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
        new HRESULT WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

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
        new HRESULT CheckLowMemory();

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
        new HRESULT ReadDebuggerData(
            [In] uint Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

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
        new HRESULT ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        #endregion
        #region IDebugDataSpaces2

        /// <summary>
        /// The VirtualToPhysical method translates a location in the target's virtual address space into a physical memory address.
        /// </summary>
        /// <param name="Virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <param name="Physical">[out] Receives the physical memory address.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT VirtualToPhysical(
            [In] ulong Virtual,
            [Out] out ulong Physical);

        /// <summary>
        /// The GetVirtualTranslationPhysicalOffsets method returns the physical addresses of the system paging structures at different levels of the paging hierarchy.
        /// </summary>
        /// <param name="Virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <param name="Offsets">[out, optional] Receives the physical addresses for the system paging structures. If it is set to NULL, this information is not returned.</param>
        /// <param name="OffsetsSize">[in] Specifies the number of elements the array Offsets holds. This is the maximum number of addresses that will be returned.</param>
        /// <param name="Levels">[out, optional] Receives the number of levels in the paging hierarchy for the specified address. If this is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. Translating a virtual address to a physical address requires
        /// Windows to walk down the paging hierarchy. At each level it reads paging information from physical memory. This
        /// method returns the offsets for these physical pages. The number of levels in the paging hierarchy may be different
        /// for different addresses. The address at the last level of the hierarchy is the physical address corresponding to
        /// the specified virtual address. This is what <see cref="VirtualToPhysical"/> would return. For details on how virtual
        /// addresses are translated into physical addresses, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        [PreserveSig]
        HRESULT GetVirtualTranslationPhysicalOffsets(
            [In] ulong Virtual,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Offsets,
            [In] uint OffsetsSize,
            [Out] out uint Levels);

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <param name="Handle">[in] Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="DataType">[in] Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="Buffer">[out, optional] Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="DataSize">[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadHandleData(
            [In] ulong Handle,
            [In] DEBUG_HANDLE_DATA_TYPE DataType,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="Start">[in] Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="Size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="Buffer">[in] Specifies the memory location of the pattern.</param>
        /// <param name="PatternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <param name="Filled">[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        [PreserveSig]
        HRESULT FillVirtual(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="Start">[in] Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="Size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="Buffer">[in] Specifies the pattern to write.</param>
        /// <param name="PatternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <param name="Filled">[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        [PreserveSig]
        HRESULT FillPhysical(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        /// The QueryVirtual method provides information about the specified pages in the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the pages whose information is requested.</param>
        /// <param name="Info">[out] Receives the information about the memory page.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may not work in all sessions. This method returns attributes for a range of pages. This range is determined
        /// by Windows; it begins at the specified page, and includes all subsequent pages with the same attributes. The size
        /// of the range is given by the RegionSize field of the structure returned in Info. MEMORY_BASIC_INFORMATION64 appears
        /// in the Microsoft Windows SDK header file winnt.h. It is the 64-bit equivalent of MEMORY_BASIC_INFORMATION, which
        /// is described in the Windows SDK documentation. This method behaves in a similar way to the Windows SDK function
        /// VirtualQuery. See Windows SDK documentation for details.
        /// </remarks>
        [PreserveSig]
        HRESULT QueryVirtual(
            [In] ulong Offset,
            [Out] IntPtr Info); //MEMORY_BASIC_INFORMATION64

        #endregion
    }
}
