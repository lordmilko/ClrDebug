using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3E11CCEE-D08B-43E5-AF01-32717A64DA03")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRDataTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMachineType(out uint machineType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPointerSize(out uint pointerSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void WriteVirtual([In] ulong address, [In] ref byte buffer, [In] uint bytesRequested, out uint bytesWritten);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTLSValue([In] uint threadID, [In] uint index, out ulong value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCurrentThreadID(out uint threadID);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThreadContext([In] uint threadID, [In] uint contextFlags, [In] uint contextSize, out byte context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext([In] uint threadID, [In] uint contextSize, [In] ref byte context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] ref byte inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);
    }
}