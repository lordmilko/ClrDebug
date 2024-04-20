using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("MethodStart = {MethodStart}, ExceptionInfo = {ExceptionInfo}")]
    public struct READYTORUN_EXCEPTION_LOOKUP_TABLE_ENTRY
    {
        public int MethodStart;
        public int ExceptionInfo;
    }
}
