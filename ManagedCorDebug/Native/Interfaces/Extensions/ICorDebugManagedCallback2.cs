using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("250E5EEA-DB5C-4C76-B6F3-8C46F12E3203")]
    [ComImport]
    public interface ICorDebugManagedCallback2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FunctionRemapOpportunity(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pOldFunction,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pNewFunction,
            [In] uint oldILOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId, [MarshalAs(UnmanagedType.LPWStr), In] string pConnName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ChangeConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DestroyConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Exception(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame,
            [In] uint nOffset,
            [In] CorDebugExceptionCallbackType dwEventType,
            [In] uint dwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwind(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] CorDebugExceptionUnwindCallbackType dwEventType,
            [In] uint dwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FunctionRemapComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT MDANotification(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugController pController,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugMDA pMDA);
    }
}