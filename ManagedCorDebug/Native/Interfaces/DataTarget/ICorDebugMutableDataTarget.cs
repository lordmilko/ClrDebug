using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A1B8A756-3CB6-4CCB-979F-3DF999673A59")]
    [ComImport]
    public interface ICorDebugMutableDataTarget : ICorDebugDataTarget
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetPlatform(out CorDebugPlatform pTargetPlatform);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT ReadVirtual(
            [In] ulong address,
            out byte pBuffer,
            [In] uint bytesRequested,
            out uint pBytesRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThreadContext(
            [In] uint dwThreadId,
            [In] uint contextFlags,
            [In] uint contextSize,
            out byte pContext);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT WriteVirtual([In] ulong address, [In] ref byte pBuffer, [In] uint bytesRequested);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetThreadContext([In] uint dwThreadId, [In] uint contextSize, [In] ref byte pContext);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ContinueStatusChanged([In] uint dwThreadId, [In] uint continueStatus);
    }
}