using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Output mask bits.
    /// </summary>
    [Flags]
    public enum DEBUG_OUTPUT : uint
    {
        /// <summary>
        /// Normal output.
        /// </summary>
        NORMAL = 1,

        /// <summary>
        /// Error output.
        /// </summary>
        ERROR = 2,

        /// <summary>
        /// Warnings.
        /// </summary>
        WARNING = 4,

        /// <summary>
        /// Additional output.
        /// </summary>
        VERBOSE = 8,

        /// <summary>
        /// Prompt output.
        /// </summary>
        PROMPT = 0x10,

        /// <summary>
        /// Register dump before prompt.
        /// </summary>
        PROMPT_REGISTERS = 0x20,

        /// <summary>
        /// Warnings specific to extension operation.
        /// </summary>
        EXTENSION_WARNING = 0x40,

        /// <summary>
        /// Debuggee debug output, such as from OutputDebugString.
        /// </summary>
        DEBUGGEE = 0x80,

        /// <summary>
        /// Debuggee-generated prompt, such as from DbgPrompt.
        /// </summary>
        DEBUGGEE_PROMPT = 0x100,

        /// <summary>
        /// Symbol messages, such as for !sym noisy.
        /// </summary>
        SYMBOLS = 0x200,

        /// <summary>
        /// Output which modifies the status bar.
        /// </summary>
        STATUS = 0x400,

        /// <summary>
        /// Structured XML status messages.
        /// </summary>
        XML = 0x800
    }
}
