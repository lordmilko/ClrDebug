using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides an enumerator for a list of <see cref="CorDebugBlockingObject"/> structures. This interface is a subclass of the ICorDebugEnum interface.
    /// </summary>
    /// <remarks>
    /// Each CorDebugBlockingObject structure represents an object that is blocking a thread.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("976A6278-134A-4A81-81A3-8F277943F4C3")]
    [ComImport]
    public interface ICorDebugBlockingObjectEnum : ICorDebugEnum
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
        /// Gets the specified number of <see cref="CorDebugBlockingObject"/> objects from the enumeration, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of objects to retrieve.</param>
        /// <param name="values">[out] An array of pointers to <see cref="CorDebugBlockingObject"/> objects.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of objects that were retrieved.</param>
        /// <remarks>
        /// This method functions like a typical COM enumerator. The input array values must be at least of size celt. The
        /// array will be filled with either the next celt values in the enumeration or with all remaining values if fewer
        /// than celt remain. When this method returns, pceltFetched will be filled with the number of values that were retrieved.
        /// If values contains invalid pointers or points to a buffer that is smaller than celt, or if pceltFetched is an invalid
        /// pointer, the result is undefined.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out] out CorDebugBlockingObject values, out uint pceltFetched);
    }
}