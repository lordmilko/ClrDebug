﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents the debug symbol information for a static field.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugStaticFieldSymbol"/> interface is used to retrieve the debug symbol information for a static field.
    /// </remarks>
    [Guid("CBF9DA63-F68D-4BBB-A21C-15A45EAADF5B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugStaticFieldSymbol
    {
        /// <summary>
        /// Gets the name of the static field.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">[out] A character array that stores the returned name.</param>
        [PreserveSig]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the size in bytes of the static field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        [PreserveSig]
        HRESULT GetSize(
            [Out] out int pcbSize);

        /// <summary>
        /// Gets the address of a static field.
        /// </summary>
        /// <param name="pRVA">[out] A pointer to the relative virtual address (RVA) of the static field.</param>
        [PreserveSig]
        HRESULT GetAddress(
            [Out] out long pRVA);
    }
}
