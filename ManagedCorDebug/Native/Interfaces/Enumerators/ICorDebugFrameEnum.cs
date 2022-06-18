using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates <see cref="ICorDebugFrame"/> arrays.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCB07-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugFrameEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip([In] int celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorDebugEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugEnum"/> object that is a copy of this <see cref="ICorDebugEnum"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount([Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of <see cref="ICorDebugFrame"/> instances, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of <see cref="ICorDebugFrame"/> instances to be retrieved.</param>
        /// <param name="frames">[out] An array of pointers, each of which points to an <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="ICorDebugFrame"/> instances actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] int celt, [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugFrame frames, [Out] out int pceltFetched);
    }
}