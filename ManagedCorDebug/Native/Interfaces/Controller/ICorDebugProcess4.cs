using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("E930C679-78AF-4953-8AB7-B0AABF0F9F80")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess4
    {
        [PreserveSig]
        HRESULT Filter(
            [In] byte[] pRecord,
            [In] int countBytes,
            [In] CorDebugRecordFormat format,
            [In] int dwFlags,
            [In] int dwThreadId,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent,
            [In, Out] ref int pContinueStatus);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProcessStateChanged([In] CorDebugStateChange change);
    }
}
