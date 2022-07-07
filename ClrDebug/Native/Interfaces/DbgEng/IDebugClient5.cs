using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("e3acb9d7-7ec2-4f0c-a0da-e81e0cbbe628")]
    [ComImport]
    public interface IDebugClient5 : IDebugClient4
    {
        #region IDebugClient

        [PreserveSig]
        new HRESULT AttachKernel(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);

        [PreserveSig]
        new HRESULT GetKernelConnectionOptions(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        [PreserveSig]
        new HRESULT SetKernelConnectionOptions(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        [PreserveSig]
        new HRESULT StartProcessServer(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved);

        [PreserveSig]
        new HRESULT ConnectProcessServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out ulong Server);

        [PreserveSig]
        new HRESULT DisconnectProcessServer(
            [In] ulong Server);

        [PreserveSig]
        new HRESULT GetRunningProcessSystemIds(
            [In] ulong Server,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] Ids,
            [In] uint Count,
            [Out] out uint ActualCount);

        [PreserveSig]
        new HRESULT GetRunningProcessSystemIdByExecutableName(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetRunningProcessDescription(
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
        new HRESULT AttachProcess(
            [In] ulong Server,
            [In] uint ProcessID,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        new HRESULT CreateProcess(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags);

        [PreserveSig]
        new HRESULT CreateProcessAndAttach(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        new HRESULT GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);

        [PreserveSig]
        new HRESULT AddProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        new HRESULT RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        new HRESULT SetProcessOptions(
            [In] DEBUG_PROCESS Options);

        [PreserveSig]
        new HRESULT OpenDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        [PreserveSig]
        new HRESULT WriteDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);

        [PreserveSig]
        new HRESULT ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] uint HistoryLimit);

        [PreserveSig]
        new HRESULT StartServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        [PreserveSig]
        new HRESULT OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        [PreserveSig]
        new HRESULT TerminateProcesses();

        [PreserveSig]
        new HRESULT DetachProcesses();

        [PreserveSig]
        new HRESULT EndSession(
            [In] DEBUG_END Flags);

        [PreserveSig]
        new HRESULT GetExitCode(
            [Out] out uint Code);

        [PreserveSig]
        new HRESULT DispatchCallbacks(
            [In] uint Timeout);

        [PreserveSig]
        new HRESULT ExitDispatch(
            [In] IntPtr Client);

        [PreserveSig]
        new HRESULT CreateClient(
            [Out] IntPtr Client);

        [PreserveSig]
        new HRESULT GetInputCallbacks(
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugInputCallbacks Callbacks);

        [PreserveSig]
        new HRESULT SetInputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)]
            IDebugInputCallbacks Callbacks);

        [PreserveSig]
        new HRESULT GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);

        [PreserveSig]
        new HRESULT SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);

        [PreserveSig]
        new HRESULT GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT SetOutputMask(
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT GetOtherOutputMask(
            [In] IntPtr Client,
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT SetOtherOutputMask(
            [In] IntPtr Client,
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT GetOutputWidth(
            [Out] out uint Columns);

        [PreserveSig]
        new HRESULT SetOutputWidth(
            [In] uint Columns);

        [PreserveSig]
        new HRESULT GetOutputLinePrefix(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        [PreserveSig]
        new HRESULT SetOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string Prefix);

        [PreserveSig]
        new HRESULT GetIdentity(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint IdentitySize);

        [PreserveSig]
        new HRESULT OutputIdentity(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        new HRESULT GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);

        [PreserveSig]
        new HRESULT SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);

        [PreserveSig]
        new HRESULT FlushCallbacks();

        #endregion
        #region IDebugClient2

        [PreserveSig]
        new HRESULT WriteDumpFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Comment);

        [PreserveSig]
        new HRESULT AddDumpInformationFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string InfoFile,
            [In] DEBUG_DUMP_FILE Type);

        [PreserveSig]
        new HRESULT EndProcessServer(
            [In] ulong Server);

        [PreserveSig]
        new HRESULT WaitForProcessServerEnd(
            [In] uint Timeout);

        [PreserveSig]
        new HRESULT IsKernelDebuggerEnabled();

        [PreserveSig]
        new HRESULT TerminateCurrentProcess();

        [PreserveSig]
        new HRESULT DetachCurrentProcess();

        [PreserveSig]
        new HRESULT AbandonCurrentProcess();

        #endregion
        #region IDebugClient3

        [PreserveSig]
        new HRESULT GetRunningProcessSystemIdByExecutableNameWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetRunningProcessDescriptionWide(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder ExeName,
            [In] int ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        [PreserveSig]
        new HRESULT CreateProcessWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags);

        [PreserveSig]
        new HRESULT CreateProcessAndAttachWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        #endregion
        #region IDebugClient4

        [PreserveSig]
        new HRESULT OpenDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle);

        [PreserveSig]
        new HRESULT WriteDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string DumpFile,
            [In] ulong FileHandle,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Comment);

        [PreserveSig]
        new HRESULT AddDumpInformationFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle,
            [In] DEBUG_DUMP_FILE Type);

        [PreserveSig]
        new HRESULT GetNumberDumpFiles(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetDumpFile(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out uint Type);

        [PreserveSig]
        new HRESULT GetDumpFileWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out uint Type);

        #endregion
        #region IDebugClient5

        [PreserveSig]
        HRESULT AttachKernelWide(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ConnectOptions);

        [PreserveSig]
        HRESULT GetKernelConnectionOptionsWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        [PreserveSig]
        HRESULT SetKernelConnectionOptionsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);

        [PreserveSig]
        HRESULT StartProcessServerWide(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options,
            [In] IntPtr Reserved);

        [PreserveSig]
        HRESULT ConnectProcessServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions,
            [Out] out ulong Server);

        [PreserveSig]
        HRESULT StartServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);

        [PreserveSig]
        HRESULT OutputServersWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        [PreserveSig]
        HRESULT GetOutputCallbacksWide(
            [Out] out IDebugOutputCallbacksWide Callbacks);

        [PreserveSig]
        HRESULT SetOutputCallbacksWide(
            [In] IDebugOutputCallbacksWide Callbacks);

        [PreserveSig]
        HRESULT GetOutputLinePrefixWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        [PreserveSig]
        HRESULT SetOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Prefix);

        [PreserveSig]
        HRESULT GetIdentityWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint IdentitySize);

        [PreserveSig]
        HRESULT OutputIdentityWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Machine);

        [PreserveSig]
        HRESULT GetEventCallbacksWide(
            [Out] out IDebugEventCallbacksWide Callbacks);

        [PreserveSig]
        HRESULT SetEventCallbacksWide(
            [In] IDebugEventCallbacksWide Callbacks);

        [PreserveSig]
        HRESULT CreateProcess2(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment);

        [PreserveSig]
        HRESULT CreateProcess2Wide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment);

        [PreserveSig]
        HRESULT CreateProcessAndAttach2(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        HRESULT CreateProcessAndAttach2Wide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        [PreserveSig]
        HRESULT PushOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string NewPrefix,
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT PushOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix,
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT PopOutputLinePrefix(
            [In] ulong Handle);

        [PreserveSig]
        HRESULT GetNumberInputCallbacks(
            [Out] out uint Count);

        [PreserveSig]
        HRESULT GetNumberOutputCallbacks(
            [Out] out uint Count);

        [PreserveSig]
        HRESULT GetNumberEventCallbacks(
            [In] DEBUG_EVENT Flags,
            [Out] out uint Count);

        [PreserveSig]
        HRESULT GetQuitLockString(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        HRESULT SetQuitLockString(
            [In, MarshalAs(UnmanagedType.LPStr)] string LockString);

        [PreserveSig]
        HRESULT GetQuitLockStringWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        HRESULT SetQuitLockStringWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string LockString);

        #endregion
    }
}
