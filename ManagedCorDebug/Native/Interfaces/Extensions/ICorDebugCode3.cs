using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D13D3E88-E1F2-4020-AA1D-3D162DCBE966")]
    [ComImport]
    public interface ICorDebugCode3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReturnValueLiveOffset(
            [In] uint ilOffset,
            [In] uint bufferSize,
            out uint pFetched,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugCode3 pOffsets);
    }
}