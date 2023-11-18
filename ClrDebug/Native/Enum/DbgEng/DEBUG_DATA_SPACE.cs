namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Data space indices for callbacks and other methods.
    /// </summary>
    public enum DEBUG_DATA_SPACE : uint
    {
        VIRTUAL = 0,
        PHYSICAL = 1,
        CONTROL = 2,
        IO = 3,
        MSR = 4,
        BUS_DATA = 5,
        DEBUGGER_DATA = 6,
    }
}
