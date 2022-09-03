using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines context information about an event.
    /// </summary>
    [DebuggerDisplay("Size = {Size}, ProcessEngineId = {ProcessEngineId}, ThreadEngineId = {ThreadEngineId}, FrameEngineId = {FrameEngineId}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EVENT_CONTEXT
    {
        /// <summary>
        /// The size of the event.
        /// </summary>
        public int Size;

        /// <summary>
        /// The process engine ID of the event.
        /// </summary>
        public int ProcessEngineId;

        /// <summary>
        /// The process thread ID of the event.
        /// </summary>
        public int ThreadEngineId;

        /// <summary>
        /// The frame engine ID of the event.
        /// </summary>
        public int FrameEngineId;
    }
}
