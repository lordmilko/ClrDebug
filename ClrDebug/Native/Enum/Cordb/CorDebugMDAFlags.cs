namespace ClrDebug
{
    /// <summary>
    /// Specifies the status of the thread on which the managed debugging assistant (MDA) is fired.
    /// </summary>
    /// <remarks>
    /// When the call stack no longer describes where the MDA was originally raised, the thread is considered to have slipped.
    /// This is an unusual circumstance brought about by the thread's execution of an invalid operation upon exiting.
    /// </remarks>
    public enum CorDebugMDAFlags
    {
        /// <summary>
        /// The thread on which the MDA was fired has slipped since the MDA was fired.
        /// </summary>
        MDA_FLAG_SLIP = 2
    }
}