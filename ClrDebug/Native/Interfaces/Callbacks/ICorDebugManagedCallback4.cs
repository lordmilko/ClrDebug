﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("322911AE-16A5-49BA-84A3-ED69678138A3")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugManagedCallback4
    {
        [PreserveSig]
        HRESULT BeforeGarbageCollection(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess);

        [PreserveSig]
        HRESULT AfterGarbageCollection(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess);

        [PreserveSig]
        HRESULT DataBreakpoint(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [In] IntPtr pContext,
            [In] int contextSize);
    }
}
