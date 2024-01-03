using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// A subclass of the <see cref="ICorPublishEnum"/> interface that provides methods to traverse a collection of <see cref="ICorPublishAppDomain"/> objects that currently exist within a process.
    /// </summary>
    /// <remarks>
    /// The ICorPublishAppDomainEnum interface implements the methods of the abstract interface, <see cref="ICorPublishEnum"/>.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9F0C98F5-5A6A-11D3-8F84-00A0C9B4D50C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorPublishAppDomainEnum : ICorPublishEnum
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        new HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the cursor of to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorPublishEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an ICorPublishEnum object that is a copy of this ICorPublishEnum object.</param>
        [PreserveSig]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        new HRESULT GetCount(
            [Out] out int pcelt);
#endif

        /// <summary>
        /// Gets the specified number of application domains that currently exist in the process, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of elements to be retrieved.</param>
        /// <param name="objects">[out] A pointer to the array of retrieved <see cref="ICorPublishAppDomain"/> objects, each of which represents an application domain.</param>
        /// <param name="pceltFetched">[out] Pointer to the number of application domains actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomain objects,
            [Out] out int pceltFetched);
    }
}
