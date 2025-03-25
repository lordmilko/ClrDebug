using System.Diagnostics;

namespace ClrDebug.TTD
{
    [DebuggerDisplay("UniqueThreadId = {info->UniqueThreadId.ToString(),nq}, ThreadId = {info->ThreadId.ToString(),nq}, next = {next.ToString(),nq}, last = {last.ToString(),nq}")]
    public unsafe struct ActiveThreadInfo
    {
        public ThreadInfo* info;
        public Position next;
        public Position last;
    }
}
