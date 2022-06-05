using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides an enumerator for objects that will be garbage-collected.
    /// </summary>
    /// <remarks>
    /// The ICorDebugGCReferenceEnum interface implements the "ICorDebugEnum" interface. An ICorDebugGCReferenceEnum instance
    /// is populated with <see cref="COR_GC_REFERENCE"/> instances by calling the <see cref="ICorDebugProcess5.EnumerateGCReferences"/>
    /// method. <see cref="COR_GC_REFERENCE"/> objects can be enumerated by calling the <see cref="ICorDebugGCReferenceEnum.Next"/>
    /// method. The <see cref="COR_GC_REFERENCE"/> objects in the collection populated by this method represent three kinds
    /// of objects:
    /// </remarks>
    [Guid("7F3C24D3-7E1D-4245-AC3A-F72F8859C80C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugGCReferenceEnum : ICorDebugEnum
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
        /// Gets the specified number of <see cref="COR_GC_REFERENCE"/> instances that contain information about objects that will be garbage-collected.
        /// </summary>
        /// <param name="celt">[in] The number of roots to be retrieved.</param>
        /// <param name="roots">[out] An array of pointers, each of which points to a <see cref="COR_GC_REFERENCE"/> object that represents the root of an object to be garbage-collected.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="COR_GC_REFERENCE"/> objects actually returned in roots. This value may be null if celt is 1.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out] out COR_GC_REFERENCE roots, out uint pceltFetched);
    }
}