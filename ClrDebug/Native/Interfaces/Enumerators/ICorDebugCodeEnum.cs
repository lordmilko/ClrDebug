﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Implements "ICorDebugEnum" methods, and enumerates "ICorDebugCode" arrays.
    /// </summary>
    [Guid("55E96461-9645-45E4-A2FF-0367877ABCDE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugCodeEnum : ICorDebugEnum
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
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorDebugEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugEnum"/> object that is a copy of this <see cref="ICorDebugEnum"/> object.</param>
        [PreserveSig]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        new HRESULT GetCount(
            [Out] out int pcelt);
#endif

        /// <summary>
        /// Gets the specified number of "ICorDebugCode" instances from the enumeration, starting at the current position.
        /// </summary>
        /// <param name="celt">[in] The number of <see cref="ICorDebugCode"/> instances to be retrieved.</param>
        /// <param name="values">[out] An array of pointers, each of which points to an <see cref="ICorDebugCode"/> object.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="ICorDebugCode"/> instances actually returned. This value may be null if celt is one.</param>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [MarshalAs(UnmanagedType.Interface), Out] out ICorDebugCode values,
            [Out] out int pceltFetched);
    }
}
