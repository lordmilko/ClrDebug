using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Disassemble flags.
    /// </summary>
    [Flags]
    public enum DEBUG_DISASM : uint
    {
        /// <summary>
        /// Compute the effective address from current register information and display it.
        /// </summary>
        EFFECTIVE_ADDRESS = 1,

        /// <summary>
        /// If the current disassembly offset has an exact symbol match output the symbol.
        /// </summary>
        MATCHING_SYMBOLS = 2,

        /// <summary>
        /// Output the source line number for each disassembly offset.
        /// </summary>
        SOURCE_LINE_NUMBER = 4,

        /// <summary>
        /// Output the source file name (no path) for each disassembly offset.
        /// </summary>
        SOURCE_FILE_NAME = 8,
    }
}
