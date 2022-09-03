using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Error = {Error}, Level = {Level}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR
    {
        public int Error;
        public int Level;
    }
}
