using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("322911AE-16A5-49BA-84A3-ED69678138A3")]
    [ComImport]
    public interface ICorDebugManagedCallback4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT BeforeGarbageCollection([MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AfterGarbageCollection([MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DataBreakpoint(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [In] IntPtr pContext,
            [In] int contextSize);
    }
}
