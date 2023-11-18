namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Event filter continuation options. These options are only used when DEBUG_STATUS_GO
    /// is used to continue execution. If a specific go status such as DEBUG_STATUS_GO_NOT_HANDLED
    /// is used it controls the continuation.
    /// </summary>
    public enum DEBUG_FILTER_CONTINUE_OPTION : uint
    {
        GO_HANDLED = 0x00000000,
        GO_NOT_HANDLED = 0x00000001,
    }
}
