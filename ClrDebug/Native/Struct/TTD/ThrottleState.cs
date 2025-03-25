namespace ClrDebug.TTD
{
    // Represents the progress towards the throttling limit specified for the current island of recording.
    public struct ThrottleState
    {
        /// <summary>
        /// Specifies how many instructions have been recorded in the given thread's current island so far. Note that this value becomes ever so slightly older, or more stale, as the given thread continues to run.
        /// </summary>
        public InstructionCount InstructionsExecuted;

        /// <summary>
        /// Specifies how many instructions remain before the throttle engages. Note that if there's no throttle this will always specify <see cref="InstructionCount.Invalid"/>.
        /// </summary>
        public InstructionCount InstructionsRemaining;
    }
}
