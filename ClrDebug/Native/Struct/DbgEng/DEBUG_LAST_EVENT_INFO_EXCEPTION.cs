using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("ExceptionRecord = {ExceptionRecord.ToString(),nq}, FirstChance = {FirstChance}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXCEPTION
    {
        public EXCEPTION_RECORD64 ExceptionRecord;
        public int FirstChance;
    }
}
