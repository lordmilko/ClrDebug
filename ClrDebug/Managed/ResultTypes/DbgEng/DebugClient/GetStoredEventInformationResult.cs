using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetStoredEventInformation"/> method.
    /// </summary>
    [DebuggerDisplay("Type = {Type.ToString(),nq}, ProcessId = {ProcessId}, ThreadId = {ThreadId}, ContextUsed = {ContextUsed}, ExtraInformationUsed = {ExtraInformationUsed}")]
    public struct GetStoredEventInformationResult
    {
        /// <summary>
        /// Receives the type of the stored event. For a list of possible types, see DEBUG_EVENT_XXX.
        /// </summary>
        public DEBUG_EVENT_TYPE Type { get; }

        /// <summary>
        /// Receives the process ID of the process in which the event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.
        /// </summary>
        public int ProcessId { get; }

        /// <summary>
        /// Receives the thread ID of the thread in which the last event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.
        /// </summary>
        public int ThreadId { get; }

        /// <summary>
        /// Receives the size in bytes of the context. If ContextUsed is NULL, this information is not returned.
        /// </summary>
        public int ContextUsed { get; }

        /// <summary>
        /// Receives the size in bytes of extra information. If ExtraInformationUsed is NULL, this information is not returned.
        /// </summary>
        public int ExtraInformationUsed { get; }

        public GetStoredEventInformationResult(DEBUG_EVENT_TYPE type, int processId, int threadId, int contextUsed, int extraInformationUsed)
        {
            Type = type;
            ProcessId = processId;
            ThreadId = threadId;
            ContextUsed = contextUsed;
            ExtraInformationUsed = extraInformationUsed;
        }
    }
}
