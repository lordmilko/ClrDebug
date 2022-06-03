using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAEB-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugValueBreakpoint : ICorDebugBreakpoint
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Activate([In] int bActive);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void IsActive(out int pbActive);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetValue([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}