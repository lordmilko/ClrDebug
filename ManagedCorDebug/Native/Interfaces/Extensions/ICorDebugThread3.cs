using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("F8544EC3-5E4E-46C7-8D3E-A52B8405B1F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateStackWalk([MarshalAs(UnmanagedType.Interface)] out ICorDebugStackWalk ppStackWalk);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetActiveInternalFrames(
            [In] uint cInternalFrames,
            out uint pcInternalFrames,
            [MarshalAs(UnmanagedType.Interface), In, Out]
            ICorDebugThread3 ppInternalFrames);
    }
}