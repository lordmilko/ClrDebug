using System;
using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("hProcess = {hProcess.ToString(),nq}, hThread = {hThread.ToString(),nq}, dwProcessId = {dwProcessId}, dwThreadId = {dwThreadId}")]
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }
}
