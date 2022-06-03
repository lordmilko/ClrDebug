using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A5664F95-0AF4-4A1B-960E-2F3346B4214C")]
    [ComImport]
    public interface ICLRDataTarget3 : ICLRDataTarget2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetMachineType(out uint machineType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetPointerSize(out uint pointerSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void WriteVirtual(
            [In] ulong address,
            [In] ref byte buffer,
            [In] uint bytesRequested,
            out uint bytesWritten);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetTLSValue([In] uint threadID, [In] uint index, out ulong value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetCurrentThreadID(out uint threadID);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetThreadContext(
            [In] uint threadID,
            [In] uint contextFlags,
            [In] uint contextSize,
            out byte context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetThreadContext([In] uint threadID, [In] uint contextSize, [In] ref byte context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] ref byte inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void AllocVirtual(
            [In] ulong addr,
            [In] uint size,
            [In] uint typeFlags,
            [In] uint protectFlags,
            out ulong virt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void FreeVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetExceptionRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetExceptionContextRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetExceptionThreadID(out uint threadID);
    }
}