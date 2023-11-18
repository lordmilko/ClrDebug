namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interrupt types.
    /// </summary>
    public enum DEBUG_INTERRUPT : uint
    {
        /// <summary>
        /// Force a break in if the debuggee is running.
        /// </summary>
        ACTIVE = 0,

        /// <summary>
        /// Notify but do not force a break in.
        /// </summary>
        PASSIVE = 1,

        /// <summary>
        /// Try and get the current engine operation to complete so that the engine will be available
        /// again. If no wait is active this is the same as a passive interrupt. If a wait is active
        /// this will try to cause the wait to fail without breaking in to the debuggee. There is
        /// no guarantee that issuing an exit interrupt will cause the engine to become available
        /// as not all operations are arbitrarily interruptible.
        /// </summary>
        EXIT = 2,
    }
}
