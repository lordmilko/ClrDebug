namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes why a live target is halted.
    /// </summary>
    public enum HaltReason : uint
    {
        /// <summary>
        /// HaltUnknown: the target is halted for an unknown reason.
        /// </summary>
        HaltUnknown,

        /// <summary>
        /// HaltRequested: the target is halted because of an explicit request from a client.
        /// </summary>
        HaltRequested,

        /// <summary>
        /// HaltStepComplete: the target is halted because a step operation completed.
        /// </summary>
        HaltStepComplete,

        /// <summary>
        /// HaltBreakpoint: the target is halted because a breakpoint was hit.
        /// </summary>
        HaltBreakpoint,

        /// <summary>
        /// HaltException: the target is halted because an exception occurred.
        /// </summary>
        HaltException,

        /// <summary>
        /// HaltProcessExit: the target is halted because the process exited or was terminated.
        /// </summary>
        HaltProcessExit
    }
}
