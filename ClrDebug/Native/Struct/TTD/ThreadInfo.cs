using System.Diagnostics;

namespace ClrDebug.TTD
{
    [DebuggerDisplay("UniqueThreadId = {UniqueThreadId.ToString(),nq}, ThreadId = {ThreadId.ToString(),nq}")]
    public struct ThreadInfo
    {
        //Based on the names returned from dx @$cursession.TTD.Calls()[0]

        public UniqueThreadId UniqueThreadId;
        public ThreadId ThreadId;

        public override string ToString()
        {
            return ThreadId.ToString();
        }
    }
}
