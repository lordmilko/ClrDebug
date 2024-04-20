using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugClient4Vtbl
    {
        public readonly IntPtr AttachKernel;
        public readonly IntPtr GetKernelConnectionOptions;
        public readonly IntPtr SetKernelConnectionOptions;
        public readonly IntPtr StartProcessServer;
        public readonly IntPtr ConnectProcessServer;
        public readonly IntPtr DisconnectProcessServer;
        public readonly IntPtr GetRunningProcessSystemIds;
        public readonly IntPtr GetRunningProcessSystemIdByExecutableName;
        public readonly IntPtr GetRunningProcessDescription;
        public readonly IntPtr AttachProcess;
        public readonly IntPtr CreateProcess;
        public readonly IntPtr CreateProcessAndAttach;
        public readonly IntPtr GetProcessOptions;
        public readonly IntPtr AddProcessOptions;
        public readonly IntPtr RemoveProcessOptions;
        public readonly IntPtr SetProcessOptions;
        public readonly IntPtr OpenDumpFile;
        public readonly IntPtr WriteDumpFile;
        public readonly IntPtr ConnectSession;
        public readonly IntPtr StartServer;
        public readonly IntPtr OutputServers;
        public readonly IntPtr TerminateProcesses;
        public readonly IntPtr DetachProcesses;
        public readonly IntPtr EndSession;
        public readonly IntPtr GetExitCode;
        public readonly IntPtr DispatchCallbacks;
        public readonly IntPtr ExitDispatch;
        public readonly IntPtr CreateClient;
        public readonly IntPtr GetInputCallbacks;
        public readonly IntPtr SetInputCallbacks;
        public readonly IntPtr GetOutputCallbacks;
        public readonly IntPtr SetOutputCallbacks;
        public readonly IntPtr GetOutputMask;
        public readonly IntPtr SetOutputMask;
        public readonly IntPtr GetOtherOutputMask;
        public readonly IntPtr SetOtherOutputMask;
        public readonly IntPtr GetOutputWidth;
        public readonly IntPtr SetOutputWidth;
        public readonly IntPtr GetOutputLinePrefix;
        public readonly IntPtr SetOutputLinePrefix;
        public readonly IntPtr GetIdentity;
        public readonly IntPtr OutputIdentity;
        public readonly IntPtr GetEventCallbacks;
        public readonly IntPtr SetEventCallbacks;
        public readonly IntPtr FlushCallbacks;
        public readonly IntPtr WriteDumpFile2;
        public readonly IntPtr AddDumpInformationFile;
        public readonly IntPtr EndProcessServer;
        public readonly IntPtr WaitForProcessServerEnd;
        public readonly IntPtr IsKernelDebuggerEnabled;
        public readonly IntPtr TerminateCurrentProcess;
        public readonly IntPtr DetachCurrentProcess;
        public readonly IntPtr AbandonCurrentProcess;
        public readonly IntPtr GetRunningProcessSystemIdByExecutableNameWide;
        public readonly IntPtr GetRunningProcessDescriptionWide;
        public readonly IntPtr CreateProcessWide;
        public readonly IntPtr CreateProcessAndAttachWide;
        public readonly IntPtr OpenDumpFileWide;
        public readonly IntPtr WriteDumpFileWide;
        public readonly IntPtr AddDumpInformationFileWide;
        public readonly IntPtr GetNumberDumpFiles;
        public readonly IntPtr GetDumpFile;
        public readonly IntPtr GetDumpFileWide;
    }
}
