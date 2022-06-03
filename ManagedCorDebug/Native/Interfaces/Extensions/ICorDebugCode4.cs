using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("18221FA4-20CB-40FA-B19D-9F91C4FA8C14")]
    [ComImport]
    public interface ICorDebugCode4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateVariableHomes([MarshalAs(UnmanagedType.Interface)] out ICorDebugVariableHomeEnum ppEnum);
    }
}