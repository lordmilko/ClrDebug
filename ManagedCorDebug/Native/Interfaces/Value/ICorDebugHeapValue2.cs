using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E3AC4D6C-9CB7-43E6-96CC-B21540E5083C")]
    [ComImport]
    public interface ICorDebugHeapValue2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateHandle([In] CorDebugHandleType type,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);
    }
}