using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Implements ICorDebugEnum methods and enumerates ICorDebugProcess arrays.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCB05-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugProcessEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip([In] uint celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this ICorDebugEnum object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an ICorDebugEnum object that is a copy of this ICorDebugEnum object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone([MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount(out uint pcelt);

        /// <summary>
        /// Gets the specified number of ICorDebugProcess instances from the enumeration, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of ICorDebugProcess instances to be retrieved.</param>
        /// <param name="processes">[out] An array of pointers, each of which points to an ICorDebugProcess object that represents a process.</param>
        /// <param name="pceltFetched">[out] Pointer to the number of ICorDebugProcess instances actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugProcess processes, out uint pceltFetched);
    }
}