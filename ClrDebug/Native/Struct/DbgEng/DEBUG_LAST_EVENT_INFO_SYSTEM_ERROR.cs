using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the system error of the last event.
    /// </summary>
    [DebuggerDisplay("Error = {Error}, Level = {Level}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR
    {
        /// <summary>
        /// The error code for the event.
        /// </summary>
        public int Error;

        /// <summary>
        /// The error level for the event.
        /// </summary>
        public int Level;
    }
}
