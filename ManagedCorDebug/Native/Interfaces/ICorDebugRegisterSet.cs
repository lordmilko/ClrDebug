using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCB0B-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugRegisterSet
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegistersAvailable(out ulong pAvailable);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegisters([In] ulong mask, [In] uint regCount, [MarshalAs(UnmanagedType.LPArray), Out]
            CORDB_REGISTER[] regBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetRegisters([In] ulong mask, [In] uint regCount, [In] IntPtr regBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.LPArray), In, Out]
            byte[] context);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In]
            byte[] context);
    }
}