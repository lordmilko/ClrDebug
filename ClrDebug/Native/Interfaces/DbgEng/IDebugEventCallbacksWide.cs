using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0690e046-9c23-45ac-a04f-987ac29ad0d3")]
    [ComImport]
    public interface IDebugEventCallbacksWide
    {
        [PreserveSig]
        HRESULT GetInterestMask(
            [Out] out DEBUG_EVENT mask);

        [PreserveSig]
        DEBUG_STATUS Breakpoint(
            [In, MarshalAs(UnmanagedType.Interface)]
            IDebugBreakpoint2 bp);

        [PreserveSig]
        DEBUG_STATUS Exception(
            [In] ref EXCEPTION_RECORD64 exception,
            [In] uint firstChance);

        [PreserveSig]
        DEBUG_STATUS CreateThread(
            [In] ulong handle,
            [In] ulong dataOffset,
            [In] ulong startOffset);

        [PreserveSig]
        DEBUG_STATUS ExitThread(
            [In] uint exitCode);

        [PreserveSig]
        DEBUG_STATUS CreateProcess(
            [In] ulong imageFileHandle,
            [In] ulong handle,
            [In] ulong baseOffset,
            [In] uint moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] uint checkSum,
            [In] uint timeDateStamp,
            [In] ulong initialThreadHandle,
            [In] ulong threadDataOffset,
            [In] ulong startOffset);

        [PreserveSig]
        DEBUG_STATUS ExitProcess(
            [In] uint exitCode);

        [PreserveSig]
        DEBUG_STATUS LoadModule(
            [In] ulong imageFileHandle,
            [In] ulong baseOffset,
            [In] uint moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] uint checkSum,
            [In] uint timeDateStamp);

        [PreserveSig]
        DEBUG_STATUS UnloadModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageBaseName,
            [In] ulong baseOffset);

        [PreserveSig]
        DEBUG_STATUS SystemError(
            [In] uint error,
            [In] uint level);

        [PreserveSig]
        HRESULT SessionStatus(
            [In] DEBUG_SESSION status);

        [PreserveSig]
        HRESULT ChangeDebuggeeState(
            [In] DEBUG_CDS flags,
            [In] ulong argument);

        [PreserveSig]
        HRESULT ChangeEngineState(
            [In] DEBUG_CES flags,
            [In] ulong argument);

        [PreserveSig]
        HRESULT ChangeSymbolState(
            [In] DEBUG_CSS flags,
            [In] ulong argument);
    }
}
