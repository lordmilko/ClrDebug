﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of <see cref="ICLRDataTarget2"/> that provides access to exception information.
    /// </summary>
    /// <remarks>
    /// The API client (that is, the debugger) must implement this interface as appropriate for the particular target process.
    /// For example, a live process would have an implementation different from that of a memory dump. The target may not
    /// support modification of its memory regions.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A5664F95-0AF4-4A1B-960E-2F3346B4214C")]
    [ComImport]
    public interface ICLRDataTarget3 : ICLRDataTarget2
    {
        /// <summary>
        /// Gets the identifier for the kind of instruction set that the target process is using.
        /// </summary>
        /// <param name="machineType">[out] A pointer to a value that indicates the instruction set that the target process is using. The returned machineType is one of the IMAGE_FILE_MACHINE constants, which are defined in the WinNT.h header file.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMachineType(out uint machineType);

        /// <summary>
        /// Gets the size, in bytes, of the pointer type that the target process uses. This method is called by the common language runtime data access services.
        /// </summary>
        /// <param name="pointerSize">[out] A pointer to an integer value that specifies the size, in bytes, of a pointer on the target process.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetPointerSize(out uint pointerSize);

        /// <summary>
        /// Gets the base memory address of the specified image.
        /// </summary>
        /// <param name="imagePath">[in] The file name of the image, including its path.</param>
        /// <param name="baseAddress">[out] A pointer to a CLRDATA_ADDRESS that stores the base address of the image.</param>
        /// <remarks>
        /// The image file name may or may not have a path. If a path is specified, matching is done on the whole path; otherwise,
        /// matching is done only on the file name.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);

        /// <summary>
        /// Reads data from the specified virtual memory address into the specified buffer.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="buffer">[out] A pointer to a buffer that receives the data.</param>
        /// <param name="bytesRequested">[in] The length of the buffer.</param>
        /// <param name="bytesRead">[out] A pointer to the number of bytes returned.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);

        /// <summary>
        /// Writes data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="buffer">[in] A pointer to a buffer that stores the data to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes to be written.</param>
        /// <param name="bytesWritten">[out] A pointer to the actual number of bytes that were written.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT WriteVirtual(
            [In] ulong address,
            [In] ref byte buffer,
            [In] uint bytesRequested,
            out uint bytesWritten);

        /// <summary>
        /// Gets a value from the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <param name="value">[out] A pointer to a CLRDATA_ADDRESS value that specifies the value returned from the given TLS location.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetTLSValue([In] uint threadID, [In] uint index, out ulong value);

        /// <summary>
        /// Sets a value in the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <param name="value">[in] A CLRDATA_ADDRESS value that specifies the value to place in the given TLS location.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);

        /// <summary>
        /// Gets the operating system identifier for the current thread.
        /// </summary>
        /// <param name="threadID">[out] A pointer to the operating system identifier of the current thread for the target process.</param>
        /// <remarks>
        /// If there is no current thread for the target process, the GetCurrentThreadID method may fail.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCurrentThreadID(out uint threadID);

        /// <summary>
        /// Gets the current execution context for the given thread in the target process. This method is called by the common language runtime data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context to return. The implementation will return at least these parts of the context.</param>
        /// <param name="contextSize">[in] The size of the context.</param>
        /// <param name="context">[out] Pointer to a buffer in which to place the context. The data in the context buffer must be in the format of the Win32 CONTEXT structure.<para/>
        /// The context specifies processor-specific register data, so the definition of the Win32 CONTEXT structure depends on the processor's architecture.<para/>
        /// Refer to the WinNT.h header file for the definition of the Win32 CONTEXT structure.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThreadContext(
            [In] uint threadID,
            [In] uint contextFlags,
            [In] uint contextSize,
            out byte context);

        /// <summary>
        /// Sets the current context of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="contextSize">[in] The size of the context.</param>
        /// <param name="context">[in] Pointer to a buffer containing the context. The data in the context buffer will be in the format of the Win32 CONTEXT structure.<para/>
        /// The context specifies processor-specific register data, so the definition of the Win32 CONTEXT structure depends on the processor's architecture.<para/>
        /// Refer to the WinNT.h header file for the definition of the Win32 CONTEXT structure.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] ref byte context);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to request an operation, as defined by the implementation.
        /// </summary>
        /// <param name="reqCode">[in] User-defined.</param>
        /// <param name="inBufferSize">[in] The size of the input buffer, which is used for the incoming request.</param>
        /// <param name="inBuffer">[in] A buffer containing the request.</param>
        /// <param name="outBufferSize">[in] The size of the output buffer, which is used for the response.</param>
        /// <param name="outBuffer">[out] A Buffer containing the response.</param>
        /// <remarks>
        /// The Request method facilitates the addition of unspecified custom operations. That is, this method provides extensibility
        /// without requiring revision of the interface definition. This method is implemented by the writer of the debugging
        /// application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] ref byte inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to allocate memory in the address space of this target process.
        /// </summary>
        /// <param name="addr">[in] A CLRDATA_ADDRESS value that specifies the requested starting address of the memory to be allocated.</param>
        /// <param name="size">[in] The size, in bytes, of the memory to be allocated.</param>
        /// <param name="typeFlags">[in] Flags that control the allocation of memory. See the Win32 VirtualAlloc function.</param>
        /// <param name="protectFlags">[in] The protection attributes for the allocated memory. See the Win32 VirtualAlloc function.</param>
        /// <param name="virt">[out] A pointer to a CLRDATA_ADDRESS value that specifies the actual starting address of the allocated memory.</param>
        /// <remarks>
        /// The AllocVirtual method serves as a logical wrapper for the Win32 VirtualAlloc function. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT AllocVirtual(
            [In] ulong addr,
            [In] uint size,
            [In] uint typeFlags,
            [In] uint protectFlags,
            out ulong virt);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to free memory that was previously allocated in the address space of the target process.
        /// </summary>
        /// <param name="addr">[in] A CLRDATA_ADDRESS value that specifies the starting address of the memory to be freed.</param>
        /// <param name="size">[in] The size, in bytes, of the memory to be freed.</param>
        /// <param name="typeFlags">[in] Flags that control the freeing of memory. See the Win32 VirtualFree function.</param>
        /// <remarks>
        /// The FreeVirtual method serves as a logical wrapper for the Win32 VirtualFree function. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT FreeVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the exception record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the exception record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be equal to sizeof(MINIDUMP_EXCEPTION).</param>
        /// <param name="bufferUsed">[out] A pointer to a ULONG32 type that receives the number of bytes actually written to the buffer.</param>
        /// <param name="buffer">[out] A pointer to a memory buffer that receives a copy of the exception record. The exception record is returned as a MINIDUMP_EXCEPTION type.</param>
        /// <returns>
        /// The return value is S_OK on success, or a failure HRESULT code on failure. The HRESULT codes can include but are not limited to the following:
        /// 
        /// | Return code                          | Description                                                                  |
        /// | ------------------------------------ | ---------------------------------------------------------------------------- |
        /// | S_OK                                 | Method succeeded. The exception record has been copied to the output buffer. |
        /// | HRESULT_FROM_WIN32(ERROR_NOT_FOUND)  | No exception record is associated with the target.                           |
        /// | HRESULT_FROM_WIN32(ERROR_BAD_LENGTH) | The input buffer size is not equal to sizeof(MINIDUMP_EXCEPTION).            |
        /// </returns>
        /// <remarks>
        /// MINIDUMP_EXCEPTION is a structure defined in dbghelp.h and imagehlp.h in the Windows SDK. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExceptionRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the context record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the context record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be large enough to accommodate the context record.</param>
        /// <param name="bufferUsed">[out] A pointer to a ULONG32 type that receives the number of bytes actually written to the buffer.</param>
        /// <param name="buffer">[out] A pointer to a memory buffer that receives a copy of the context record. The exception record is returned as a CONTEXT type.</param>
        /// <returns>
        /// The return value is S_OK on success, or a failure HRESULT code on failure. The HRESULT codes can include but are not limited to the following:
        /// 
        /// | Return code                          | Description                                                                  |
        /// | ------------------------------------ | ---------------------------------------------------------------------------- |
        /// | S_OK                                 | Method succeeded. The context record has been copied to the output buffer.   |
        /// | HRESULT_FROM_WIN32(ERROR_NOT_FOUND)  | No context record is associated with the target.                             |
        /// | HRESULT_FROM_WIN32(ERROR_BAD_LENGTH) | The input buffer size is not large enough to accommodate the context record. |
        /// </returns>
        /// <remarks>
        /// CONTEXT is a platform-specific structure defined in headers provided by the Windows SDK. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExceptionContextRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to get the ID of the thread that threw the exception.
        /// </summary>
        /// <param name="threadID">[out] The ID of the thread that threw the exception.</param>
        /// <returns>
        /// The return value is S_OK on success, or a failure HRESULT code on failure. The HRESULT codes can include but are not limited to the following:
        /// 
        /// | Return code                         | Description                                         |
        /// | ----------------------------------- | --------------------------------------------------- |
        /// | S_OK                                | Method succeeded.                                   |
        /// | HRESULT_FROM_WIN32(ERROR_NOT_FOUND) | Could not find a valid thread ID for the exception. |
        /// </returns>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExceptionThreadID(out uint threadID);
    }
}