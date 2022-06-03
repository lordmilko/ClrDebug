using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FB0D9CE7-BE66-4683-9D32-A42A04E2FD91")]
    [ComImport]
    public interface ICorDebugEval2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CallParameterizedFunction(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] uint nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateValueForType([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pType, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewParameterizedObject(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] uint nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewParameterizedObjectNoConstructor(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewParameterizedArray(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pElementType,
            [In] uint rank,
            [In] ref uint dims,
            [In] ref uint lowBounds);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewStringWithLength([MarshalAs(UnmanagedType.LPWStr), In] string @string, [In] uint uiLength);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RudeAbort();
    }
}