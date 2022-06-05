using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a callback interface that provides access to a particular target process.
    /// </summary>
    /// <remarks>
    /// ICorDebugDataTarget and its methods have the following characteristics: The target process should be stopped and
    /// not changed in any way while ICorDebug* interfaces (and therefore ICorDebugDataTarget methods) are being called.
    /// If the target is a live process and its state changes, the <see cref="ICLRDebugging.OpenVirtualProcess"/> method
    /// has to be called again to provide a replacement ICorDebugProcess instance.
    /// </remarks>
    [Guid("FE06DC28-49FB-4636-A4A3-E80DB4AE116C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugDataTarget
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPlatform(out CorDebugPlatform pTargetPlatform);

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
        HRESULT ReadVirtual([In] ulong address, out byte pBuffer, [In] uint bytesRequested, out uint pBytesRead);

        /// <summary>
        /// Returns the current thread context for the specified thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">[in] A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="contextSize">[in] The size of pContext.</param>
        /// <param name="pContext">[out] The buffer where the thread context will be stored.</param>
        /// <remarks>
        /// On Windows platforms, pContext must be a CONTEXT structure (defined in WinNT.h) that is appropriate for the machine
        /// type specified by the <see cref="ICorDebugDataTarget.GetPlatform"/> method. contextFlags must have the same values
        /// as the ContextFlags field of the CONTEXT structure. The CONTEXT structure is processor-specific; refer to the WinNT.h
        /// file for details.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext([In] uint dwThreadId, [In] uint contextFlags, [In] uint contextSize, out byte pContext);
    }
}