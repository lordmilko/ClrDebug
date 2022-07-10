using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugSystemObjects4Vtbl
    {
        public readonly IntPtr GetEventThread;
        public readonly IntPtr GetEventProcess;
        public readonly IntPtr GetCurrentThreadId;
        public readonly IntPtr SetCurrentThreadId;
        public readonly IntPtr GetCurrentProcessId;
        public readonly IntPtr SetCurrentProcessId;
        public readonly IntPtr GetNumberThreads;
        public readonly IntPtr GetTotalNumberThreads;
        public readonly IntPtr GetThreadIdsByIndex;
        public readonly IntPtr GetThreadIdByProcessor;
        public readonly IntPtr GetCurrentThreadDataOffset;
        public readonly IntPtr GetThreadIdByDataOffset;
        public readonly IntPtr GetCurrentThreadTeb;
        public readonly IntPtr GetThreadIdByTeb;
        public readonly IntPtr GetCurrentThreadSystemId;
        public readonly IntPtr GetThreadIdBySystemId;
        public readonly IntPtr GetCurrentThreadHandle;
        public readonly IntPtr GetThreadIdByHandle;
        public readonly IntPtr GetNumberProcesses;
        public readonly IntPtr GetProcessIdsByIndex;
        public readonly IntPtr GetCurrentProcessDataOffset;
        public readonly IntPtr GetProcessIdByDataOffset;
        public readonly IntPtr GetCurrentProcessPeb;
        public readonly IntPtr GetProcessIdByPeb;
        public readonly IntPtr GetCurrentProcessSystemId;
        public readonly IntPtr GetProcessIdBySystemId;
        public readonly IntPtr GetCurrentProcessHandle;
        public readonly IntPtr GetProcessIdByHandle;
        public readonly IntPtr GetCurrentProcessExecutableName;
        public readonly IntPtr GetCurrentProcessUpTime;
        public readonly IntPtr GetImplicitThreadDataOffset;
        public readonly IntPtr SetImplicitThreadDataOffset;
        public readonly IntPtr GetImplicitProcessDataOffset;
        public readonly IntPtr SetImplicitProcessDataOffset;
        public readonly IntPtr GetEventSystem;
        public readonly IntPtr GetCurrentSystemId;
        public readonly IntPtr SetCurrentSystemId;
        public readonly IntPtr GetNumberSystems;
        public readonly IntPtr GetSystemIdsByIndex;
        public readonly IntPtr GetTotalNumberThreadsAndProcesses;
        public readonly IntPtr GetCurrentSystemServer;
        public readonly IntPtr GetSystemByServer;
        public readonly IntPtr GetCurrentSystemServerName;
        public readonly IntPtr GetCurrentProcessExecutableNameWide;
        public readonly IntPtr GetCurrentSystemServerNameWide;
    }
}
