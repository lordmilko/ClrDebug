using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for objects on the managed heap. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugHeapEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugHeapEnum"/> instance is populated
    /// with <see cref="COR_HEAPOBJECT"/> instances by calling the <see cref="ICorDebugProcess5.EnumerateHeap"/> method.
    /// Each <see cref="COR_HEAPOBJECT"/> instance in the collection represents either a live object on the heap or an
    /// object that is not rooted by any object but has not yet been collected by the garbage collector. The <see cref="COR_HEAPOBJECT"/>
    /// objects in the collection can be enumerated by calling the <see cref="Next"/> method.
    /// </remarks>
    [Guid("76D7DAB8-D044-11DF-9A15-7E29DFD72085")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugHeapEnum : ICorDebugEnum
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip(
            [In] int celt);

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
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount(
            [Out] out int pcelt);
#endif

        /// <summary>
        /// Gets the specified number of <see cref="COR_HEAPOBJECT"/> instances that contain information about objects on the managed heap.
        /// </summary>
        /// <param name="celt">[in] The number of objects to be retrieved.</param>
        /// <param name="objects">[out] An array of pointers, each of which points to a <see cref="COR_HEAPOBJECT"/> object that provides information about an object on the managed heap.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="COR_HEAPOBJECT"/> objects actually returned in objects. This value may be null if celt is 1.</param>
        /// <remarks>
        /// The COR_HEAPOBJECT.type field is the identifier of a nested reference-counted COM interface. This reference must
        /// be released by the caller of ICorDebugHeapEnum::Next.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [Out] out COR_HEAPOBJECT objects,
            [Out] out int pceltFetched);
    }
}
