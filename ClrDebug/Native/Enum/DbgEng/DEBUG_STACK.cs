using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// OutputStackTrace flags.
    /// </summary>
    [Flags]
    public enum DEBUG_STACK : uint
    {
        /// <summary>
        /// Display a small number of arguments for each call. These may or may not be the actual
        /// arguments depending on the architecture, particular function and point during the execution
        /// of the function. If the current code level is assembly arguments are dumped as hex values.
        /// If the code level is source the engine attempts to provide symbolic argument information.
        /// </summary>
        ARGUMENTS = 0x1,

        /// <summary>
        /// Displays information about the functions frame such as __stdcall arguments, FPO
        /// information and whatever else is available.
        /// </summary>
        FUNCTION_INFO = 0x2,

        /// <summary>
        /// Displays source line information for each frame of the stack trace.
        /// </summary>
        SOURCE_LINE = 0x4,

        /// <summary>
        /// Show return, previous frame and other relevant address values for each frame.
        /// </summary>
        FRAME_ADDRESSES = 0x8,

        /// <summary>
        /// Show column names.
        /// </summary>
        COLUMN_NAMES = 0x10,

        /// <summary>
        /// Show non-volatile register context for each frame. This is only meaningful for some platforms.
        /// </summary>
        NONVOLATILE_REGISTERS = 0x20,

        /// <summary>
        /// Show frame numbers
        /// </summary>
        FRAME_NUMBERS = 0x40,

        /// <summary>
        /// Show typed source parameters.
        /// </summary>
        PARAMETERS = 0x80,

        /// <summary>
        /// Show just return address in stack frame addresses.
        /// </summary>
        FRAME_ADDRESSES_RA_ONLY = 0x100,

        /// <summary>
        /// Show frame-to-frame memory usage.
        /// </summary>
        FRAME_MEMORY_USAGE = 0x200,

        /// <summary>
        /// Show typed source parameters one to a line.
        /// </summary>
        PARAMETERS_NEWLINE = 0x400,

        /// <summary>
        /// Produce stack output enhanced with DML content.
        /// </summary>
        DML = 0x800,

        /// <summary>
        /// Show offset from stack frame.
        /// </summary>
        FRAME_OFFSETS = 0x1000,

        /// <summary>
        /// The stack trace information is from a stack provider.
        /// </summary>
        PROVIDER = 0x2000,

        /// <summary>
        /// The architecture of the frame (for mixed architecture stacks).
        /// </summary>
        FRAME_ARCH = 0x4000
    }
}
