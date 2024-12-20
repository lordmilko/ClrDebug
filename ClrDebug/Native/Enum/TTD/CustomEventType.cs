namespace ClrDebug.TTD
{
    //From LiveRecorder

    /// <summary>
    /// Different types of custom events.
    /// </summary>
    public enum CustomEventType : byte
    {
        /// <summary>
        /// Thread-local events are recorder as part of the calling thread, if it's currently recording.
        /// If the calling thread is not currently recording, thread-local events are still recorded, but as global events.
        /// </summary>
        ThreadLocal = 0,

        /// <summary>
        /// Global events are not attached to any thread.
        /// </summary>
        Global = 1,
    }
}
