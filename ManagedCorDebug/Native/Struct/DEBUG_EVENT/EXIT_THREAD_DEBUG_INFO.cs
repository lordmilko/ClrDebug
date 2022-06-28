using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct EXIT_THREAD_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"dwExitCode = {dwExitCode}";

        public int dwExitCode;
    }
}
