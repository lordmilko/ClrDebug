using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the exit thread of the last event.
    /// </summary>
    [DebuggerDisplay("ExitCode = {ExitCode}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXIT_THREAD
    {
        /// <summary>
        /// The exit code of the thread.
        /// </summary>
        public int ExitCode;
    }
}
