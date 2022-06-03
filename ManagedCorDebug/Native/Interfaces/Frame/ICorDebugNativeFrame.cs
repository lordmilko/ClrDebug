using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("03E26314-4F76-11D3-88C6-006097945418")]
    [ComImport]
    public interface ICorDebugNativeFrame : ICorDebugFrame
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
        void GetIP(out uint pnOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIP([In] uint nOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRegisterSet([MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalRegisterValue(
            [In] CorDebugRegister reg,
            [In] uint cbSigBlob,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalDoubleRegisterValue(
            [In] CorDebugRegister highWordReg,
            [In] CorDebugRegister lowWordReg,
            [In] uint cbSigBlob,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalMemoryValue(
            [In] ulong address,
            [In] uint cbSigBlob,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalRegisterMemoryValue(
            [In] CorDebugRegister highWordReg,
            [In] ulong lowWordAddress,
            [In] uint cbSigBlob,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalMemoryRegisterValue(
            [In] ulong highWordAddress,
            [In] CorDebugRegister lowWordRegister,
            [In] uint cbSigBlob,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CanSetIP([In] uint nOffset);
    }
}