using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A1B8A756-3CB6-4CCB-979F-3DF999673A59")]
    [ComImport]
    public interface ICorDebugMutableDataTarget : ICorDebugDataTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetPlatform(out CorDebugPlatform pTargetPlatform);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void ReadVirtual(
            [In] ulong address,
            out byte pBuffer,
            [In] uint bytesRequested,
            out uint pBytesRead);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetThreadContext(
            [In] uint dwThreadId,
            [In] uint contextFlags,
            [In] uint contextSize,
            out byte pContext);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void WriteVirtual([In] ulong address, [In] ref byte pBuffer, [In] uint bytesRequested);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext([In] uint dwThreadId, [In] uint contextSize, [In] ref byte pContext);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ContinueStatusChanged([In] uint dwThreadId, [In] uint continueStatus);
    }
}