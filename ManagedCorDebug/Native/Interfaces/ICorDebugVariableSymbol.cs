using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("707E8932-1163-48D9-8A93-F5B1F480FBB7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVariableSymbol
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(out uint pcbValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetValue(
            [In] uint offset,
            [In] uint cbContext,
            [In] ref byte context,
            [In] uint cbValue,
            out uint pcbValue,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugVariableSymbol pValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetValue(
            [In] uint offset,
            [In] uint threadID,
            [In] uint cbContext,
            [In] ref byte context,
            [In] uint cbValue,
            [In] ref byte pValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSlotIndex(out uint pSlotIndex);
    }
}