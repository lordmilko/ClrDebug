using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an in-memory buffer.
    /// </summary>
    [Guid("677888B3-D160-4B8C-A73B-D79E6AAA1D13")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugMemoryBuffer
    {
        /// <summary>
        /// Gets the starting address of the memory buffer.
        /// </summary>
        /// <param name="address">[out] A pointer to the starting address of the memory buffer.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStartAddress(out IntPtr address);

        /// <summary>
        /// Gets the size of the memory buffer in bytes.
        /// </summary>
        /// <param name="pcbBufferLength">[out] A pointer to the size of the memory buffer.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(out uint pcbBufferLength);
    }
}