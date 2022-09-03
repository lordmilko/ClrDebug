using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Breakpoint = {Breakpoint.ToString(),nq}, Exception = {Exception.ToString(),nq}, ExitThread = {ExitThread.ToString(),nq}, ExitProcess = {ExitProcess.ToString(),nq}, LoadModule = {LoadModule.ToString(),nq}, UnloadModule = {UnloadModule.ToString(),nq}, SystemError = {SystemError.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct DEBUG_LAST_EVENT_INFO
    {
        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_BREAKPOINT Breakpoint;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_EXCEPTION Exception;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_EXIT_THREAD ExitThread;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_EXIT_PROCESS ExitProcess;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_LOAD_MODULE LoadModule;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_UNLOAD_MODULE UnloadModule;

        [FieldOffset(0)]
        public DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR SystemError;
    }
}
