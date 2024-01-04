using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the exit process of the last event.
    /// </summary>
    [DebuggerDisplay("ExitCode = {ExitCode}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXIT_PROCESS
    {
        /// <summary>
        /// The exit code of the process.
        /// </summary>
        public int ExitCode;
    }
}
