using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface includes a <see cref="DEBUG_EVENT_CONTEXT"/> as the “context” parameter of each event callback. The context structure contains the “ProcessEngineId”, “ThreadEngineId”, and “FrameEngineId”.<para/>
    /// For example, for an event callbacks like a breakpoint event, it provides information on which process/thread the breakpoint hit on without having to do additional calls back into the engine.<para/>
    /// This interface supports event context callbacks and replaces the use of the <see cref="IDebugClient.SetEventCallbacks"/> method.<para/>
    /// Set this interface on a debugger client by using the <see cref="IDebugClient6.SetEventContextCallbacks"/> method.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61a4905b-23f9-4247-b3c5-53d087529ab7")]
    [ComImport]
    public interface IDebugEventContextCallbacks
    {
        [PreserveSig]
        HRESULT GetInterestMask(
            [Out] out DEBUG_EVENT_TYPE mask);

        [PreserveSig]
        DEBUG_STATUS Breakpoint(
            [In, ComAliasName("IDebugBreakpoint2")] IntPtr bp,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS Exception(
            [In] ref EXCEPTION_RECORD64 exception,
            [In] int firstChance,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS CreateThread(
            [In] long handle,
            [In] long dataOffset,
            [In] long startOffset,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS ExitThread(
            [In] int exitCode,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS CreateProcess(
            [In] long imageFileHandle,
            [In] long handle,
            [In] long baseOffset,
            [In] int moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] int checkSum,
            [In] int timeDateStamp,
            [In] long initialThreadHandle,
            [In] long threadDataOffset,
            [In] long startOffset,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS ExitProcess(
            [In] int exitCode,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS LoadModule(
            [In] long imageFileHandle,
            [In] long baseOffset,
            [In] int moduleSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageName,
            [In] int checkSum,
            [In] int timeDateStamp,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS UnloadModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imageBaseName,
            [In] long baseOffset,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        DEBUG_STATUS SystemError(
            [In] int error,
            [In] int level,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        HRESULT SessionStatus(
            [In] DEBUG_SESSION status);

        [PreserveSig]
        HRESULT ChangeDebuggeeState(
            [In] DEBUG_CDS flags,
            [In] long argument,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        HRESULT ChangeEngineState(
            [In] DEBUG_CES flags,
            [In] long argument,
            [In] ref DEBUG_EVENT_CONTEXT context,
            [In] int contextSize);

        [PreserveSig]
        HRESULT ChangeSymbolState(
            [In] DEBUG_CSS flags,
            [In] long argument);
    }
}
