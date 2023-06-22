using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of the <see cref="ICorPublishEnum"/> interface that provides methods to traverse a collection of <see cref="ICorPublishProcess"/> objects.
    /// </summary>
    /// <remarks>
    /// The ICorPublishProcessEnum interface implements the methods of the abstract interface, <see cref="ICorPublishEnum"/>.
    /// An ICorPublishProcessEnum instance is created by the <see cref="ICorPublish.EnumProcesses"/> method. The traversal
    /// of the collection of ICorPublishProcess objects is based on the filter criteria given at the time the ICorPublishProcessEnum
    /// instance was created.
    /// </remarks>
    [Guid("A37FBD41-5A69-11D3-8F84-00A0C9B4D50C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorPublishProcessEnum : ICorPublishEnum
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
        /// Moves the cursor of to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorPublishEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an ICorPublishEnum object that is a copy of this ICorPublishEnum object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);

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
        /// Gets the specified number of processes from the collection, starting at the current cursor position.
        /// </summary>
        /// <param name="celt">[in] The number of processes to be retrieved.</param>
        /// <param name="objects">[out] A pointer to the array of retrieved <see cref="ICorPublishProcess"/> objects, each of which represents a process.</param>
        /// <param name="pceltFetched">[out] Pointer to the number of processes actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess objects,
            [Out] out int pceltFetched);
    }
}
