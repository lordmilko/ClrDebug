using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("09B70F28-E465-482D-99E0-81A165EB0532")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugFunction3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetActiveReJitRequestILCode([MarshalAs(UnmanagedType.Interface)] ref ICorDebugILCode ppReJitedILCode);
    }
}