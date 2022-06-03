using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("2BD956D9-7B07-4BEF-8A98-12AA862417C5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetActiveFunctions([In] uint cFunctions, out uint pcFunctions,
            [MarshalAs(UnmanagedType.Interface), In, Out]
            ICorDebugThread2 pFunctions);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetConnectionID(out uint pdwConnectionId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTaskID(out ulong pTaskId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetVolatileOSThreadID(out uint pdwTid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void InterceptCurrentException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame);
    }
}