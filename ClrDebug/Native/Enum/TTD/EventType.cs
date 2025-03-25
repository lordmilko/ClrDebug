namespace ClrDebug.TTD
{
    public enum EventType : byte
    {
        //Based on the descriptions listed in TtdTargetInfo::WaitForEvent

        PositionWatchpoint = 1,
        Exception = 2,
        Gap = 3,

        /// <summary>
        /// Indicates that the start or end of the current thread has been reached (depending on the replay direction).
        /// </summary>
        Thread = 4,
        StepCount = 5,
        Position = 6,

        /// <summary>
        /// Indicates that the start or end of the entire trace has been reached (depending on the replay direction).
        /// </summary>
        Process = 7,
        Interrupted = 8, //User Interrupt
        Error = 9, //Internal Error
    }
}
