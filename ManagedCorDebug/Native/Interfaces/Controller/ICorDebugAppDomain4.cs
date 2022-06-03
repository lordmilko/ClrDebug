using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FB99CC40-83BE-4724-AB3B-768E796EBAC2")]
    [ComImport]
    public interface ICorDebugAppDomain4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObjectForCCW([In] ulong ccwPointer,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppManagedObject);
    }
}