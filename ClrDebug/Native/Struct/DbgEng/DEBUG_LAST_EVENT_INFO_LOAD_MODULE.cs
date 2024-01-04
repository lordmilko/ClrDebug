using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the load module of the last event.
    /// </summary>
    [DebuggerDisplay("Base = {Base}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_LOAD_MODULE
    {
        /// <summary>
        /// The base of the load module.
        /// </summary>
        public ulong Base;
    }
}
