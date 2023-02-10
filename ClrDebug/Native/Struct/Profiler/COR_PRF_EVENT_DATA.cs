using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Describes the event data for an EventPipe event being written.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EVENT_DATA structure is used by the <see cref="ICorProfilerInfo12.EventPipeWriteEvent"/> method to
    /// provide the data payload for the event being written.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_EVENT_DATA
    {
        /// <summary>
        /// A pointer to the data.
        /// </summary>
        public long ptr; //UINT64 so must be 8 bytes

        /// <summary>
        /// The size of the data pointed to by ptr.
        /// </summary>
        public int size;

        /// <summary>
        /// An reserved implementation specific field.
        /// </summary>
        public int reserved;
    }
}
