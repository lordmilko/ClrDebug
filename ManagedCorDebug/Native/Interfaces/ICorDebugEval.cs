using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("CC7BCAF6-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEval
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CallFunction([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewObject([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewObjectNoConstructor([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewString([MarshalAs(UnmanagedType.LPWStr), In] string @string);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewArray(
            [In] uint elementType,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass,
            [In] uint rank,
            [In] ref uint dims,
            [In] ref uint lowBounds);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsActive(out int pbActive);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Abort();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetResult([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateValue([In] uint elementType, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}