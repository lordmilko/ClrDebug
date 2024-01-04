using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugPlmClient.LaunchPlmBgTaskForDebugWide"/> method.
    /// </summary>
    [DebuggerDisplay("ProcessId = {ProcessId}, ThreadId = {ThreadId}")]
    public struct LaunchPlmBgTaskForDebugWideResult
    {
        /// <summary>
        /// A pointer to a process ID output.
        /// </summary>
        public int ProcessId { get; }

        /// <summary>
        /// A pointer to a thread ID output.
        /// </summary>
        public int ThreadId { get; }

        public LaunchPlmBgTaskForDebugWideResult(int processId, int threadId)
        {
            ProcessId = processId;
            ThreadId = threadId;
        }
    }
}
