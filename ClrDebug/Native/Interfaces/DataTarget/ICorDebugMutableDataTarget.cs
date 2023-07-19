using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDataTarget"/> interface to support mutable data targets.
    /// </summary>
    /// <remarks>
    /// This extension to the <see cref="ICorDebugDataTarget"/> interface can be implemented by debugging tools that wish
    /// to modify the target process (for example, to perform live invasive debugging). All of these methods are optional
    /// in the sense that no core inspection-based debugging functionality is lost by not implementing this interface or
    /// by the failure of calls to these methods. Any failure <see cref="HRESULT"/> from these methods will propagate out as the <see cref="HRESULT"/>
    /// from the <see cref="ICorDebug"/> method call. Note that a single <see cref="ICorDebug"/> method call may result in multiple mutations, and
    /// that there is no mechanism for ensuring related mutations are applied transactionally (all-or-none). This means
    /// that if a mutation fails after others (for the same <see cref="ICorDebug"/> call) have succeeded, the target process may be left
    /// in an inconsistent state and debugging may become unreliable.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A1B8A756-3CB6-4CCB-979F-3DF999673A59")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugMutableDataTarget : ICorDebugDataTarget
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Provides information about the platform, including processor architecture and operating system, on which the target process is running.
        /// </summary>
        /// <param name="pTargetPlatform">[out] A pointer to a <see cref="CorDebugPlatform"/> enumeration that describes the target platform.</param>
        /// <remarks>
        /// The CorDebugPlatformEnum enumeration return value is used by the <see cref="ICorDebug"/> interface to determine
        /// details of the target process such as its pointer size, address space layout, register set, instruction format,
        /// context layout, and calling conventions. The pTargetPlatform value may refer to a platform that is being emulated
        /// for the target instead of specifying the actual hardware in use. For example, a process that is running in the
        /// Windows on Windows (WOW) environment on a 64-bit edition of the Windows operating system should use the CORDB_PLATFORM_WINDOWS_X86
        /// value of the <see cref="CorDebugPlatform"/> enumeration. This method must succeed. If it fails, the target platform
        /// is unusable. The method may fail for the following reasons:
        /// </remarks>
        [PreserveSig]
        new HRESULT GetPlatform(
            [Out] out CorDebugPlatform pTargetPlatform);

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.
        /// </summary>
        /// <param name="address">[in] The start address of requested memory.</param>
        /// <param name="pBuffer">[out] The buffer where the memory will be stored.</param>
        /// <param name="bytesRequested">[in] The number of bytes to get from the target address.</param>
        /// <param name="pBytesRead">[out] The number of bytes actually read from the target address. This can be fewer than bytesRequested.</param>
        /// <remarks>
        /// If the first byte (at the specified start address) can be read, the call should return success (to support efficient
        /// reading of data structures with self-describing length, like null-terminated strings).
        /// </remarks>
        [PreserveSig]
        new HRESULT ReadVirtual(
            [In] CORDB_ADDRESS address,
            [Out] IntPtr pBuffer,
            [In] int bytesRequested,
            [Out] out int pBytesRead);

        /// <summary>
        /// Returns the current thread context for the specified thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">[in] A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="contextSize">[in] The size of pContext.</param>
        /// <param name="pContext">[out] The buffer where the thread context will be stored.</param>
        /// <remarks>
        /// On Windows platforms, pContext must be a CONTEXT structure (defined in WinNT.h) that is appropriate for the machine
        /// type specified by the <see cref="GetPlatform"/> method. contextFlags must have the same values as the ContextFlags
        /// field of the CONTEXT structure. The CONTEXT structure is processor-specific; refer to the WinNT.h file for details.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetThreadContext(
            [In] int dwThreadId,
            [In] ContextFlags contextFlags,
            [In] int contextSize,
            [Out] IntPtr pContext);
#endif

        /// <summary>
        /// Writes memory into the target process address space.
        /// </summary>
        /// <param name="address">[in] The address at which to write the contents of pBuffer.</param>
        /// <param name="pBuffer">[in] A pointer to a byte array that contains the bytes to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes in pBuffer.</param>
        /// <returns>S_OK on success, or any other <see cref="HRESULT"/> on failure.</returns>
        /// <remarks>
        /// If any bytes cannot be written, the method call fails without changing any bytes in the target address space. (Otherwise,
        /// the target would be in an inconsistent state that makes further debugging unreliable.)
        /// </remarks>
        [PreserveSig]
        HRESULT WriteVirtual(
            [In] CORDB_ADDRESS address,
            [In] IntPtr pBuffer,
            [In] int bytesRequested);

        /// <summary>
        /// Sets the context (register values) for a thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The operating system-defined thread identifier.</param>
        /// <param name="contextSize">[in] The size of the pContext buffer to be written.</param>
        /// <param name="pContext">[in] A pointer to the bytes to be written.</param>
        /// <remarks>
        /// The SetThreadContext method updates the current context for the thread specified by the operating system-defined
        /// dwThreadID argument. The format of the context record is determined by the platform indicated by the <see cref="ICorDebugDataTarget.GetPlatform"/>
        /// method. On Windows, this is a CONTEXT structure.
        /// </remarks>
        [PreserveSig]
        HRESULT SetThreadContext(
            [In] int dwThreadId,
            [In] int contextSize,
            [In] IntPtr pContext);

        /// <summary>
        /// Changes the continuation status for the outstanding debug event on the specified thread.
        /// </summary>
        /// <param name="dwThreadId">The operating system-defined thread identifier.</param>
        /// <param name="continueStatus">A COREDB_CONTINUE_STATUS value that represents the new requested continuation status.</param>
        /// <remarks>
        /// The debugger calls the ContinueStatusChanged method when it calls an <see cref="ICorDebug"/> method that requires the current
        /// debug event to be handled in a way that is potentially different from the way in which it normally would be handled.
        /// For example, if there is an outstanding exception, and the debugger requests an operation that would cancel the
        /// exception (such as <see cref="ICorDebugILFrame.SetIP"/> or FuncEval), this API is used to request that the exception
        /// be cancelled.
        /// </remarks>
        [PreserveSig]
        HRESULT ContinueStatusChanged(
            [In] int dwThreadId,
            [In] int continueStatus);
    }
}
