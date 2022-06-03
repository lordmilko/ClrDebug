using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B92CC7F7-9D2D-45C4-BC2B-621FCC9DFBF4")]
    [ComImport]
    public interface ICorDebugInternalFrame : ICorDebugFrame
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetFunctionToken(out uint pToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetStackRange(out ulong pStart, out ulong pEnd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFrameType(out CorDebugInternalFrameType pType);
    }
}