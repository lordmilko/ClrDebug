using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("6DC7BA3F-89BA-4459-9EC1-9D60937B468D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugRegisterSet2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRegistersAvailable([In] uint numChunks, out byte availableRegChunks);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRegisters([In] uint maskCount, [In] ref byte mask, [In] uint regCount, out ulong regBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetRegisters([In] uint maskCount, [In] ref byte mask, [In] uint regCount, [In] ref ulong regBuffer);
    }
}