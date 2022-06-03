using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0647DE9-55DE-4816-929C-385271C64CF7")]
    [ComImport]
    public interface ICorDebugStackWalk
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext(
            [In] uint contextFlags,
            [In] uint contextBufSize,
            out uint contextSize,
            out byte contextBuf);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetContext([In] CorDebugSetContextFlag flag, [In] uint contextSize, [In] ref byte context);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame pFrame);
    }
}