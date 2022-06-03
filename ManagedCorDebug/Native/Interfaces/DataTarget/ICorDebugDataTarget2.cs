using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2EB364DA-605B-4E8D-B333-3394C4828D41")]
    [ComImport]
    public interface ICorDebugDataTarget2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetImageFromPointer([In] ulong addr, out ulong pImageBase, out uint pSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetImageLocation(
            [In] ulong baseAddress,
            [In] uint cchName,
            out uint pcchName,
            [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolProviderForImage(
            [In] ulong imageBaseAddress,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugSymbolProvider ppSymProvider);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateThreadIDs([In] uint cThreadIds, out uint pcThreadIds, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugDataTarget2 pThreadIds);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateVirtualUnwinder(
            [In] uint nativeThreadID,
            [In] uint contextFlags,
            [In] uint cbContext,
            [In] ref byte initialContext,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugVirtualUnwinder ppUnwinder);
    }
}