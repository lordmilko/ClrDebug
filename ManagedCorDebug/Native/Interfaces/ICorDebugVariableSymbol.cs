using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("707E8932-1163-48D9-8A93-F5B1F480FBB7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVariableSymbol
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugVariableSymbol szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSize(out uint pcbValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetValue(
            [In] uint offset,
            [In] uint cbContext,
            [In] ref byte context,
            [In] uint cbValue,
            out uint pcbValue,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugVariableSymbol pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetValue(
            [In] uint offset,
            [In] uint threadID,
            [In] uint cbContext,
            [In] ref byte context,
            [In] uint cbValue,
            [In] ref byte pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSlotIndex(out uint pSlotIndex);
    }
}