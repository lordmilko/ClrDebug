﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Serves as the abstract base interface for the enumerators that are used by a debugging application.
    /// </summary>
    /// <remarks>
    /// The following enumerators derive from ICorDebugEnum:
    /// </remarks>
    [Guid("CC7BCB01-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorDebugEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugEnum"/> object that is a copy of this <see cref="ICorDebugEnum"/> object.</param>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pcelt);
    }
}
