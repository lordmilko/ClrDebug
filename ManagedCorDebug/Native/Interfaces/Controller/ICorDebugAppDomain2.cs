using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("096E81D5-ECDA-4202-83F5-C65980A9EF75")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAppDomain2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetArrayOrPointerType(
            [In] uint elementType,
            [In] uint nRank,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pTypeArg,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionPointerType(
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}