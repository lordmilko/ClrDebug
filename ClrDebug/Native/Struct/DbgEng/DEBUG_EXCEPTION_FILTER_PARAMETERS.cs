using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_EXCEPTION_FILTER_PARAMETERS structure contains the parameters for an exception filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EXCEPTION_FILTER_PARAMETERS
    {
        /// <summary>
        /// The break status of the exception filter, including the terminator. For possible values, see DEBUG_FILTER_XXX.
        /// </summary>
        public DEBUG_FILTER_EXEC_OPTION ExecutionOption;

        /// <summary>
        /// The handling status of the exception filter. For possible values, see DEBUG_FILTER_XXX.
        /// </summary>
        public DEBUG_FILTER_CONTINUE_OPTION ContinueOption;

        /// <summary>
        /// The size, in characters, of the name (including the terminator) of the exception filter. If the filter is an arbitrary exception filter, it does not have a name and TextSize is zero.
        /// </summary>
        public int TextSize;

        /// <summary>
        /// The size, in characters, of the command (including the terminator) to execute upon the first chance of the exception.
        /// </summary>
        public int CommandSize;

        /// <summary>
        /// The size, in characters, of the command (including the terminator) to execute upon the second chance of the exception.
        /// </summary>
        public int SecondCommandSize;

        /// <summary>
        /// The exception code for the exception filter.
        /// </summary>
        public int ExceptionCode;
    }
}