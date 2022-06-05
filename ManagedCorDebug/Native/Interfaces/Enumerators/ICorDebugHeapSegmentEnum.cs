using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides an enumerator for the memory regions of the managed heap. This interface is a subclass of the ICorDebugEnum interface.
    /// </summary>
    /// <remarks>
    /// The ICorDebugHeapSegmentEnum interface implements the ICorDebugEnum interface. An ICorDebugHeapSegmentEnum instance
    /// is populated with <see cref="COR_SEGMENT"/> instances by calling the <see cref="ICorDebugProcess5.EnumerateHeapRegions"/>
    /// method. The <see cref="COR_SEGMENT"/> objects in the collection can be enumerated by calling the <see cref="Next"/>
    /// method. An ICorDebugHeapSegmentEnum collection object enumerates all memory regions that may contain managed objects,
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

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out] out COR_SEGMENT segments, out uint pceltFetched);
    }
}