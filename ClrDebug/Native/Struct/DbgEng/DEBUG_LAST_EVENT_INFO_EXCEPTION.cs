using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the exception of the last event.
    /// </summary>
    [DebuggerDisplay("ExceptionRecord = {ExceptionRecord.ToString(),nq}, FirstChance = {FirstChance}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXCEPTION
    {
        /// <summary>
        /// An exception record.
        /// </summary>
        public EXCEPTION_RECORD64 ExceptionRecord;

        /// <summary>
        /// A first chance value.
        /// </summary>
        public int FirstChance;
    }
}
