using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCB0B-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugRegisterSet
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRegistersAvailable(out ulong pAvailable);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRegisters([In] ulong mask, [In] uint regCount, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugRegisterSet regBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetRegisters([In] ulong mask, [In] uint regCount, [In] ref ulong regBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In, Out]
            ICorDebugRegisterSet context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRegisterSet context);
    }
}