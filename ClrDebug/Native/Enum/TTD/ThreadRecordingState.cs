namespace ClrDebug.TTD
{
    //From LiveRecorder

    /// <summary>
    /// Represents all possibly valid states of a thread, with respect to TTD's recording engine.
    /// </summary>
    public enum ThreadRecordingState : byte
    {
        /// <summary>
        /// Outside of a Start/Stop recording sequence.
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// Inside of a Start/Stop recording sequence and currently being recorded.
        /// </summary>
        Recording = 1,

        /// <summary>
        /// Inside of a Start/Stop recording sequence, but recording has been temporarily paused by calling the API.
        /// </summary>
        Paused = 2,

        /// <summary>
        /// Inside of a Start/Stop recording sequence, but recording has been halted by the throttling mechanism.
        /// </summary>
        Throttled = 3,
    };
}
