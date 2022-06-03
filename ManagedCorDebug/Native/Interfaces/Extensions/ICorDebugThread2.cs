using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("2BD956D9-7B07-4BEF-8A98-12AA862417C5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveFunctions([In] uint cFunctions, out uint pcFunctions,
            [MarshalAs(UnmanagedType.Interface), In, Out]
            ICorDebugThread2 pFunctions);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetConnectionID(out uint pdwConnectionId);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTaskID(out ulong pTaskId);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVolatileOSThreadID(out uint pdwTid);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT InterceptCurrentException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame);
    }
}