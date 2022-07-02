using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator for the memory regions of the managed heap. This interface is a subclass of the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugHeapSegmentEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugHeapSegmentEnum"/> instance
    /// is populated with <see cref="COR_SEGMENT"/> instances by calling the <see cref="ICorDebugProcess5.EnumerateHeapRegions"/>
    /// method. The <see cref="COR_SEGMENT"/> objects in the collection can be enumerated by calling the <see cref="Next"/>
    /// method. An <see cref="ICorDebugHeapSegmentEnum"/> collection object enumerates all memory regions that may contain managed objects,
    /// but it does not guarantee that managed objects actually reside in those regions. It may include information about
    /// empty or reserved memory regions.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A2FA0F8E-D045-11DF-AC8E-CE2ADFD72085")]
    [ComImport]
    public interface ICorDebugHeapSegmentEnum : ICorDebugEnum
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
        /// Gets the specified number of <see cref="COR_SEGMENT"/> instances that contain information about memory regions of the managed heap.
        /// </summary>
        /// <param name="celt">[in] The number of segments to be retrieved.</param>
        /// <param name="segments">[out] An array of pointers, each of which points to a <see cref="COR_SEGMENT"/> object that provides information about a region of memory in the managed heap.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="COR_SEGMENT"/> objects actually returned in segments. This value may be null if celt is 1.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] int celt, [MarshalAs(UnmanagedType.Interface), Out] out COR_SEGMENT segments, [Out] out int pceltFetched);
    }
}