using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("CC7BCAF6-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEval
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CallFunction([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewObject([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewObjectNoConstructor([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewString([MarshalAs(UnmanagedType.LPWStr), In] string @string);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewArray(
            [In] uint elementType,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass,
            [In] uint rank,
            [In] ref uint dims,
            [In] ref uint lowBounds);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsActive(out int pbActive);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Abort();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetResult([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateValue([In] uint elementType, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}