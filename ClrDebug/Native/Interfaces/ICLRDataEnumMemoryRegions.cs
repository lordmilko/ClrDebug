﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method to enumerate regions of memory that are specified by callers.
    /// </summary>
    [Guid("471C35B4-7C2F-4EF0-A945-00F8C38056F1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRDataEnumMemoryRegions
    {
        /// <summary>
        /// Enumerates specified areas of memory.
        /// </summary>
        /// <param name="callback">[in] A pointer to an <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance that is called by this method for each memory region being enumerated to notify the debugger of the result.<para/>
        /// The enumeration of memory regions continues even if the callback indicates a failure.</param>
        /// <param name="miniDumpFlags">[in] Not used.</param>
        /// <param name="clrFlags">[in] A value of the <see cref="CLRDataEnumMemoryFlags"/> enumeration that specifies the regions of memory to be enumerated.</param>
        /// <remarks>
        /// This method uses the specified <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance to notify the caller of
        /// results.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumMemoryRegions(
            [MarshalAs(UnmanagedType.Interface), In] ICLRDataEnumMemoryRegionsCallback callback,
            [In] int miniDumpFlags,
            [In] CLRDataEnumMemoryFlags clrFlags);
    }
}
