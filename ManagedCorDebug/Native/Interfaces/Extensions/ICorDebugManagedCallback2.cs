using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("250E5EEA-DB5C-4C76-B6F3-8C46F12E3203")]
    [ComImport]
    public interface ICorDebugManagedCallback2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FunctionRemapOpportunity(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pOldFunction,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pNewFunction,
            [In] uint oldILOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId, [In] ref ushort pConnName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ChangeConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DestroyConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Exception(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame,
            [In] uint nOffset,
            [In] CorDebugExceptionCallbackType dwEventType,
            [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExceptionUnwind(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] CorDebugExceptionUnwindCallbackType dwEventType,
            [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FunctionRemapComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MDANotification(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugController pController,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugMDA pMDA);
    }
}