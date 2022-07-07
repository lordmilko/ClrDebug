using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("27fe5639-8407-4f47-8364-ee118fb08ac8")]
    [ComImport]
    public interface IDebugClient
    {
        [PreserveSig]
        HRESULT AttachKernel(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);

        [PreserveSig]
        HRESULT GetKernelConnectionOptions(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        [PreserveSig]
        HRESULT SetKernelConnectionOptions(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        [PreserveSig]
        HRESULT StartProcessServer(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved);

        [PreserveSig]
        HRESULT ConnectProcessServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out ulong Server);

        [PreserveSig]
        HRESULT DisconnectProcessServer(
            [In] ulong Server);

        [PreserveSig]
        HRESULT GetRunningProcessSystemIds(
            [In] ulong Server,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] Ids,
            [In] uint Count,
            [Out] out uint ActualCount);

        [PreserveSig]
        HRESULT GetRunningProcessSystemIdByExecutableName(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetRunningProcessDescription(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ExeName,
            [In] int ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        [PreserveSig]
        HRESULT AttachProcess(
            [In] ulong Server,
            [In] uint ProcessID,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        HRESULT CreateProcess(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags);

        [PreserveSig]
        HRESULT CreateProcessAndAttach(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        HRESULT GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);

        [PreserveSig]
        HRESULT AddProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        HRESULT RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        HRESULT SetProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        HRESULT OpenDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        [PreserveSig]
        HRESULT WriteDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);

        [PreserveSig]
        HRESULT ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] uint HistoryLimit);

        [PreserveSig]
        HRESULT StartServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        [PreserveSig]
        HRESULT OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        [PreserveSig]
        HRESULT TerminateProcesses();

        [PreserveSig]
        HRESULT DetachProcesses();

        [PreserveSig]
        HRESULT EndSession(
            [In] DEBUG_END Flags);

        [PreserveSig]
        HRESULT GetExitCode(
            [Out] out uint Code);

        [PreserveSig]
        HRESULT DispatchCallbacks(
            [In] uint Timeout);

        [PreserveSig]
        HRESULT ExitDispatch(
            [In] IntPtr Client);

        [PreserveSig]
        HRESULT CreateClient(
            [Out] IntPtr Client);

        [PreserveSig]
        HRESULT GetInputCallbacks(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugInputCallbacks Callbacks);

        [PreserveSig]
        HRESULT SetInputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks);

        //Due to conversions to and from wide types, we can't assume the IDebugOutputCallbacks we get back is the one we put in
        [PreserveSig]
        HRESULT GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);

        //Due to conversions to and from wide types, we can't assume the IDebugOutputCallbacks we put in is the one we'll get back
        [PreserveSig]
        HRESULT SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);

        [PreserveSig]
        HRESULT GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        HRESULT SetOutputMask(
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        HRESULT GetOtherOutputMask(
            [In] IntPtr Client,
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        HRESULT SetOtherOutputMask(
            [In] IntPtr Client,
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        HRESULT GetOutputWidth(
            [Out] out uint Columns);

        [PreserveSig]
        HRESULT SetOutputWidth(
            [In] uint Columns);

        [PreserveSig]
        HRESULT GetOutputLinePrefix(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        [PreserveSig]
        HRESULT SetOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string Prefix);

        [PreserveSig]
        HRESULT GetIdentity(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint IdentitySize);

        [PreserveSig]
        HRESULT OutputIdentity(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        HRESULT GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);

        [PreserveSig]
        HRESULT SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);

        [PreserveSig]
        HRESULT FlushCallbacks();
    }
}
