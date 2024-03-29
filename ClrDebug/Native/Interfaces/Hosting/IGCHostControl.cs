﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method that allows the garbage collector to request the host to change the limits of virtual memory.
    /// </summary>
    [Guid("5513D564-8374-4CB9-AED9-0083F4160A1D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IGCHostControl
    {
        /// <summary>
        /// Requests the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="sztMaxVirtualMemMB">[in] The requested size of memory to be allocated.</param>
        /// <param name="psztNewMaxVirtualMemMB">[in, out] A pointer to the actual size of memory allocated.</param>
        [PreserveSig]
        HRESULT RequestVirtualMemLimit(
            [In] int sztMaxVirtualMemMB,
            [Out] out int psztNewMaxVirtualMemMB);
    }
}
