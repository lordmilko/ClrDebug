using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("879CAC0A-4A53-4668-B8E3-CB8473CB187F")]
    [ComImport]
    public interface ICorDebugRuntimeUnwindableFrame : ICorDebugFrame
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFunctionToken(out uint pToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetStackRange(out ulong pStart, out ulong pEnd);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);
    }
}