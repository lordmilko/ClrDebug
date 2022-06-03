using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0647DE9-55DE-4816-929C-385271C64CF7")]
    [ComImport]
    public interface ICorDebugStackWalk
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetContext(
            [In] uint contextFlags,
            [In] uint contextBufSize,
            out uint contextSize,
            out byte contextBuf);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetContext([In] CorDebugSetContextFlag flag, [In] uint contextSize, [In] ref byte context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Next();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame pFrame);
    }
}