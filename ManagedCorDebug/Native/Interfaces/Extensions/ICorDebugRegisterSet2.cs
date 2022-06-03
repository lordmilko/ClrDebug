using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("6DC7BA3F-89BA-4459-9EC1-9D60937B468D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugRegisterSet2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegistersAvailable([In] uint numChunks, out byte availableRegChunks);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegisters([In] uint maskCount, [In] ref byte mask, [In] uint regCount, out ulong regBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetRegisters([In] uint maskCount, [In] ref byte mask, [In] uint regCount, [In] ref ulong regBuffer);
    }
}