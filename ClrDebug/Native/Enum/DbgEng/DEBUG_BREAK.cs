using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Data breakpoint access types.<para/>
    /// Different architectures support different sets of these bits.
    /// </summary>
    [Flags]
    public enum DEBUG_BREAK : uint
    {
        READ = 1,
        WRITE = 2,
        EXECUTE = 4,
        IO = 8,
    }
}
