using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the unload module of the last event.
    /// </summary>
    [DebuggerDisplay("Base = {Base}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_UNLOAD_MODULE
    {
        /// <summary>
        /// The base of the unload module.
        /// </summary>
        public ulong Base;
    }
}
