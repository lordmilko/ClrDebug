using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Contains the error that caused the RIP debug event.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct RIP_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"dwError = {dwError}, dwType = {dwType}";

        /// <summary>
        /// The error that caused the RIP debug event.
        /// </summary>
        public int dwError;

        /// <summary>
        /// Any additional information about the type of error that caused the RIP debug event
        /// </summary>
        public SLE dwType;
    }
}
