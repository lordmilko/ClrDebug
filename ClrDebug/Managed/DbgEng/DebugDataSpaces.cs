using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugDataSpaces : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugDataSpaces = new Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugDataSpacesVtbl* Vtbl => (IDebugDataSpacesVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugDataSpaces2Vtbl* Vtbl2 => (IDebugDataSpaces2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugDataSpaces3Vtbl* Vtbl3 => (IDebugDataSpaces3Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugDataSpaces4Vtbl* Vtbl4 => (IDebugDataSpaces4Vtbl*) base.Vtbl;

        #endregion
        
        public DebugDataSpaces(IntPtr raw) : base(raw, IID_IDebugDataSpaces)
        {
        }

        public DebugDataSpaces(IDebugDataSpaces raw) : base(raw)
        {
        }

        #region IDebugDataSpaces
        #region ReadVirtual

        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <returns>[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// may reference a cache of memory data when retrieving data. If the data is volatile, such as memory-mapped hardware
        /// state, use <see cref="ReadVirtualUncached"/> instead. When reading memory that contains pointers, these pointers
        /// are for the target's virtual address space and not the engine's. For example, if a data structure contained a string,
        /// a second call to this method may be needed to read the contents of the string.
        /// </remarks>
        public uint ReadVirtual(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadVirtual(offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// may reference a cache of memory data when retrieving data. If the data is volatile, such as memory-mapped hardware
        /// state, use <see cref="ReadVirtualUncached"/> instead. When reading memory that contains pointers, these pointers
        /// are for the target's virtual address space and not the engine's. For example, if a data structure contained a string,
        /// a second call to this method may be needed to read the contents of the string.
        /// </remarks>
        public HRESULT TryReadVirtual(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readVirtual, Vtbl->ReadVirtual);

            /*HRESULT ReadVirtual(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readVirtual(Raw, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteVirtual

        /// <summary>
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <returns>[out, optional] Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method may only write to
        /// a cache of memory data when storing data. To avoid caching, use <see cref="WriteVirtualUncached"/> instead.
        /// </remarks>
        public uint WriteVirtual(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteVirtual(offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method may only write to
        /// a cache of memory data when storing data. To avoid caching, use <see cref="WriteVirtualUncached"/> instead.
        /// </remarks>
        public HRESULT TryWriteVirtual(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeVirtual, Vtbl->WriteVirtual);

            /*HRESULT WriteVirtual(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeVirtual(Raw, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region SearchVirtual

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">[in] Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="pattern">[in] Specifies the pattern to search for.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern. This must be a multiple of the granularity of the pattern.</param>
        /// <param name="patternGranularity">[in] Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <returns>[out] Receives the location in the target's virtual address space of the pattern, if it was found.</returns>
        /// <remarks>
        /// This method searches the target's virtual memory for the first occurrence, subject to granularity, of the pattern
        /// entirely contained in the Length bytes of the target's memory starting at the location Offset. PatternGranularity
        /// can be used to ensure the alignment of the match relative to Offset. For example, a value of 0x4 can be used to
        /// require alignment to a DWORD. A value of 0x1 can be used to allow the pattern to start anywhere. For additional
        /// options, including the ability to restrict the search to writable memory, see <see cref="SearchVirtual2"/>.
        /// </remarks>
        public ulong SearchVirtual(ulong offset, ulong length, IntPtr pattern, uint patternSize, uint patternGranularity)
        {
            ulong matchOffset;
            TrySearchVirtual(offset, length, pattern, patternSize, patternGranularity, out matchOffset).ThrowDbgEngNotOk();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">[in] Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="pattern">[in] Specifies the pattern to search for.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern. This must be a multiple of the granularity of the pattern.</param>
        /// <param name="patternGranularity">[in] Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <param name="matchOffset">[out] Receives the location in the target's virtual address space of the pattern, if it was found.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method searches the target's virtual memory for the first occurrence, subject to granularity, of the pattern
        /// entirely contained in the Length bytes of the target's memory starting at the location Offset. PatternGranularity
        /// can be used to ensure the alignment of the match relative to Offset. For example, a value of 0x4 can be used to
        /// require alignment to a DWORD. A value of 0x1 can be used to allow the pattern to start anywhere. For additional
        /// options, including the ability to restrict the search to writable memory, see <see cref="SearchVirtual2"/>.
        /// </remarks>
        public HRESULT TrySearchVirtual(ulong offset, ulong length, IntPtr pattern, uint patternSize, uint patternGranularity, out ulong matchOffset)
        {
            InitDelegate(ref searchVirtual, Vtbl->SearchVirtual);

            /*HRESULT SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] IntPtr Pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);*/
            return searchVirtual(Raw, offset, length, pattern, patternSize, patternGranularity, out matchOffset);
        }

        #endregion
        #region ReadVirtualUncached

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <returns>[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// behaves identically to <see cref="ReadVirtual"/>, except that it avoids using the virtual memory cache. It is therefore
        /// useful for reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating
        /// or invalidating the cache.
        /// </remarks>
        public uint ReadVirtualUncached(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadVirtualUncached(offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="buffer">[out] Specifies the buffer to read the memory into.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes that were read. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method fills the buffer with the contents of the memory in the target's virtual address space. This method
        /// behaves identically to <see cref="ReadVirtual"/>, except that it avoids using the virtual memory cache. It is therefore
        /// useful for reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating
        /// or invalidating the cache.
        /// </remarks>
        public HRESULT TryReadVirtualUncached(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readVirtualUncached, Vtbl->ReadVirtualUncached);

            /*HRESULT ReadVirtualUncached(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readVirtualUncached(Raw, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteVirtualUncached

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <returns>[out, optional] Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method behaves identically
        /// to <see cref="WriteVirtual"/>, except that it avoids using the virtual memory cache. It is therefore useful for
        /// reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating or invalidating
        /// the cache.
        /// </remarks>
        public uint WriteVirtualUncached(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteVirtualUncached(offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="buffer">[in] Specifies the buffer to write the memory from.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer. This is also the number of bytes requested to be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the buffer to the memory in the target's virtual address space. This method behaves identically
        /// to <see cref="WriteVirtual"/>, except that it avoids using the virtual memory cache. It is therefore useful for
        /// reading inherently volatile virtual memory, such as memory-mapped device areas, without contaminating or invalidating
        /// the cache.
        /// </remarks>
        public HRESULT TryWriteVirtualUncached(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeVirtualUncached, Vtbl->WriteVirtualUncached);

            /*HRESULT WriteVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeVirtualUncached(Raw, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region ReadPointersVirtual

        /// <summary>
        /// The ReadPointersVirtual method is a convenience method for reading pointers from the target's virtual address space.
        /// </summary>
        /// <param name="count">[in] Specifies the number of pointers to read.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to start reading the pointers.</param>
        /// <returns>[out] Specifies the array to store the pointers. The number of elements this array holds is Count.</returns>
        /// <remarks>
        /// This method reads from the memory from the target's virtual address space. The memory is then treated as a list
        /// of pointers. Any 32-bit pointers are then sign-extended to 64-bit values.
        /// </remarks>
        public ulong[] ReadPointersVirtual(uint count, ulong offset)
        {
            ulong[] ptrs;
            TryReadPointersVirtual(count, offset, out ptrs).ThrowDbgEngNotOk();

            return ptrs;
        }

        /// <summary>
        /// The ReadPointersVirtual method is a convenience method for reading pointers from the target's virtual address space.
        /// </summary>
        /// <param name="count">[in] Specifies the number of pointers to read.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space to start reading the pointers.</param>
        /// <param name="ptrs">[out] Specifies the array to store the pointers. The number of elements this array holds is Count.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method reads from the memory from the target's virtual address space. The memory is then treated as a list
        /// of pointers. Any 32-bit pointers are then sign-extended to 64-bit values.
        /// </remarks>
        public HRESULT TryReadPointersVirtual(uint count, ulong offset, out ulong[] ptrs)
        {
            InitDelegate(ref readPointersVirtual, Vtbl->ReadPointersVirtual);
            /*HRESULT ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);*/
            ptrs = new ulong[(int) count];
            HRESULT hr = readPointersVirtual(Raw, count, offset, ptrs);

            return hr;
        }

        #endregion
        #region WritePointersVirtual

        /// <summary>
        /// The WritePointersVirtual method is a convenience method for writing pointers to the target's virtual address space.
        /// </summary>
        /// <param name="count">[in] Specifies the number of pointers to write.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space at which to start writing the pointers.</param>
        /// <param name="ptrs">[in] Specifies the array of pointers to write. The number of elements in this array is Count.</param>
        /// <remarks>
        /// If the target uses 32-bit pointers, this method casts the specified 64-bit values into 32-bit pointers. Then it
        /// writes these pointers to the target's memory.
        /// </remarks>
        public void WritePointersVirtual(uint count, ulong offset, ulong[] ptrs)
        {
            TryWritePointersVirtual(count, offset, ptrs).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The WritePointersVirtual method is a convenience method for writing pointers to the target's virtual address space.
        /// </summary>
        /// <param name="count">[in] Specifies the number of pointers to write.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space at which to start writing the pointers.</param>
        /// <param name="ptrs">[in] Specifies the array of pointers to write. The number of elements in this array is Count.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the target uses 32-bit pointers, this method casts the specified 64-bit values into 32-bit pointers. Then it
        /// writes these pointers to the target's memory.
        /// </remarks>
        public HRESULT TryWritePointersVirtual(uint count, ulong offset, ulong[] ptrs)
        {
            InitDelegate(ref writePointersVirtual, Vtbl->WritePointersVirtual);

            /*HRESULT WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);*/
            return writePointersVirtual(Raw, count, offset, ptrs);
        }

        #endregion
        #region ReadPhysical

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to read.</param>
        /// <param name="buffer">[out] Receives the memory that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>[out, optional] Receives the number of bytes read from the target's memory. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint ReadPhysical(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadPhysical(offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to read.</param>
        /// <param name="buffer">[out] Receives the memory that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes read from the target's memory. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryReadPhysical(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readPhysical, Vtbl->ReadPhysical);

            /*HRESULT ReadPhysical(
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readPhysical(Raw, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WritePhysical

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to write the data to.</param>
        /// <param name="buffer">[in] Specifies the data to write.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <returns>[out, optional] Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint WritePhysical(ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWritePhysical(offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to write the data to.</param>
        /// <param name="buffer">[in] Specifies the data to write.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryWritePhysical(ulong offset, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writePhysical, Vtbl->WritePhysical);

            /*HRESULT WritePhysical(
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writePhysical(Raw, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region ReadControl

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose information is to be read.</param>
        /// <param name="offset">[in] Specifies the offset in the control space of the memory to read.</param>
        /// <param name="buffer">[out] Receives the data read from the control-space memory.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint ReadControl(uint processor, ulong offset, IntPtr buffer, int bufferSize)
        {
            uint bytesRead;
            TryReadControl(processor, offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose information is to be read.</param>
        /// <param name="offset">[in] Specifies the offset in the control space of the memory to read.</param>
        /// <param name="buffer">[out] Receives the data read from the control-space memory.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryReadControl(uint processor, ulong offset, IntPtr buffer, int bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readControl, Vtbl->ReadControl);

            /*HRESULT ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);*/
            return readControl(Raw, processor, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteControl

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose information is to be written.</param>
        /// <param name="offset">[in] Specifies the offset of the control space of the memory to write.</param>
        /// <param name="buffer">[in] Specifies the data to write to the control-space memory.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <returns>[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint WriteControl(uint processor, ulong offset, IntPtr buffer, int bufferSize)
        {
            uint bytesWritten;
            TryWriteControl(processor, offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose information is to be written.</param>
        /// <param name="offset">[in] Specifies the offset of the control space of the memory to write.</param>
        /// <param name="buffer">[in] Specifies the data to write to the control-space memory.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryWriteControl(uint processor, ulong offset, IntPtr buffer, int bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeControl, Vtbl->WriteControl);

            /*HRESULT WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);*/
            return writeControl(Raw, processor, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region ReadIo

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <param name="interfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">[in] This parameter must be equal to one.</param>
        /// <param name="offset">[in] Specifies the I/O address within the address space.</param>
        /// <param name="buffer">[out] Receives the data read from the I/O bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read. At present, this must be 1, 2, or 4.</param>
        /// <returns>[out, optional] Receives the number of bytes returned read from the I/O bus. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint ReadIo(INTERFACE_TYPE interfaceType, uint busNumber, uint addressSpace, ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadIo(interfaceType, busNumber, addressSpace, offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <param name="interfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">[in] This parameter must be equal to one.</param>
        /// <param name="offset">[in] Specifies the I/O address within the address space.</param>
        /// <param name="buffer">[out] Receives the data read from the I/O bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read. At present, this must be 1, 2, or 4.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes returned read from the I/O bus. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryReadIo(INTERFACE_TYPE interfaceType, uint busNumber, uint addressSpace, ulong offset, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readIo, Vtbl->ReadIo);

            /*HRESULT ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readIo(Raw, interfaceType, busNumber, addressSpace, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteIo

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <param name="interfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">[in] Set to one.</param>
        /// <param name="offset">[in] Specifies the location of the requested data.</param>
        /// <param name="buffer">[in] Specifies the data to write to the I/O bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <returns>[out, optional] Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public uint WriteIo(INTERFACE_TYPE interfaceType, uint busNumber, uint addressSpace, ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteIo(interfaceType, busNumber, addressSpace, offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <param name="interfaceType">[in] Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">[in] Set to one.</param>
        /// <param name="offset">[in] Specifies the location of the requested data.</param>
        /// <param name="buffer">[in] Specifies the data to write to the I/O bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryWriteIo(INTERFACE_TYPE interfaceType, uint busNumber, uint addressSpace, ulong offset, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeIo, Vtbl->WriteIo);

            /*HRESULT WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeIo(Raw, interfaceType, busNumber, addressSpace, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region ReadMsr

        /// <summary>
        /// The ReadMsr method reads a specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="msr">[in] Specifies the MSR address.</param>
        /// <returns>[out] Receives the value of the MSR.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        public ulong ReadMsr(uint msr)
        {
            ulong msrValue;
            TryReadMsr(msr, out msrValue).ThrowDbgEngNotOk();

            return msrValue;
        }

        /// <summary>
        /// The ReadMsr method reads a specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="msr">[in] Specifies the MSR address.</param>
        /// <param name="msrValue">[out] Receives the value of the MSR.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        public HRESULT TryReadMsr(uint msr, out ulong msrValue)
        {
            InitDelegate(ref readMsr, Vtbl->ReadMsr);

            /*HRESULT ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);*/
            return readMsr(Raw, msr, out msrValue);
        }

        #endregion
        #region WriteMsr

        /// <summary>
        /// The WriteMsr method writes a value to the specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="msr">Specifies the MSR address.</param>
        /// <param name="msrValue">Specifies the value to write to the MSR.</param>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        public void WriteMsr(uint msr, ulong msrValue)
        {
            TryWriteMsr(msr, msrValue).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The WriteMsr method writes a value to the specified Model-Specific Register (MSR).
        /// </summary>
        /// <param name="msr">Specifies the MSR address.</param>
        /// <param name="msrValue">Specifies the value to write to the MSR.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For details on the addresses and values of MSRs, see the
        /// processor documentation.
        /// </remarks>
        public HRESULT TryWriteMsr(uint msr, ulong msrValue)
        {
            InitDelegate(ref writeMsr, Vtbl->WriteMsr);

            /*HRESULT WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);*/
            return writeMsr(Raw, msr, msrValue);
        }

        #endregion
        #region ReadBusData

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <param name="busDataType">[in] Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="offset">[in] Specifies the offset in the bus data to start reading from.</param>
        /// <param name="buffer">[out] Receives the data from the bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>[out, optional] Receives the number of bytes read from the bus. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        public uint ReadBusData(BUS_DATA_TYPE busDataType, uint busNumber, uint slotNumber, uint offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadBusData(busDataType, busNumber, slotNumber, offset, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <param name="busDataType">[in] Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="offset">[in] Specifies the offset in the bus data to start reading from.</param>
        /// <param name="buffer">[out] Receives the data from the bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes read from the bus. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        public HRESULT TryReadBusData(BUS_DATA_TYPE busDataType, uint busNumber, uint slotNumber, uint offset, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readBusData, Vtbl->ReadBusData);

            /*HRESULT ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readBusData(Raw, busDataType, busNumber, slotNumber, offset, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteBusData

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <param name="busDataType">[in] Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="offset">[in] Specifies the offset in the bus data to start writing to.</param>
        /// <param name="buffer">[in] Specifies the data to write to the bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <returns>[out, optional] Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        public uint WriteBusData(BUS_DATA_TYPE busDataType, uint busNumber, uint slotNumber, uint offset, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteBusData(busDataType, busNumber, slotNumber, offset, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <param name="busDataType">[in] Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">[in] Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">[in] Specifies the logical slot number on the bus.</param>
        /// <param name="offset">[in] Specifies the offset in the bus data to start writing to.</param>
        /// <param name="buffer">[in] Specifies the data to write to the bus.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The nature of the data read from the bus is system, bus,
        /// and slot dependent.
        /// </remarks>
        public HRESULT TryWriteBusData(BUS_DATA_TYPE busDataType, uint busNumber, uint slotNumber, uint offset, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeBusData, Vtbl->WriteBusData);

            /*HRESULT WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeBusData(Raw, busDataType, busNumber, slotNumber, offset, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region CheckLowMemory

        /// <summary>
        /// The CheckLowMemory method checks for memory corruption in the low 4 GB of memory.
        /// </summary>
        /// <remarks>
        /// This method is only available in kernel-mode debugging, and is only useful when the kernel was booted using the
        /// /nolowmem option. When the kernel is booted with the /nolowmem option, the kernel, drivers, operating system and
        /// applications are loaded in memory above 4 GB, while the low 4 GB of memory is filled with a unique pattern. The
        /// CheckLowMemory method checks this pattern for corruption. This may be used to verify that a driver behaves well
        /// when using physical addresses greater than 32 bits in length. See Physical Address Extension (PAE), /pae, and /nolowmem
        /// in the Windows Driver Kit.
        /// </remarks>
        public void CheckLowMemory()
        {
            TryCheckLowMemory().ThrowDbgEngNotOk();
        }

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
        public HRESULT TryCheckLowMemory()
        {
            InitDelegate(ref checkLowMemory, Vtbl->CheckLowMemory);

            /*HRESULT CheckLowMemory();*/
            return checkLowMemory(Raw);
        }

        #endregion
        #region ReadDebuggerData

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="buffer">[out] Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer.</param>
        /// <returns>[out, optional] Receives the number of bytes used in the buffer Buffer. If DataSize is NULL, this information is not returned.</returns>
        /// <remarks>
        /// Some or all of the values may be unavailable in certain debugging sessions. For example, some of the values are
        /// only available for particular versions of the operating system. For details on the different values returned by
        /// ReadDebuggerData, see Microsoft Windows Internals by David Solomon and Mark Russinovich, the Microsoft Windows
        /// SDK, and the Windows Driver Kit (WDK).
        /// </remarks>
        public uint ReadDebuggerData(uint index, IntPtr buffer, uint bufferSize)
        {
            uint dataSize;
            TryReadDebuggerData(index, buffer, bufferSize, out dataSize).ThrowDbgEngNotOk();

            return dataSize;
        }

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="buffer">[out] Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer.</param>
        /// <param name="dataSize">[out, optional] Receives the number of bytes used in the buffer Buffer. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some or all of the values may be unavailable in certain debugging sessions. For example, some of the values are
        /// only available for particular versions of the operating system. For details on the different values returned by
        /// ReadDebuggerData, see Microsoft Windows Internals by David Solomon and Mark Russinovich, the Microsoft Windows
        /// SDK, and the Windows Driver Kit (WDK).
        /// </remarks>
        public HRESULT TryReadDebuggerData(uint index, IntPtr buffer, uint bufferSize, out uint dataSize)
        {
            InitDelegate(ref readDebuggerData, Vtbl->ReadDebuggerData);

            /*HRESULT ReadDebuggerData(
            [In] uint Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);*/
            return readDebuggerData(Raw, index, buffer, bufferSize, out dataSize);
        }

        #endregion
        #region ReadProcessorSystemData

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose data is to be read.</param>
        /// <param name="index">[in] Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="buffer">[out] Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For information about the PCR, PRCB, and KTHREAD structures,
        /// as well as information about paging tables, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        public uint ReadProcessorSystemData(uint processor, DEBUG_DATA index, IntPtr buffer, uint bufferSize)
        {
            uint dataSize;
            TryReadProcessorSystemData(processor, index, buffer, bufferSize, out dataSize).ThrowDbgEngNotOk();

            return dataSize;
        }

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <param name="processor">[in] Specifies the processor whose data is to be read.</param>
        /// <param name="index">[in] Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="buffer">[out] Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="dataSize">[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For information about the PCR, PRCB, and KTHREAD structures,
        /// as well as information about paging tables, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        public HRESULT TryReadProcessorSystemData(uint processor, DEBUG_DATA index, IntPtr buffer, uint bufferSize, out uint dataSize)
        {
            InitDelegate(ref readProcessorSystemData, Vtbl->ReadProcessorSystemData);

            /*HRESULT ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);*/
            return readProcessorSystemData(Raw, processor, index, buffer, bufferSize, out dataSize);
        }

        #endregion
        #endregion
        #region IDebugDataSpaces2
        #region VirtualToPhysical

        /// <summary>
        /// The VirtualToPhysical method translates a location in the target's virtual address space into a physical memory address.
        /// </summary>
        /// <param name="virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <returns>[out] Receives the physical memory address.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public ulong VirtualToPhysical(ulong @virtual)
        {
            ulong physical;
            TryVirtualToPhysical(@virtual, out physical).ThrowDbgEngNotOk();

            return physical;
        }

        /// <summary>
        /// The VirtualToPhysical method translates a location in the target's virtual address space into a physical memory address.
        /// </summary>
        /// <param name="virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <param name="physical">[out] Receives the physical memory address.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging.
        /// </remarks>
        public HRESULT TryVirtualToPhysical(ulong @virtual, out ulong physical)
        {
            InitDelegate(ref virtualToPhysical, Vtbl2->VirtualToPhysical);

            /*HRESULT VirtualToPhysical(
            [In] ulong Virtual,
            [Out] out ulong Physical);*/
            return virtualToPhysical(Raw, @virtual, out physical);
        }

        #endregion
        #region GetVirtualTranslationPhysicalOffsets

        /// <summary>
        /// The GetVirtualTranslationPhysicalOffsets method returns the physical addresses of the system paging structures at different levels of the paging hierarchy.
        /// </summary>
        /// <param name="virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <returns>[out, optional] Receives the physical addresses for the system paging structures. If it is set to NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. Translating a virtual address to a physical address requires
        /// Windows to walk down the paging hierarchy. At each level it reads paging information from physical memory. This
        /// method returns the offsets for these physical pages. The number of levels in the paging hierarchy may be different
        /// for different addresses. The address at the last level of the hierarchy is the physical address corresponding to
        /// the specified virtual address. This is what <see cref="VirtualToPhysical"/> would return. For details on how virtual
        /// addresses are translated into physical addresses, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        public ulong[] GetVirtualTranslationPhysicalOffsets(ulong @virtual)
        {
            ulong[] offsets;
            TryGetVirtualTranslationPhysicalOffsets(@virtual, out offsets).ThrowDbgEngNotOk();

            return offsets;
        }

        /// <summary>
        /// The GetVirtualTranslationPhysicalOffsets method returns the physical addresses of the system paging structures at different levels of the paging hierarchy.
        /// </summary>
        /// <param name="virtual">[in] Specifies the location in the target's virtual address space to translate.</param>
        /// <param name="offsets">[out, optional] Receives the physical addresses for the system paging structures. If it is set to NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. Translating a virtual address to a physical address requires
        /// Windows to walk down the paging hierarchy. At each level it reads paging information from physical memory. This
        /// method returns the offsets for these physical pages. The number of levels in the paging hierarchy may be different
        /// for different addresses. The address at the last level of the hierarchy is the physical address corresponding to
        /// the specified virtual address. This is what <see cref="VirtualToPhysical"/> would return. For details on how virtual
        /// addresses are translated into physical addresses, see Microsoft Windows Internals by David Solomon and Mark Russinovich.
        /// </remarks>
        public HRESULT TryGetVirtualTranslationPhysicalOffsets(ulong @virtual, out ulong[] offsets)
        {
            InitDelegate(ref getVirtualTranslationPhysicalOffsets, Vtbl2->GetVirtualTranslationPhysicalOffsets);
            /*HRESULT GetVirtualTranslationPhysicalOffsets(
            [In] ulong Virtual,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] Offsets,
            [In] uint OffsetsSize,
            [Out] out uint Levels);*/
            offsets = null;
            uint offsetsSize = 0;
            uint levels;
            HRESULT hr = getVirtualTranslationPhysicalOffsets(Raw, @virtual, null, offsetsSize, out levels);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            offsetsSize = levels;
            offsets = new ulong[(int) offsetsSize];
            hr = getVirtualTranslationPhysicalOffsets(Raw, @virtual, offsets, offsetsSize, out levels);
            fail:
            return hr;
        }

        #endregion
        #region ReadHandleData

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">[in] Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="buffer">[out, optional] Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging.
        /// </remarks>
        public uint ReadHandleData(ulong handle, DEBUG_HANDLE_DATA_TYPE dataType, IntPtr buffer, uint bufferSize)
        {
            uint dataSize;
            TryReadHandleData(handle, dataType, buffer, bufferSize, out dataSize).ThrowDbgEngNotOk();

            return dataSize;
        }

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <param name="handle">[in] Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">[in] Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="buffer">[out, optional] Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="dataSize">[out, optional] Receives the size of the data in bytes. If DataSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging.
        /// </remarks>
        public HRESULT TryReadHandleData(ulong handle, DEBUG_HANDLE_DATA_TYPE dataType, IntPtr buffer, uint bufferSize, out uint dataSize)
        {
            InitDelegate(ref readHandleData, Vtbl2->ReadHandleData);

            /*HRESULT ReadHandleData(
            [In] ulong Handle,
            [In] DEBUG_HANDLE_DATA_TYPE DataType,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);*/
            return readHandleData(Raw, handle, dataType, buffer, bufferSize, out dataSize);
        }

        #endregion
        #region FillVirtual

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="start">[in] Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="buffer">[in] Specifies the memory location of the pattern.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <returns>[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        public uint FillVirtual(ulong start, uint size, IntPtr buffer, uint patternSize)
        {
            uint filled;
            TryFillVirtual(start, size, buffer, patternSize, out filled).ThrowDbgEngNotOk();

            return filled;
        }

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="start">[in] Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="buffer">[in] Specifies the memory location of the pattern.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <param name="filled">[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        public HRESULT TryFillVirtual(ulong start, uint size, IntPtr buffer, uint patternSize, out uint filled)
        {
            InitDelegate(ref fillVirtual, Vtbl2->FillVirtual);

            /*HRESULT FillVirtual(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);*/
            return fillVirtual(Raw, start, size, buffer, patternSize, out filled);
        }

        #endregion
        #region FillPhysical

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="start">[in] Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="buffer">[in] Specifies the pattern to write.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <returns>[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        public uint FillPhysical(ulong start, uint size, IntPtr buffer, uint patternSize)
        {
            uint filled;
            TryFillPhysical(start, size, buffer, patternSize, out filled).ThrowDbgEngNotOk();

            return filled;
        }

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="start">[in] Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">[in] Specifies how many bytes to write to the target's memory.</param>
        /// <param name="buffer">[in] Specifies the pattern to write.</param>
        /// <param name="patternSize">[in] Specifies the size in bytes of the pattern.</param>
        /// <param name="filled">[out, optional] Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method writes the pattern to the target's memory as many times as will fit in Size bytes. If the final copy
        /// of the pattern will not completely fit into the memory range, it will only be partially written. This includes
        /// the case where the size of the pattern is larger than the value of Size, and the extra bytes in the pattern are
        /// ignored.
        /// </remarks>
        public HRESULT TryFillPhysical(ulong start, uint size, IntPtr buffer, uint patternSize, out uint filled)
        {
            InitDelegate(ref fillPhysical, Vtbl2->FillPhysical);

            /*HRESULT FillPhysical(
            [In] ulong Start,
            [In] uint Size,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);*/
            return fillPhysical(Raw, start, size, buffer, patternSize, out filled);
        }

        #endregion
        #region QueryVirtual

        /// <summary>
        /// The QueryVirtual method provides information about the specified pages in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the pages whose information is requested.</param>
        /// <param name="info">[out] Receives the information about the memory page.</param>
        /// <remarks>
        /// This method may not work in all sessions. This method returns attributes for a range of pages. This range is determined
        /// by Windows; it begins at the specified page, and includes all subsequent pages with the same attributes. The size
        /// of the range is given by the RegionSize field of the structure returned in Info. MEMORY_BASIC_INFORMATION64 appears
        /// in the Microsoft Windows SDK header file winnt.h. It is the 64-bit equivalent of MEMORY_BASIC_INFORMATION, which
        /// is described in the Windows SDK documentation. This method behaves in a similar way to the Windows SDK function
        /// VirtualQuery. See Windows SDK documentation for details.
        /// </remarks>
        public void QueryVirtual(ulong offset, IntPtr info)
        {
            TryQueryVirtual(offset, info).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The QueryVirtual method provides information about the specified pages in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the pages whose information is requested.</param>
        /// <param name="info">[out] Receives the information about the memory page.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may not work in all sessions. This method returns attributes for a range of pages. This range is determined
        /// by Windows; it begins at the specified page, and includes all subsequent pages with the same attributes. The size
        /// of the range is given by the RegionSize field of the structure returned in Info. MEMORY_BASIC_INFORMATION64 appears
        /// in the Microsoft Windows SDK header file winnt.h. It is the 64-bit equivalent of MEMORY_BASIC_INFORMATION, which
        /// is described in the Windows SDK documentation. This method behaves in a similar way to the Windows SDK function
        /// VirtualQuery. See Windows SDK documentation for details.
        /// </remarks>
        public HRESULT TryQueryVirtual(ulong offset, IntPtr info)
        {
            InitDelegate(ref queryVirtual, Vtbl2->QueryVirtual);

            /*HRESULT QueryVirtual(
            [In] ulong Offset,
            [Out] IntPtr Info);*/
            return queryVirtual(Raw, offset, info);
        }

        #endregion
        #endregion
        #region IDebugDataSpaces3
        #region ReadImageNtHeaders

        /// <summary>
        /// The ReadImageNtHeaders method returns the NT headers for the specified image loaded in the target.
        /// </summary>
        /// <param name="imageBase">[in] Specifies the location in the target's virtual address space of the image whose NT headers are being requested.</param>
        /// <param name="headers">[out] Receives the NT headers for the specified image.</param>
        /// <remarks>
        /// If the image's NT headers are 32-bit, they are automatically converted to 64-bit for consistency. To determine
        /// if the headers were originally 32-bit, look at the value of Headers.OptionalHeader.Magic. If the value is IMAGE_NT_OPTIONAL_HDR32_MAGIC,
        /// the NT headers were originally 32-bit; otherwise the value is IMAGE_NT_OPTIONAL_HDR64_MAGIC, indicating the NT
        /// headers were originally 64-bit. This method will not read ROM headers. IMAGE_NT_HEADERS64, IMAGE_NT_OPTIONAL_HDR32_MAGIC,
        /// and IMAGE_NT_OPTIONAL_HDR64_MAGIC appear in the Microsoft Windows SDK header file winnt.h. IMAGE_NT_HEADERS64 is
        /// the 64-bit equivalent of IMAGE_NT_HEADERS, which is described in the Windows SDK documentation.
        /// </remarks>
        public void ReadImageNtHeaders(ulong imageBase, IntPtr headers)
        {
            TryReadImageNtHeaders(imageBase, headers).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ReadImageNtHeaders method returns the NT headers for the specified image loaded in the target.
        /// </summary>
        /// <param name="imageBase">[in] Specifies the location in the target's virtual address space of the image whose NT headers are being requested.</param>
        /// <param name="headers">[out] Receives the NT headers for the specified image.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the image's NT headers are 32-bit, they are automatically converted to 64-bit for consistency. To determine
        /// if the headers were originally 32-bit, look at the value of Headers.OptionalHeader.Magic. If the value is IMAGE_NT_OPTIONAL_HDR32_MAGIC,
        /// the NT headers were originally 32-bit; otherwise the value is IMAGE_NT_OPTIONAL_HDR64_MAGIC, indicating the NT
        /// headers were originally 64-bit. This method will not read ROM headers. IMAGE_NT_HEADERS64, IMAGE_NT_OPTIONAL_HDR32_MAGIC,
        /// and IMAGE_NT_OPTIONAL_HDR64_MAGIC appear in the Microsoft Windows SDK header file winnt.h. IMAGE_NT_HEADERS64 is
        /// the 64-bit equivalent of IMAGE_NT_HEADERS, which is described in the Windows SDK documentation.
        /// </remarks>
        public HRESULT TryReadImageNtHeaders(ulong imageBase, IntPtr headers)
        {
            InitDelegate(ref readImageNtHeaders, Vtbl3->ReadImageNtHeaders);

            /*HRESULT ReadImageNtHeaders(
            [In] ulong ImageBase,
            [Out] IntPtr Headers);*/
            return readImageNtHeaders(Raw, imageBase, headers);
        }

        #endregion
        #region ReadTagged

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <param name="tag">[in] Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">[in] Specifies the offset within the data to read.</param>
        /// <param name="buffer">[out, optional] Receives the data. If Buffer is NULL, the data is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>[out, optional] Receives the total size in bytes of the data specified by Tag.</returns>
        /// <remarks>
        /// Some debugger sessions have arbitrary additional data available. For example, when a dump file is created, additional
        /// dump information files containing extra information may also be created. This additional data is tagged with a
        /// global unique identifier and can only be retrieved via the tag. LPGUID is a pointer to a 128-bit unique identifier.
        /// It is defined in the Microsoft Windows SDK header file guiddef.h.
        /// </remarks>
        public uint ReadTagged(Guid tag, uint offset, IntPtr buffer, uint bufferSize)
        {
            uint totalSize;
            TryReadTagged(tag, offset, buffer, bufferSize, out totalSize).ThrowDbgEngNotOk();

            return totalSize;
        }

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <param name="tag">[in] Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">[in] Specifies the offset within the data to read.</param>
        /// <param name="buffer">[out, optional] Receives the data. If Buffer is NULL, the data is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="totalSize">[out, optional] Receives the total size in bytes of the data specified by Tag.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some debugger sessions have arbitrary additional data available. For example, when a dump file is created, additional
        /// dump information files containing extra information may also be created. This additional data is tagged with a
        /// global unique identifier and can only be retrieved via the tag. LPGUID is a pointer to a 128-bit unique identifier.
        /// It is defined in the Microsoft Windows SDK header file guiddef.h.
        /// </remarks>
        public HRESULT TryReadTagged(Guid tag, uint offset, IntPtr buffer, uint bufferSize, out uint totalSize)
        {
            InitDelegate(ref readTagged, Vtbl3->ReadTagged);

            /*HRESULT ReadTagged(
            [In, MarshalAs(UnmanagedType.LPStruct)]
            Guid Tag,
            [In] uint Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint TotalSize);*/
            return readTagged(Raw, tag, offset, buffer, bufferSize, out totalSize);
        }

        #endregion
        #region StartEnumTagged

        /// <summary>
        /// The StartEnumTagged method initializes a enumeration over the tagged data associated with a debugger session.
        /// </summary>
        /// <returns>[out] Receives the handle identifying the enumeration. This handle can be passed to <see cref="GetNextTagged"/> and <see cref="EndEnumTagged"/>.</returns>
        /// <remarks>
        /// The resources held by an enumeration created with this method can be released using <see cref="EndEnumTagged"/>.
        /// </remarks>
        public ulong StartEnumTagged()
        {
            ulong handle;
            TryStartEnumTagged(out handle).ThrowDbgEngNotOk();

            return handle;
        }

        /// <summary>
        /// The StartEnumTagged method initializes a enumeration over the tagged data associated with a debugger session.
        /// </summary>
        /// <param name="handle">[out] Receives the handle identifying the enumeration. This handle can be passed to <see cref="GetNextTagged"/> and <see cref="EndEnumTagged"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The resources held by an enumeration created with this method can be released using <see cref="EndEnumTagged"/>.
        /// </remarks>
        public HRESULT TryStartEnumTagged(out ulong handle)
        {
            InitDelegate(ref startEnumTagged, Vtbl3->StartEnumTagged);

            /*HRESULT StartEnumTagged(
            [Out] out ulong Handle);*/
            return startEnumTagged(Raw, out handle);
        }

        #endregion
        #region GetNextTagged

        /// <summary>
        /// The GetNextTagged method returns the GUID for the next block of tagged data in the enumeration.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle identifying the enumeration. This is the handle returned by <see cref="StartEnumTagged"/>.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetNextTaggedResult GetNextTagged(ulong handle)
        {
            GetNextTaggedResult result;
            TryGetNextTagged(handle, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNextTagged method returns the GUID for the next block of tagged data in the enumeration.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle identifying the enumeration. This is the handle returned by <see cref="StartEnumTagged"/>.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNextTagged(ulong handle, out GetNextTaggedResult result)
        {
            InitDelegate(ref getNextTagged, Vtbl3->GetNextTagged);
            /*HRESULT GetNextTagged(
            [In] ulong Handle,
            [Out] out Guid Tag,
            [Out] out uint Size);*/
            Guid tag;
            uint size;
            HRESULT hr = getNextTagged(Raw, handle, out tag, out size);

            if (hr == HRESULT.S_OK)
                result = new GetNextTaggedResult(tag, size);
            else
                result = default(GetNextTaggedResult);

            return hr;
        }

        #endregion
        #region EndEnumTagged

        /// <summary>
        /// The EndEnumTagged method releases the resources used by the specified enumeration.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle identifying the enumeration. This is the handle returned by <see cref="StartEnumTagged"/>.</param>
        /// <remarks>
        /// After a handle has been passed to this method it is no longer valid and must not be used again.
        /// </remarks>
        public void EndEnumTagged(ulong handle)
        {
            TryEndEnumTagged(handle).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The EndEnumTagged method releases the resources used by the specified enumeration.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle identifying the enumeration. This is the handle returned by <see cref="StartEnumTagged"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After a handle has been passed to this method it is no longer valid and must not be used again.
        /// </remarks>
        public HRESULT TryEndEnumTagged(ulong handle)
        {
            InitDelegate(ref endEnumTagged, Vtbl3->EndEnumTagged);

            /*HRESULT EndEnumTagged(
            [In] ulong Handle);*/
            return endEnumTagged(Raw, handle);
        }

        #endregion
        #endregion
        #region IDebugDataSpaces4
        #region GetOffsetInformation

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <param name="space">[in] Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">[in] Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">[in] Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="buffer">[out, optional] Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer.</param>
        /// <returns>[out, optional] Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</returns>
        public uint GetOffsetInformation(DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, ulong offset, IntPtr buffer, uint bufferSize)
        {
            uint infoSize;
            TryGetOffsetInformation(space, which, offset, buffer, bufferSize, out infoSize).ThrowDbgEngNotOk();

            return infoSize;
        }

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <param name="space">[in] Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">[in] Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">[in] Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="buffer">[out, optional] Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer.</param>
        /// <param name="infoSize">[out, optional] Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetOffsetInformation(DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, ulong offset, IntPtr buffer, uint bufferSize, out uint infoSize)
        {
            InitDelegate(ref getOffsetInformation, Vtbl4->GetOffsetInformation);

            /*HRESULT GetOffsetInformation(
            [In] DEBUG_DATA_SPACE Space,
            [In] DEBUG_OFFSINFO Which,
            [In] ulong Offset,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint InfoSize);*/
            return getOffsetInformation(Raw, space, which, offset, buffer, bufferSize, out infoSize);
        }

        #endregion
        #region GetNextDifferentlyValidOffsetVirtual

        /// <summary>
        /// The GetNextDifferentlyValidOffsetVirtual method returns the offset of the next address whose validity might be different from the validity of the specified address.
        /// </summary>
        /// <param name="offset">[in] Specifies a start address. The address returned in NextOffset will be the next address whose validity might be defined differently from this one.</param>
        /// <returns>[out] Receives the address of the next address whose validity might be defined differently from the address in Offset.</returns>
        /// <remarks>
        /// The size of regions of validity depends on the target. For example, in live user-mode debugging sessions, where
        /// virtual address validity changes from page to page, NextOffset will receive the address of the next page. In user-mode
        /// dump files the validity can change from byte to byte.
        /// </remarks>
        public ulong GetNextDifferentlyValidOffsetVirtual(ulong offset)
        {
            ulong nextOffset;
            TryGetNextDifferentlyValidOffsetVirtual(offset, out nextOffset).ThrowDbgEngNotOk();

            return nextOffset;
        }

        /// <summary>
        /// The GetNextDifferentlyValidOffsetVirtual method returns the offset of the next address whose validity might be different from the validity of the specified address.
        /// </summary>
        /// <param name="offset">[in] Specifies a start address. The address returned in NextOffset will be the next address whose validity might be defined differently from this one.</param>
        /// <param name="nextOffset">[out] Receives the address of the next address whose validity might be defined differently from the address in Offset.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The size of regions of validity depends on the target. For example, in live user-mode debugging sessions, where
        /// virtual address validity changes from page to page, NextOffset will receive the address of the next page. In user-mode
        /// dump files the validity can change from byte to byte.
        /// </remarks>
        public HRESULT TryGetNextDifferentlyValidOffsetVirtual(ulong offset, out ulong nextOffset)
        {
            InitDelegate(ref getNextDifferentlyValidOffsetVirtual, Vtbl4->GetNextDifferentlyValidOffsetVirtual);

            /*HRESULT GetNextDifferentlyValidOffsetVirtual(
            [In] ulong Offset,
            [Out] out ulong NextOffset);*/
            return getNextDifferentlyValidOffsetVirtual(Raw, offset, out nextOffset);
        }

        #endregion
        #region GetValidRegionVirtual

        /// <summary>
        /// The GetValidRegionVirtual method locates the first valid region of memory in a specified memory range.
        /// </summary>
        /// <param name="base">[in] Specifies the address of the beginning of the memory range to search for valid memory.</param>
        /// <param name="size">[in] Specifies the size, in bytes, of the memory range to search.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetValidRegionVirtualResult GetValidRegionVirtual(ulong @base, uint size)
        {
            GetValidRegionVirtualResult result;
            TryGetValidRegionVirtual(@base, size, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetValidRegionVirtual method locates the first valid region of memory in a specified memory range.
        /// </summary>
        /// <param name="base">[in] Specifies the address of the beginning of the memory range to search for valid memory.</param>
        /// <param name="size">[in] Specifies the size, in bytes, of the memory range to search.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetValidRegionVirtual(ulong @base, uint size, out GetValidRegionVirtualResult result)
        {
            InitDelegate(ref getValidRegionVirtual, Vtbl4->GetValidRegionVirtual);
            /*HRESULT GetValidRegionVirtual(
            [In] ulong Base,
            [In] uint Size,
            [Out] out ulong ValidBase,
            [Out] out uint ValidSize);*/
            ulong validBase;
            uint validSize;
            HRESULT hr = getValidRegionVirtual(Raw, @base, size, out validBase, out validSize);

            if (hr == HRESULT.S_OK)
                result = new GetValidRegionVirtualResult(validBase, validSize);
            else
                result = default(GetValidRegionVirtualResult);

            return hr;
        }

        #endregion
        #region SearchVirtual2

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">[in] Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">[in] Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="buffer">[in] Specifies the pattern to search for.</param>
        /// <param name="patternSize">[in] Specifies the size, in bytes, of the pattern. This must be a multiple of the granularity of the pattern.</param>
        /// <param name="patternGranularity">[in] Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <returns>[out] Receives the location in the process's virtual address space of the pattern, if it was found.</returns>
        /// <remarks>
        /// This method searches the target's virtual memory for the first occurrence, subject to granularity, of the pattern
        /// that is entirely contained in the Length bytes of the target's memory, starting at the Offset location. PatternGranularity
        /// can be used to ensure the alignment of the match relative to Offset. For example, a value of 0x4 can be used to
        /// require alignment to a DWORD. A value of 0x1 can be used to allow the pattern to start anywhere.
        /// </remarks>
        public ulong SearchVirtual2(ulong offset, ulong length, DEBUG_VSEARCH flags, IntPtr buffer, uint patternSize, uint patternGranularity)
        {
            ulong matchOffset;
            TrySearchVirtual2(offset, length, flags, buffer, patternSize, patternGranularity, out matchOffset).ThrowDbgEngNotOk();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">[in] Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">[in] Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="buffer">[in] Specifies the pattern to search for.</param>
        /// <param name="patternSize">[in] Specifies the size, in bytes, of the pattern. This must be a multiple of the granularity of the pattern.</param>
        /// <param name="patternGranularity">[in] Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <param name="matchOffset">[out] Receives the location in the process's virtual address space of the pattern, if it was found.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method searches the target's virtual memory for the first occurrence, subject to granularity, of the pattern
        /// that is entirely contained in the Length bytes of the target's memory, starting at the Offset location. PatternGranularity
        /// can be used to ensure the alignment of the match relative to Offset. For example, a value of 0x4 can be used to
        /// require alignment to a DWORD. A value of 0x1 can be used to allow the pattern to start anywhere.
        /// </remarks>
        public HRESULT TrySearchVirtual2(ulong offset, ulong length, DEBUG_VSEARCH flags, IntPtr buffer, uint patternSize, uint patternGranularity, out ulong matchOffset)
        {
            InitDelegate(ref searchVirtual2, Vtbl4->SearchVirtual2);

            /*HRESULT SearchVirtual2(
            [In] ulong Offset,
            [In] ulong Length,
            [In] DEBUG_VSEARCH Flags,
            [In] IntPtr Buffer,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);*/
            return searchVirtual2(Raw, offset, length, flags, buffer, patternSize, patternGranularity, out matchOffset);
        }

        #endregion
        #region ReadMultiByteStringVirtual

        /// <summary>
        /// The ReadMultiByteStringVirtual method reads a null-terminated, multibyte string from the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <returns>[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public string ReadMultiByteStringVirtual(ulong offset, uint maxBytes)
        {
            string bufferResult;
            TryReadMultiByteStringVirtual(offset, maxBytes, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The ReadMultiByteStringVirtual method reads a null-terminated, multibyte string from the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="bufferResult">[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public HRESULT TryReadMultiByteStringVirtual(ulong offset, uint maxBytes, out string bufferResult)
        {
            InitDelegate(ref readMultiByteStringVirtual, Vtbl4->ReadMultiByteStringVirtual);
            /*HRESULT ReadMultiByteStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);*/
            StringBuilder buffer;
            uint bufferSize = 0;
            uint stringBytes;
            HRESULT hr = readMultiByteStringVirtual(Raw, offset, maxBytes, null, bufferSize, out stringBytes);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringBytes;
            buffer = new StringBuilder((int) bufferSize);
            hr = readMultiByteStringVirtual(Raw, offset, maxBytes, buffer, bufferSize, out stringBytes);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReadMultiByteStringVirtualWide

        /// <summary>
        /// The ReadMultiByteStringVirtualWide method reads a null-terminated, multibyte string from the target and converts it to Unicode.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="codePage">[in] Specifies the code page to use to convert the multibyte string read from the target into a Unicode string.<para/>
        /// For example, CP_ACP is the ANSI code page.</param>
        /// <returns>[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer. Note that even if S_OK is returned, the buffer
        /// may not have been large enough to store the string. In this case the string is truncated to fit in Buffer. The
        /// truncated string is null-terminated if Buffer has space for at least one character. After the call returns, check
        /// to see if *StringBytes is bigger than BufferSize.
        /// </remarks>
        public string ReadMultiByteStringVirtualWide(ulong offset, uint maxBytes, CODE_PAGE codePage)
        {
            string bufferResult;
            TryReadMultiByteStringVirtualWide(offset, maxBytes, codePage, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The ReadMultiByteStringVirtualWide method reads a null-terminated, multibyte string from the target and converts it to Unicode.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="codePage">[in] Specifies the code page to use to convert the multibyte string read from the target into a Unicode string.<para/>
        /// For example, CP_ACP is the ANSI code page.</param>
        /// <param name="bufferResult">[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer. Note that even if S_OK is returned, the buffer
        /// may not have been large enough to store the string. In this case the string is truncated to fit in Buffer. The
        /// truncated string is null-terminated if Buffer has space for at least one character. After the call returns, check
        /// to see if *StringBytes is bigger than BufferSize.
        /// </remarks>
        public HRESULT TryReadMultiByteStringVirtualWide(ulong offset, uint maxBytes, CODE_PAGE codePage, out string bufferResult)
        {
            InitDelegate(ref readMultiByteStringVirtualWide, Vtbl4->ReadMultiByteStringVirtualWide);
            /*HRESULT ReadMultiByteStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);*/
            StringBuilder buffer;
            uint bufferSize = 0;
            uint stringBytes;
            HRESULT hr = readMultiByteStringVirtualWide(Raw, offset, maxBytes, codePage, null, bufferSize, out stringBytes);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringBytes;
            buffer = new StringBuilder((int) bufferSize);
            hr = readMultiByteStringVirtualWide(Raw, offset, maxBytes, codePage, buffer, bufferSize, out stringBytes);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReadUnicodeStringVirtual

        /// <summary>
        /// The ReadUnicodeStringVirtual method reads a null-terminated, Unicode string from the target and converts it to a multibyte string.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the string.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="codePage">[in] Specifies the code page to use to convert the multibyte string read from the target into a Unicode string.<para/>
        /// For example, CP_ACP is the ANSI code page.</param>
        /// <returns>[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public string ReadUnicodeStringVirtual(ulong offset, uint maxBytes, CODE_PAGE codePage)
        {
            string bufferResult;
            TryReadUnicodeStringVirtual(offset, maxBytes, codePage, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The ReadUnicodeStringVirtual method reads a null-terminated, Unicode string from the target and converts it to a multibyte string.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the string.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="codePage">[in] Specifies the code page to use to convert the multibyte string read from the target into a Unicode string.<para/>
        /// For example, CP_ACP is the ANSI code page.</param>
        /// <param name="bufferResult">[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public HRESULT TryReadUnicodeStringVirtual(ulong offset, uint maxBytes, CODE_PAGE codePage, out string bufferResult)
        {
            InitDelegate(ref readUnicodeStringVirtual, Vtbl4->ReadUnicodeStringVirtual);
            /*HRESULT ReadUnicodeStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);*/
            StringBuilder buffer;
            uint bufferSize = 0;
            uint stringBytes;
            HRESULT hr = readUnicodeStringVirtual(Raw, offset, maxBytes, codePage, null, bufferSize, out stringBytes);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringBytes;
            buffer = new StringBuilder((int) bufferSize);
            hr = readUnicodeStringVirtual(Raw, offset, maxBytes, codePage, buffer, bufferSize, out stringBytes);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReadUnicodeStringVirtualWide

        /// <summary>
        /// The ReadUnicodeStringVirtualWide method reads a null-terminated, Unicode string from the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <returns>[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public string ReadUnicodeStringVirtualWide(ulong offset, uint maxBytes)
        {
            string bufferResult;
            TryReadUnicodeStringVirtualWide(offset, maxBytes, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The ReadUnicodeStringVirtualWide method reads a null-terminated, Unicode string from the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location of the string in the process's virtual address space.</param>
        /// <param name="maxBytes">[in] Specifies the maximum number of bytes to read from the target.</param>
        /// <param name="bufferResult">[out, optional] Receives the string from the target. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details. The method was successful.</returns>
        /// <remarks>
        /// The engine will read up to MaxBytes from the target, looking for a null-terminator. If the string has more than
        /// BufferSize characters, the string will be truncated to fit in Buffer.
        /// </remarks>
        public HRESULT TryReadUnicodeStringVirtualWide(ulong offset, uint maxBytes, out string bufferResult)
        {
            InitDelegate(ref readUnicodeStringVirtualWide, Vtbl4->ReadUnicodeStringVirtualWide);
            /*HRESULT ReadUnicodeStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);*/
            StringBuilder buffer;
            uint bufferSize = 0;
            uint stringBytes;
            HRESULT hr = readUnicodeStringVirtualWide(Raw, offset, maxBytes, null, bufferSize, out stringBytes);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringBytes;
            buffer = new StringBuilder((int) bufferSize);
            hr = readUnicodeStringVirtualWide(Raw, offset, maxBytes, buffer, bufferSize, out stringBytes);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReadPhysical2

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to read.</param>
        /// <param name="flags">[in] Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="buffer">[out] Receives the memory that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>[out, optional] Receives the number of bytes read from the target's memory. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The flags DEBUG_PHYSICAL_CACHED, DEBUG_PHYSICAL_UNCACHED,
        /// and DEBUG_PHYSICAL_WRITE_COMBINED can only be used when the target is a live kernel target that is being debugged
        /// in the standard way (using a COM port, 1394 bus, or named pipe).
        /// </remarks>
        public uint ReadPhysical2(ulong offset, DEBUG_PHYSICAL flags, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadPhysical2(offset, flags, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to read.</param>
        /// <param name="flags">[in] Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="buffer">[out] Receives the memory that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes read from the target's memory. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The flags DEBUG_PHYSICAL_CACHED, DEBUG_PHYSICAL_UNCACHED,
        /// and DEBUG_PHYSICAL_WRITE_COMBINED can only be used when the target is a live kernel target that is being debugged
        /// in the standard way (using a COM port, 1394 bus, or named pipe).
        /// </remarks>
        public HRESULT TryReadPhysical2(ulong offset, DEBUG_PHYSICAL flags, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readPhysical2, Vtbl4->ReadPhysical2);

            /*HRESULT ReadPhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readPhysical2(Raw, offset, flags, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WritePhysical2

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">[in] Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="buffer">[in] Specifies the data to write.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be written.</param>
        /// <returns>[out, optional] Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The flags DEBUG_PHYSICAL_CACHED, DEBUG_PHYSICAL_UNCACHED,
        /// and DEBUG_PHYSICAL_WRITE_COMBINED can only be used when the target is a live kernel target that is being debugged
        /// in the standard way (using a COM port, 1394 bus, or named pipe).
        /// </remarks>
        public uint WritePhysical2(ulong offset, DEBUG_PHYSICAL flags, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWritePhysical2(offset, flags, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">[in] Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="buffer">[in] Specifies the data to write.</param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. The flags DEBUG_PHYSICAL_CACHED, DEBUG_PHYSICAL_UNCACHED,
        /// and DEBUG_PHYSICAL_WRITE_COMBINED can only be used when the target is a live kernel target that is being debugged
        /// in the standard way (using a COM port, 1394 bus, or named pipe).
        /// </remarks>
        public HRESULT TryWritePhysical2(ulong offset, DEBUG_PHYSICAL flags, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writePhysical2, Vtbl4->WritePhysical2);

            /*HRESULT WritePhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writePhysical2(Raw, offset, flags, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugDataSpaces

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadVirtualDelegate readVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteVirtualDelegate writeVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SearchVirtualDelegate searchVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadVirtualUncachedDelegate readVirtualUncached;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteVirtualUncachedDelegate writeVirtualUncached;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadPointersVirtualDelegate readPointersVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WritePointersVirtualDelegate writePointersVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadPhysicalDelegate readPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WritePhysicalDelegate writePhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadControlDelegate readControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteControlDelegate writeControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadIoDelegate readIo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteIoDelegate writeIo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadMsrDelegate readMsr;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteMsrDelegate writeMsr;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadBusDataDelegate readBusData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteBusDataDelegate writeBusData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CheckLowMemoryDelegate checkLowMemory;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadDebuggerDataDelegate readDebuggerData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadProcessorSystemDataDelegate readProcessorSystemData;

        #endregion
        #region IDebugDataSpaces2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private VirtualToPhysicalDelegate virtualToPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetVirtualTranslationPhysicalOffsetsDelegate getVirtualTranslationPhysicalOffsets;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadHandleDataDelegate readHandleData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FillVirtualDelegate fillVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FillPhysicalDelegate fillPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryVirtualDelegate queryVirtual;

        #endregion
        #region IDebugDataSpaces3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadImageNtHeadersDelegate readImageNtHeaders;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadTaggedDelegate readTagged;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartEnumTaggedDelegate startEnumTagged;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNextTaggedDelegate getNextTagged;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EndEnumTaggedDelegate endEnumTagged;

        #endregion
        #region IDebugDataSpaces4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetInformationDelegate getOffsetInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNextDifferentlyValidOffsetVirtualDelegate getNextDifferentlyValidOffsetVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetValidRegionVirtualDelegate getValidRegionVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SearchVirtual2Delegate searchVirtual2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadMultiByteStringVirtualDelegate readMultiByteStringVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadMultiByteStringVirtualWideDelegate readMultiByteStringVirtualWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadUnicodeStringVirtualDelegate readUnicodeStringVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadUnicodeStringVirtualWideDelegate readUnicodeStringVirtualWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadPhysical2Delegate readPhysical2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WritePhysical2Delegate writePhysical2;

        #endregion
        #endregion
        #region Delegates
        #region IDebugDataSpaces

        private delegate HRESULT ReadVirtualDelegate(IntPtr self, [In] ulong Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteVirtualDelegate(IntPtr self, [In] ulong Offset, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT SearchVirtualDelegate(IntPtr self, [In] ulong Offset, [In] ulong Length, [In] IntPtr Pattern, [In] uint PatternSize, [In] uint PatternGranularity, [Out] out ulong MatchOffset);
        private delegate HRESULT ReadVirtualUncachedDelegate(IntPtr self, [In] ulong Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteVirtualUncachedDelegate(IntPtr self, [In] ulong Offset, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT ReadPointersVirtualDelegate(IntPtr self, [In] uint Count, [In] ulong Offset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);
        private delegate HRESULT WritePointersVirtualDelegate(IntPtr self, [In] uint Count, [In] ulong Offset, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);
        private delegate HRESULT ReadPhysicalDelegate(IntPtr self, [In] ulong Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WritePhysicalDelegate(IntPtr self, [In] ulong Offset, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT ReadControlDelegate(IntPtr self, [In] uint Processor, [In] ulong Offset, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteControlDelegate(IntPtr self, [In] uint Processor, [In] ulong Offset, [In] IntPtr Buffer, [In] int BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT ReadIoDelegate(IntPtr self, [In] INTERFACE_TYPE InterfaceType, [In] uint BusNumber, [In] uint AddressSpace, [In] ulong Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteIoDelegate(IntPtr self, [In] INTERFACE_TYPE InterfaceType, [In] uint BusNumber, [In] uint AddressSpace, [In] ulong Offset, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT ReadMsrDelegate(IntPtr self, [In] uint Msr, [Out] out ulong MsrValue);
        private delegate HRESULT WriteMsrDelegate(IntPtr self, [In] uint Msr, [In] ulong MsrValue);
        private delegate HRESULT ReadBusDataDelegate(IntPtr self, [In] BUS_DATA_TYPE BusDataType, [In] uint BusNumber, [In] uint SlotNumber, [In] uint Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteBusDataDelegate(IntPtr self, [In] BUS_DATA_TYPE BusDataType, [In] uint BusNumber, [In] uint SlotNumber, [In] uint Offset, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT CheckLowMemoryDelegate(IntPtr self);
        private delegate HRESULT ReadDebuggerDataDelegate(IntPtr self, [In] uint Index, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint DataSize);
        private delegate HRESULT ReadProcessorSystemDataDelegate(IntPtr self, [In] uint Processor, [In] DEBUG_DATA Index, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint DataSize);

        #endregion
        #region IDebugDataSpaces2

        private delegate HRESULT VirtualToPhysicalDelegate(IntPtr self, [In] ulong Virtual, [Out] out ulong Physical);
        private delegate HRESULT GetVirtualTranslationPhysicalOffsetsDelegate(IntPtr self, [In] ulong Virtual, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] Offsets, [In] uint OffsetsSize, [Out] out uint Levels);
        private delegate HRESULT ReadHandleDataDelegate(IntPtr self, [In] ulong Handle, [In] DEBUG_HANDLE_DATA_TYPE DataType, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint DataSize);
        private delegate HRESULT FillVirtualDelegate(IntPtr self, [In] ulong Start, [In] uint Size, [In] IntPtr Buffer, [In] uint PatternSize, [Out] out uint Filled);
        private delegate HRESULT FillPhysicalDelegate(IntPtr self, [In] ulong Start, [In] uint Size, [In] IntPtr Buffer, [In] uint PatternSize, [Out] out uint Filled);
        private delegate HRESULT QueryVirtualDelegate(IntPtr self, [In] ulong Offset, [Out] IntPtr Info);

        #endregion
        #region IDebugDataSpaces3

        private delegate HRESULT ReadImageNtHeadersDelegate(IntPtr self, [In] ulong ImageBase, [Out] IntPtr Headers);
        private delegate HRESULT ReadTaggedDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] Guid Tag, [In] uint Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint TotalSize);
        private delegate HRESULT StartEnumTaggedDelegate(IntPtr self, [Out] out ulong Handle);
        private delegate HRESULT GetNextTaggedDelegate(IntPtr self, [In] ulong Handle, [Out] out Guid Tag, [Out] out uint Size);
        private delegate HRESULT EndEnumTaggedDelegate(IntPtr self, [In] ulong Handle);

        #endregion
        #region IDebugDataSpaces4

        private delegate HRESULT GetOffsetInformationDelegate(IntPtr self, [In] DEBUG_DATA_SPACE Space, [In] DEBUG_OFFSINFO Which, [In] ulong Offset, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint InfoSize);
        private delegate HRESULT GetNextDifferentlyValidOffsetVirtualDelegate(IntPtr self, [In] ulong Offset, [Out] out ulong NextOffset);
        private delegate HRESULT GetValidRegionVirtualDelegate(IntPtr self, [In] ulong Base, [In] uint Size, [Out] out ulong ValidBase, [Out] out uint ValidSize);
        private delegate HRESULT SearchVirtual2Delegate(IntPtr self, [In] ulong Offset, [In] ulong Length, [In] DEBUG_VSEARCH Flags, [In] IntPtr Buffer, [In] uint PatternSize, [In] uint PatternGranularity, [Out] out ulong MatchOffset);
        private delegate HRESULT ReadMultiByteStringVirtualDelegate(IntPtr self, [In] ulong Offset, [In] uint MaxBytes, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] uint BufferSize, [Out] out uint StringBytes);
        private delegate HRESULT ReadMultiByteStringVirtualWideDelegate(IntPtr self, [In] ulong Offset, [In] uint MaxBytes, [In] CODE_PAGE CodePage, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] uint BufferSize, [Out] out uint StringBytes);
        private delegate HRESULT ReadUnicodeStringVirtualDelegate(IntPtr self, [In] ulong Offset, [In] uint MaxBytes, [In] CODE_PAGE CodePage, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] uint BufferSize, [Out] out uint StringBytes);
        private delegate HRESULT ReadUnicodeStringVirtualWideDelegate(IntPtr self, [In] ulong Offset, [In] uint MaxBytes, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] uint BufferSize, [Out] out uint StringBytes);
        private delegate HRESULT ReadPhysical2Delegate(IntPtr self, [In] ulong Offset, [In] DEBUG_PHYSICAL Flags, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WritePhysical2Delegate(IntPtr self, [In] ulong Offset, [In] DEBUG_PHYSICAL Flags, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);

        #endregion
        #endregion
    }
}
