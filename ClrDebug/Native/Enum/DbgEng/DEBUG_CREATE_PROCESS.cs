using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_CREATE_PROCESS : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// The calling thread starts and attaches to the new process and all child processes created by the new process.<para/>
        /// A process that uses <see cref="DEBUG_PROCESS"/> becomes the root of a debugging chain. This continues until another process in the chain is created with DEBUG_PROCESS.<para/>
        /// If this flag is combined with <see cref="DEBUG_ONLY_THIS_PROCESS"/>, the caller debugs only the new process, not any child processes.
        /// </summary>
        DEBUG_PROCESS = 0x00000001,

        /// <summary>
        /// The calling thread starts and attaches to the new process.
        /// </summary>
        DEBUG_ONLY_THIS_PROCESS = 0x00000002,

        CREATE_NEW_CONSOLE = 0x00000010,
        NO_DEBUG_HEAP = 0x00000400, /* CREATE_UNICODE_ENVIRONMENT */
        THROUGH_RTL = 0x00010000, /* STACK_SIZE_PARAM_IS_A_RESERVATION */

        /// <summary>
        ///    The process is a console application that is being run without a console
        ///    window. Therefore, the console handle for the application is not set.
        ///
        ///    This flag is ignored if the application is not a console application, or if
        ///    it is used with either <see cref="CREATE_NEW_CONSOLE"/> or DETACHED_PROCESS.
        /// </summary>
        CREATE_NO_WINDOW = 0x08000000,
    }
}