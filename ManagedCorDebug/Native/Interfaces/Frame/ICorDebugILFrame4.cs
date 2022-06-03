using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AD914A30-C6D1-4AC5-9C5E-577F3BAA8A45")]
    [ComImport]
    public interface ICorDebugILFrame4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLocalVariablesEx([In] ILCodeKind flags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariableEx([In] ILCodeKind flags, [In] uint dwIndex,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeEx([In] ILCodeKind flags, [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);
    }
}