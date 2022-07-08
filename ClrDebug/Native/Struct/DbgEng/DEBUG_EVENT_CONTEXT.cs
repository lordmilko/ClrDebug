using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines context information about an event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EVENT_CONTEXT
    {
        /// <summary>
        /// The size of the event.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The process engine ID of the event.
        /// </summary>
        public uint ProcessEngineId;

        /// <summary>
        /// The process thread ID of the event.
        /// </summary>
        public uint ThreadEngineId;

        /// <summary>
        /// The frame engine ID of the event.
        /// </summary>
        public uint FrameEngineId;
    }
}