using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides a callback interface that provides access to a particular target process.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugDataTarget"/> and its methods have the following characteristics: The target process should be stopped and
    /// not changed in any way while ICorDebug* interfaces (and therefore <see cref="ICorDebugDataTarget"/> methods) are being called.
    /// If the target is a live process and its state changes, the <see cref="ICLRDebugging.OpenVirtualProcess"/> method
    /// has to be called again to provide a replacement <see cref="ICorDebugProcess"/> instance.
    /// </remarks>
    [Guid("FE06DC28-49FB-4636-A4A3-E80DB4AE116C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugDataTarget
    {
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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPlatform(
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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ReadVirtual(
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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext(
            [In] int dwThreadId,
            [In] ContextFlags contextFlags,
            [In] int contextSize,
            [Out] IntPtr pContext);
    }
}
