﻿using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The memory access interface to the underlying debugger.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("212149C9-9183-4A3E-B00E-4FD1DC95339B")]
    [ComImport]
    public interface IDebugHostMemory
    {
        /// <summary>
        /// Reads a number of bytes from the address space of the target as defined by the inpassed context and location.The number of bytes read is returned in "bytesRead" upon success.
        /// </summary>
        /// <param name="context">The host context in which to read bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes read from the debug target will be written to this buffer.</param>
        /// <param name="bufferSize">The size of the buffer and the number of bytes to read.</param>
        /// <param name="bytesRead">The number of bytes actually read from the debug target will be returned here. If the method can complete a partial read, S_FALSE will be returned and the value in bytesRead may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full read was completed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT ReadBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesRead);

        /// <summary>
        /// Writes a number of bytes to the address space of the target as defined by the inpassed context and location. The number of bytes written is returned in "bytesWritten" upon success.
        /// </summary>
        /// <param name="context">The host context in which to write bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes to write to the debug target.</param>
        /// <param name="bufferSize">The size of the buffer / number of bytes to write to the debug target.</param>
        /// <param name="bytesWritten">The number of bytes actually written to the debug target will be returned here. If the method can complete a partial write, S_FALSE will be returned and the value in bytesWritten may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full write was completed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT WriteBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesWritten);

        /// <summary>
        /// Reads a number of pointer sized objects from the address space of the target as defined by the inpassed context and location.<para/>
        /// Each read pointer is, if necessary, zero extended to 64-bits and returned.
        /// </summary>
        /// <param name="context">The host context in which to read pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to read.</param>
        /// <param name="pointers">The pointers read from the debug target will be placed into the array passed here. Any pointers less than 64-bits in size will be zero extended to 64-bits.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT ReadPointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);

        /// <summary>
        /// Takes a number of pointers as held in unsigned 64-bit values, truncates them to the native pointer size of the target, and writes them into the address space of the target as defined by the inpassed context and location.
        /// </summary>
        /// <param name="context">The host context in which to write pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to write.</param>
        /// <param name="pointers">The pointers to write to the debug target. If the target is 32-bits, the pointer values here will be truncated prior to writing them to the underlying debug target.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT WritePointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);

        /// <summary>
        /// For a given location within the address space of the target as defined by context and location, convert the location to a displayable string (according to whatever format the host chooses).<para/>
        /// If the "verbose" argument is true, the string conversion may be "more verbose"
        /// </summary>
        /// <param name="context">The host context in which the location is valid. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location to convert to a displayable string.</param>
        /// <param name="verbose">An indication of whether the conversion should be verbose or not. A verbose conversion will contain more information than a non-verbose one.<para/>
        /// The default is for a non-verbose conversion.</param>
        /// <param name="locationName">A displayable string for the location will be returned here. This string is allocated by SysAllocString and the caller is responsible for freeing the allocation with a call to the SysFreeString function.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetDisplayStringForLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.U1)] bool verbose,
            [Out, MarshalAs(UnmanagedType.BStr)] out string locationName);
    }
}
