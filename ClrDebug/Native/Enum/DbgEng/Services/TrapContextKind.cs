namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates a particular type of trap context from which to restore underlying register context.
    /// </summary>
    public enum TrapContextKind : uint
    {
        /// <summary>
        /// Indicates restoration from a signal frame. The inbound register context is the unwound context record of a signal frame.<para/>
        /// The context of the signal point must be restored in the output record.
        /// </summary>
        TrapContextSignalFrame
    }
}
