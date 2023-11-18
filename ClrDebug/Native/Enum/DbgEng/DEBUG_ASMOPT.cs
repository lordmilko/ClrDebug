using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Assembly/disassembly options.<para/>
    /// The specific effects of these flags varies depending on the particular instruction set.
    /// </summary>
    [Flags]
    public enum DEBUG_ASMOPT : uint
    {
        DEFAULT = 0x00000000,

        /// <summary>
        /// Display additional information in disassembly.
        /// </summary>
        VERBOSE = 0x00000001,

        /// <summary>
        /// Do not display raw code bytes in disassembly.
        /// </summary>
        NO_CODE_BYTES = 0x00000002,

        /// <summary>
        /// Do not take the output width into account when formatting disassembly.
        /// </summary>
        IGNORE_OUTPUT_WIDTH = 0x00000004,

        /// <summary>
        /// Display source file line number before each line if available.
        /// </summary>
        SOURCE_LINE_NUMBER = 0x00000008,
    }
}
