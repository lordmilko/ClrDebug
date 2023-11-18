namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Classes of debuggee. Each class has different qualifiers for specific kinds of debuggees.
    /// </summary>
    public enum DEBUG_CLASS : uint
    {
        UNINITIALIZED = 0,
        KERNEL = 1,
        USER_WINDOWS = 2,
        IMAGE_FILE = 3,
    }
}
