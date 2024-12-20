namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Flags that define behaviors of attaching to (or creating) a new process.
    /// </summary>
    public enum SvcAttachFlags : uint
    {
        /// <summary>
        /// No flags.
        /// </summary>
        SvcAttachNone = 0x00000000,

        /// <summary>
        /// Indicates that child processes of the given process should automatically be debugged.
        /// </summary>
        SvcAttachChildProcesses = 0x00000001
    }
}
