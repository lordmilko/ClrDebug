using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetSystemErrorControl"/> method.
    /// </summary>
    [DebuggerDisplay("OutputLevel = {OutputLevel.ToString(),nq}, BreakLevel = {BreakLevel.ToString(),nq}")]
    public struct GetSystemErrorControlResult
    {
        /// <summary>
        /// Receives the level at which system errors are printed to the engine's output. If the level of the system error is less than or equal to OutputLevel, the error is printed to the debugger console.
        /// </summary>
        public ERROR_LEVEL OutputLevel { get; }

        /// <summary>
        /// Receives the level at which system errors break into the debugger. If the level of the system error is less than or equal to BreakLevel, the error breaks into the debugger.
        /// </summary>
        public ERROR_LEVEL BreakLevel { get; }

        public GetSystemErrorControlResult(ERROR_LEVEL outputLevel, ERROR_LEVEL breakLevel)
        {
            OutputLevel = outputLevel;
            BreakLevel = breakLevel;
        }
    }
}
