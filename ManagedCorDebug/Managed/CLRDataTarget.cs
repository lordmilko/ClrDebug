using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for interaction with a target item of the common language runtime (CLR).
    /// </summary>
    /// <remarks>
    /// The API client (that is, the debugger) must implement this interface as appropriate for the particular target item.
    /// For example, a live process would have an implementation different from that of a memory dump.
    /// </remarks>
    public class CLRDataTarget : ComObject<ICLRDataTarget>
    {
        public CLRDataTarget(ICLRDataTarget raw) : base(raw)
        {
        }

        #region ICLRDataTarget
        #region GetMachineType

        /// <summary>
        /// Gets the identifier for the kind of instruction set that the target process is using.
        /// </summary>
        public uint MachineType
        {
            get
            {
                HRESULT hr;
                uint machineType;

                if ((hr = TryGetMachineType(out machineType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return machineType;
            }
        }

        /// <summary>
        /// Gets the identifier for the kind of instruction set that the target process is using.
        /// </summary>
        /// <param name="machineType">[out] A pointer to a value that indicates the instruction set that the target process is using. The returned machineType is one of the IMAGE_FILE_MACHINE constants, which are defined in the WinNT.h header file.</param>
        public HRESULT TryGetMachineType(out uint machineType)
        {
            /*HRESULT GetMachineType(out uint machineType);*/
            return Raw.GetMachineType(out machineType);
        }

        #endregion
        #region GetPointerSize

        /// <summary>
        /// Gets the size, in bytes, of the pointer type that the target process uses. This method is called by the common language runtime data access services.
        /// </summary>
        public uint PointerSize
        {
            get
            {
                HRESULT hr;
                uint pointerSize;

                if ((hr = TryGetPointerSize(out pointerSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pointerSize;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the pointer type that the target process uses. This method is called by the common language runtime data access services.
        /// </summary>
        /// <param name="pointerSize">[out] A pointer to an integer value that specifies the size, in bytes, of a pointer on the target process.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public HRESULT TryGetPointerSize(out uint pointerSize)
        {
            /*HRESULT GetPointerSize(out uint pointerSize);*/
            return Raw.GetPointerSize(out pointerSize);
        }

        #endregion
        #region GetCurrentThreadID

        /// <summary>
        /// Gets the operating system identifier for the current thread.
        /// </summary>
        public uint CurrentThreadID
        {
            get
            {
                HRESULT hr;
                uint threadID;

                if ((hr = TryGetCurrentThreadID(out threadID)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return threadID;
            }
        }

        /// <summary>
        /// Gets the operating system identifier for the current thread.
        /// </summary>
        /// <param name="threadID">[out] A pointer to the operating system identifier of the current thread for the target process.</param>
        /// <remarks>
        /// If there is no current thread for the target process, the GetCurrentThreadID method may fail.
        /// </remarks>
        public HRESULT TryGetCurrentThreadID(out uint threadID)
        {
            /*HRESULT GetCurrentThreadID(out uint threadID);*/
            return Raw.GetCurrentThreadID(out threadID);
        }

        #endregion
        #region GetImageBase

        /// <summary>
        /// Gets the base memory address of the specified image.
        /// </summary>
        /// <param name="imagePath">[in] The file name of the image, including its path.</param>
        /// <returns>[out] A pointer to a CLRDATA_ADDRESS that stores the base address of the image.</returns>
        /// <remarks>
        /// The image file name may or may not have a path. If a path is specified, matching is done on the whole path; otherwise,
        /// matching is done only on the file name.
        /// </remarks>
        public ulong GetImageBase(string imagePath)
        {
            HRESULT hr;
            ulong baseAddress;

            if ((hr = TryGetImageBase(imagePath, out baseAddress)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return baseAddress;
        }

        /// <summary>
        /// Gets the base memory address of the specified image.
        /// </summary>
        /// <param name="imagePath">[in] The file name of the image, including its path.</param>
        /// <param name="baseAddress">[out] A pointer to a CLRDATA_ADDRESS that stores the base address of the image.</param>
        /// <remarks>
        /// The image file name may or may not have a path. If a path is specified, matching is done on the whole path; otherwise,
        /// matching is done only on the file name.
        /// </remarks>
        public HRESULT TryGetImageBase(string imagePath, out ulong baseAddress)
        {
            /*HRESULT GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);*/
            return Raw.GetImageBase(imagePath, out baseAddress);
        }

        #endregion
        #region ReadVirtual

        /// <summary>
        /// Reads data from the specified virtual memory address into the specified buffer.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="bytesRequested">[in] The length of the buffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public ReadVirtualResult ReadVirtual(ulong address, uint bytesRequested)
        {
            HRESULT hr;
            ReadVirtualResult result;

            if ((hr = TryReadVirtual(address, bytesRequested, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Reads data from the specified virtual memory address into the specified buffer.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="bytesRequested">[in] The length of the buffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryReadVirtual(ulong address, uint bytesRequested, out ReadVirtualResult result)
        {
            /*HRESULT ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);*/
            byte buffer;
            uint bytesRead;
            HRESULT hr = Raw.ReadVirtual(address, out buffer, bytesRequested, out bytesRead);

            if (hr == HRESULT.S_OK)
                result = new ReadVirtualResult(buffer, bytesRead);
            else
                result = default(ReadVirtualResult);

            return hr;
        }

        #endregion
        #region WriteVirtual

        /// <summary>
        /// Writes data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="buffer">[in] A pointer to a buffer that stores the data to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes to be written.</param>
        /// <returns>[out] A pointer to the actual number of bytes that were written.</returns>
        public uint WriteVirtual(ulong address, IntPtr buffer, uint bytesRequested)
        {
            HRESULT hr;
            uint bytesWritten;

            if ((hr = TryWriteVirtual(address, buffer, bytesRequested, out bytesWritten)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return bytesWritten;
        }

        /// <summary>
        /// Writes data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="buffer">[in] A pointer to a buffer that stores the data to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes to be written.</param>
        /// <param name="bytesWritten">[out] A pointer to the actual number of bytes that were written.</param>
        public HRESULT TryWriteVirtual(ulong address, IntPtr buffer, uint bytesRequested, out uint bytesWritten)
        {
            /*HRESULT WriteVirtual([In] ulong address, [In] IntPtr buffer, [In] uint bytesRequested, out uint bytesWritten);*/
            return Raw.WriteVirtual(address, buffer, bytesRequested, out bytesWritten);
        }

        #endregion
        #region GetTLSValue

        /// <summary>
        /// Gets a value from the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <returns>[out] A pointer to a CLRDATA_ADDRESS value that specifies the value returned from the given TLS location.</returns>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public ulong GetTLSValue(uint threadID, uint index)
        {
            HRESULT hr;
            ulong value;

            if ((hr = TryGetTLSValue(threadID, index, out value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return value;
        }

        /// <summary>
        /// Gets a value from the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <param name="value">[out] A pointer to a CLRDATA_ADDRESS value that specifies the value returned from the given TLS location.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public HRESULT TryGetTLSValue(uint threadID, uint index, out ulong value)
        {
            /*HRESULT GetTLSValue([In] uint threadID, [In] uint index, out ulong value);*/
            return Raw.GetTLSValue(threadID, index, out value);
        }

        #endregion
        #region SetTLSValue

        /// <summary>
        /// Sets a value in the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <param name="value">[in] A CLRDATA_ADDRESS value that specifies the value to place in the given TLS location.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public void SetTLSValue(uint threadID, uint index, ulong value)
        {
            HRESULT hr;

            if ((hr = TrySetTLSValue(threadID, index, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets a value in the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="index">[in] The index of the location. This value must be a valid index in the local store of the specified thread.</param>
        /// <param name="value">[in] A CLRDATA_ADDRESS value that specifies the value to place in the given TLS location.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public HRESULT TrySetTLSValue(uint threadID, uint index, ulong value)
        {
            /*HRESULT SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);*/
            return Raw.SetTLSValue(threadID, index, value);
        }

        #endregion
        #region GetThreadContext

        /// <summary>
        /// Gets the current execution context for the given thread in the target process. This method is called by the common language runtime data access services.
        /// </summary>
        /// <param name="threadID">[in] The operating system identifier of a thread in the target process.</param>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context to return. The implementation will return at least these parts of the context.</param>
        /// <param name="contextSize">[in] The size of the context.</param>
        /// <returns>[out] Pointer to a buffer in which to place the context. The data in the context buffer must be in the format of the Win32 CONTEXT structure.<para/>
        /// The context specifies processor-specific register data, so the definition of the Win32 CONTEXT structure depends on the processor's architecture.<para/>
        /// Refer to the WinNT.h header file for the definition of the Win32 CONTEXT structure.</returns>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public byte GetThreadContext(uint threadID, uint contextFlags, uint contextSize)
        {
            HRESULT hr;
            byte context;

            if ((hr = TryGetThreadContext(threadID, contextFlags, contextSize, out context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return context;
        }

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
        public HRESULT TryGetThreadContext(uint threadID, uint contextFlags, uint contextSize, out byte context)
        {
            /*HRESULT GetThreadContext([In] uint threadID, [In] uint contextFlags, [In] uint contextSize, out byte context);*/
            return Raw.GetThreadContext(threadID, contextFlags, contextSize, out context);
        }

        #endregion
        #region SetThreadContext

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
        public void SetThreadContext(uint threadID, uint contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(threadID, contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TrySetThreadContext(uint threadID, uint contextSize, IntPtr context)
        {
            /*HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] IntPtr context);*/
            return Raw.SetThreadContext(threadID, contextSize, context);
        }

        #endregion
        #region Request

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to request an operation, as defined by the implementation.
        /// </summary>
        /// <param name="reqCode">[in] User-defined.</param>
        /// <param name="inBufferSize">[in] The size of the input buffer, which is used for the incoming request.</param>
        /// <param name="inBuffer">[in] A buffer containing the request.</param>
        /// <param name="outBufferSize">[in] The size of the output buffer, which is used for the response.</param>
        /// <returns>[out] A Buffer containing the response.</returns>
        /// <remarks>
        /// The Request method facilitates the addition of unspecified custom operations. That is, this method provides extensibility
        /// without requiring revision of the interface definition. This method is implemented by the writer of the debugging
        /// application.
        /// </remarks>
        public byte Request(uint reqCode, uint inBufferSize, IntPtr inBuffer, uint outBufferSize)
        {
            HRESULT hr;
            byte outBuffer;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

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
        public HRESULT TryRequest(uint reqCode, uint inBufferSize, IntPtr inBuffer, uint outBufferSize, out byte outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] IntPtr inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer);
        }

        #endregion
        #endregion
        #region ICLRDataTarget2

        public ICLRDataTarget2 Raw2 => (ICLRDataTarget2) Raw;

        #region AllocVirtual

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to allocate memory in the address space of this target process.
        /// </summary>
        /// <param name="addr">[in] A CLRDATA_ADDRESS value that specifies the requested starting address of the memory to be allocated.</param>
        /// <param name="size">[in] The size, in bytes, of the memory to be allocated.</param>
        /// <param name="typeFlags">[in] Flags that control the allocation of memory. See the Win32 VirtualAlloc function.</param>
        /// <param name="protectFlags">[in] The protection attributes for the allocated memory. See the Win32 VirtualAlloc function.</param>
        /// <returns>[out] A pointer to a CLRDATA_ADDRESS value that specifies the actual starting address of the allocated memory.</returns>
        /// <remarks>
        /// The AllocVirtual method serves as a logical wrapper for the Win32 VirtualAlloc function. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        public ulong AllocVirtual(ulong addr, uint size, uint typeFlags, uint protectFlags)
        {
            HRESULT hr;
            ulong virt;

            if ((hr = TryAllocVirtual(addr, size, typeFlags, protectFlags, out virt)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return virt;
        }

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
        public HRESULT TryAllocVirtual(ulong addr, uint size, uint typeFlags, uint protectFlags, out ulong virt)
        {
            /*HRESULT AllocVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags, [In] uint protectFlags, out ulong virt);*/
            return Raw2.AllocVirtual(addr, size, typeFlags, protectFlags, out virt);
        }

        #endregion
        #region FreeVirtual

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
        public void FreeVirtual(ulong addr, uint size, uint typeFlags)
        {
            HRESULT hr;

            if ((hr = TryFreeVirtual(addr, size, typeFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryFreeVirtual(ulong addr, uint size, uint typeFlags)
        {
            /*HRESULT FreeVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags);*/
            return Raw2.FreeVirtual(addr, size, typeFlags);
        }

        #endregion
        #endregion
        #region ICLRDataTarget3

        public ICLRDataTarget3 Raw3 => (ICLRDataTarget3) Raw;

        #region GetExceptionThreadID

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to get the ID of the thread that threw the exception.
        /// </summary>
        public uint ExceptionThreadID
        {
            get
            {
                HRESULT hr;
                uint threadID;

                if ((hr = TryGetExceptionThreadID(out threadID)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return threadID;
            }
        }

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
        public HRESULT TryGetExceptionThreadID(out uint threadID)
        {
            /*HRESULT GetExceptionThreadID(out uint threadID);*/
            return Raw3.GetExceptionThreadID(out threadID);
        }

        #endregion
        #region GetExceptionRecord

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the exception record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the exception record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be equal to sizeof(MINIDUMP_EXCEPTION).</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// MINIDUMP_EXCEPTION is a structure defined in dbghelp.h and imagehlp.h in the Windows SDK. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        public GetExceptionRecordResult GetExceptionRecord(uint bufferSize)
        {
            HRESULT hr;
            GetExceptionRecordResult result;

            if ((hr = TryGetExceptionRecord(bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the exception record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the exception record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be equal to sizeof(MINIDUMP_EXCEPTION).</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        public HRESULT TryGetExceptionRecord(uint bufferSize, out GetExceptionRecordResult result)
        {
            /*HRESULT GetExceptionRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);*/
            uint bufferUsed;
            byte buffer;
            HRESULT hr = Raw3.GetExceptionRecord(bufferSize, out bufferUsed, out buffer);

            if (hr == HRESULT.S_OK)
                result = new GetExceptionRecordResult(bufferUsed, buffer);
            else
                result = default(GetExceptionRecordResult);

            return hr;
        }

        #endregion
        #region GetExceptionContextRecord

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the context record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the context record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be large enough to accommodate the context record.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// CONTEXT is a platform-specific structure defined in headers provided by the Windows SDK. This method is implemented
        /// by the writer of the debugging application.
        /// </remarks>
        public GetExceptionContextRecordResult GetExceptionContextRecord(uint bufferSize)
        {
            HRESULT hr;
            GetExceptionContextRecordResult result;

            if ((hr = TryGetExceptionContextRecord(bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the context record associated with the target process.<para/>
        /// For example, for a dump target, this would be equivalent to the context record passed in via the ExceptionParam argument to the MiniDumpWriteDump function in the Windows Debug Help Library (DbgHelp).
        /// </summary>
        /// <param name="bufferSize">[in] The input buffer size, in bytes. This must be large enough to accommodate the context record.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        public HRESULT TryGetExceptionContextRecord(uint bufferSize, out GetExceptionContextRecordResult result)
        {
            /*HRESULT GetExceptionContextRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);*/
            uint bufferUsed;
            byte buffer;
            HRESULT hr = Raw3.GetExceptionContextRecord(bufferSize, out bufferUsed, out buffer);

            if (hr == HRESULT.S_OK)
                result = new GetExceptionContextRecordResult(bufferUsed, buffer);
            else
                result = default(GetExceptionContextRecordResult);

            return hr;
        }

        #endregion
        #endregion
    }
}