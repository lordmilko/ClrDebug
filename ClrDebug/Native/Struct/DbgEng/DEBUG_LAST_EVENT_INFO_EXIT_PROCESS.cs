using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("ExitCode = {ExitCode}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXIT_PROCESS
    {
        public int ExitCode;
    }
}
