using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("FE06DC28-49FB-4636-A4A3-E80DB4AE116C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugDataTarget
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPlatform(out CorDebugPlatform pTargetPlatform);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ReadVirtual([In] ulong address, out byte pBuffer, [In] uint bytesRequested, out uint pBytesRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext([In] uint dwThreadId, [In] uint contextFlags, [In] uint contextSize, out byte pContext);
    }
}