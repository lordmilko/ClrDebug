using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("11588775-7205-4CEB-A41A-93753C3153E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess6
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DecodeEvent(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess6 pRecord,
            [In] uint countBytes,
            [In] CorDebugRecordFormat format,
            [In] uint dwFlags,
            [In] uint dwThreadId,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ProcessStateChanged([In] CorDebugStateChange change);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCode([In] ulong codeAddress, [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnableVirtualModuleSplitting(int enableSplitting);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MarkDebuggerAttached(int fIsAttached);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetExportStepInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pszExportName,
            out CorDebugCodeInvokeKind pInvokeKind,
            out CorDebugCodeInvokePurpose pInvokePurpose);
    }
}