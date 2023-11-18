using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// OutputCurrentState flags.<para/>
    /// These flags allow a particular type of information to be displayed but do not guarantee
    /// that it will be displayed. Other global settings may override these flags or the particular
    /// state may not be available. For example, source line information may not be present so source
    /// line information may not be displayed.
    /// </summary>
    [Flags]
    public enum DEBUG_CURRENT : uint
    {
        DEFAULT = 0xf,
        SYMBOL = 1,
        DISASM = 2,
        REGISTERS = 4,
        SOURCE_LINE = 8,
    }
}
