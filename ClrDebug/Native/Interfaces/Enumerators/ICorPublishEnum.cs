﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Serves as the abstract base interface for the enumerators that are used in the publishing of information about processes and application domains.
    /// </summary>
    /// <remarks>
    /// The following enumerators derive from ICorPublishEnum:
    /// </remarks>
    [Guid("C0B22967-5A69-11D3-8F84-00A0C9B4D50C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorPublishEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the cursor of to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorPublishEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an ICorPublishEnum object that is a copy of this ICorPublishEnum object.</param>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pcelt);
    }
}
