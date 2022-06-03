using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("E76B7A57-4F7A-4309-85A7-5D918C3DEAF7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVariableHomeEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Skip([In] uint celt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Reset();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Clone([MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetCount(out uint pcelt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugVariableHomeEnum homes, out uint pceltFetched);
    }
}