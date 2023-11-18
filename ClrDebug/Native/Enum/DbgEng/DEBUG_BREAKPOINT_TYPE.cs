namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Types of breakpoints.
    /// </summary>
    public enum DEBUG_BREAKPOINT_TYPE : uint
    {
        CODE = 0,
        DATA = 1,
        TIME = 2,
        INLINE = 3
    }
}
