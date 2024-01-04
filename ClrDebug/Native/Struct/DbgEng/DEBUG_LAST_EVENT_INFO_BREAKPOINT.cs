using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the breakpoint of the last event.
    /// </summary>
    [DebuggerDisplay("Id = {Id}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_BREAKPOINT
    {
        /// <summary>
        /// The ID of the breakpoint.
        /// </summary>
        public int Id;
    }
}
