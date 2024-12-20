namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the current "status" of a live target.
    /// </summary>
    public enum TargetStatus : uint
    {
        /// <summary>
        /// TargetRunPending: The target is expected to start running. Such has not compelted.
        /// </summary>
        TargetRunPending,

        /// <summary>
        /// TargetRunning: The target is running.
        /// </summary>
        TargetRunning,

        /// <summary>
        /// TargetHaltPending: The target is expected to start halting. Such has not completed.
        /// </summary>
        TargetHaltPending,

        /// <summary>
        /// TargetHalted: The target is halted and is not actively running instructions/threads.
        /// </summary>
        TargetHalted,

        /// <summary>
        /// TargetFaulted: The target is faulted and cannot be resumed (it may not function properly).
        /// </summary>
        TargetFaulted
    }
}
