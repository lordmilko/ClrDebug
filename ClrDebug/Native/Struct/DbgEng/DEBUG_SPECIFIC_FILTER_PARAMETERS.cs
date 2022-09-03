using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_SPECIFIC_FILTER_PARAMETERS structure contains the parameters for a specific event filter.
    /// </summary>
    [DebuggerDisplay("ExecutionOption = {ExecutionOption.ToString(),nq}, ContinueOption = {ContinueOption.ToString(),nq}, TextSize = {TextSize}, CommandSize = {CommandSize}, ArgumentSize = {ArgumentSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SPECIFIC_FILTER_PARAMETERS
    {
        /// <summary>
        /// The break status of the specific event filter. For possible values, see DEBUG_FILTER_XXX.
        /// </summary>
        public DEBUG_FILTER_EXEC_OPTION ExecutionOption;

        /// <summary>
        /// The handling status of the specific event filter. For possible values, see DEBUG_FILTER_XXX.
        /// </summary>
        public DEBUG_FILTER_CONTINUE_OPTION ContinueOption;

        /// <summary>
        /// The size, in characters (including the terminator), of the name of the specific event filter.
        /// </summary>
        public int TextSize;

        /// <summary>
        /// The size, in characters, of the command (including the terminator), to execute when the event occurs.
        /// </summary>
        public int CommandSize;

        /// <summary>
        /// Specifies the size, in characters, of the specific event filter argument. This size includes the NULL terminator.<para/>
        /// If the specific event filter does not take an argument, ArgumentSize is zero.
        /// </summary>
        public int ArgumentSize;
    }
}
